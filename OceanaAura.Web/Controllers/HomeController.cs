using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using OceanaAura.Application.Features.ContactUs.Commands.AddContactUs;
using OceanaAura.Application.Features.LookUp.Queries.GetAllPayment;
using OceanaAura.Application.Features.LookUp.Queries.GetAllProductCategories;
using OceanaAura.Application.Features.LookUp.Queries.GetAllRegions;
using OceanaAura.Application.Features.Product.Queries.GetProduct;
using OceanaAura.Application.Features.Product.Queries.GetProductDetails;
using OceanaAura.Application.Features.Product.Queries.NormalBuy.GetColors;
using OceanaAura.Application.Features.Product.Queries.NormalBuy.GetSize;
using OceanaAura.Domain.Entities.ProductsEntities;
using OceanaAura.Web.Extensions;
using OceanaAura.Web.Models;
using OceanaAura.Web.Models.BuyVM;
using OceanaAura.Web.Models.Colors;
using OceanaAura.Web.Models.Home;
using OceanaAura.Web.Models.Lookup;
using OceanaAura.Web.Models.Products;
using OceanaAura.Web.Models.Size;
using System.Diagnostics;
using System.Drawing;

namespace OceanaAura.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly CalculateOrder calculateOrder;

        public HomeController(IMediator mediator, IMapper mapper, IMemoryCache cache, CalculateOrder calculateOrder)
        {
            _mediator = mediator;
            _mapper = mapper;
            _cache = cache;
            this.calculateOrder = calculateOrder;
        }

        private string GetSelectedRegionFromSession()
        {
            var selectedRegion = HttpContext.Session.GetString("SelectedRegionPage");
            if (string.IsNullOrEmpty(selectedRegion))
            {
                selectedRegion = "Jordan"; // Default to "Jordan" if not set
            }
            return selectedRegion;
        }

        [HttpPost]
        public IActionResult SetSelectedRegion(string selectedRegion)
        {
            HttpContext.Session.SetString("SelectedRegionPage", selectedRegion);
            return Json(new { success = true }); // Respond with success for the AJAX request
        }

        private async Task<List<RegionVM>> GetRegionsAsync()
        {
            if (!_cache.TryGetValue("Regions", out List<RegionVM> regions))
            {
                var regionsData = await _mediator.Send(new RegionQuery());
                regions = _mapper.Map<List<RegionVM>>(regionsData);

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(1)); // Set a suitable expiration time for your cache

                _cache.Set("Regions", regions, cacheOptions);
            }
            return regions;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _mediator.Send(new CategoriesQuery());
            var categoriesVM = _mapper.Map<List<CategoryVM>>(categories);

            var products = await _mediator.Send(new ProductQuery());
            var productsVM = _mapper.Map<List<ProductVMHome>>(products);

            var regions = await _mediator.Send(new RegionQuery());
            var regionsVM = _mapper.Map<List<RegionVM>>(regions);
            ViewBag.Regions = regionsVM;

            ViewBag.Products = productsVM;
            ViewBag.ProductCategory = categoriesVM;
            ViewBag.SelectedRegionPage = GetSelectedRegionFromSession(); // Set the selected region in ViewBag

            return View();
        }

        public async Task<IActionResult> ContactUs()
        {
            var regions = await _mediator.Send(new RegionQuery());
            var regionsVM = _mapper.Map<List<RegionVM>>(regions);
            ViewBag.Regions = regionsVM;

            ViewBag.SelectedRegionPage = GetSelectedRegionFromSession(); // Set the selected region in ViewBag
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactUs(ContactUsVM contactUsVM)
        {
            var regions = await _mediator.Send(new RegionQuery());
            var regionsVM = _mapper.Map<List<RegionVM>>(regions);
            ViewBag.Regions = regionsVM;

            ViewBag.SelectedRegionPage = GetSelectedRegionFromSession(); // Set the selected region in ViewBag

            if (ModelState.IsValid)
            {
                try
                {
                    var contactUsDto = _mapper.Map<AddContactUsCommand>(contactUsVM);
                    var result = await _mediator.Send(contactUsDto);

                    TempData["SuccessMessage"] = "Your message has been sent successfully!";
                    return RedirectToAction("ContactUs", "Home");
                }
                catch (Exception)
                {
                    TempData["ErrorMessage"] = "There was an error processing your request. Please try again.";
                    return View(contactUsVM);
                }
            }
            return View(contactUsVM);
        }

        public async Task<IActionResult> Store()
        {
            var products = await _mediator.Send(new ProductQuery());
            var productsVM = _mapper.Map<List<ProductVMHome>>(products);

            ViewBag.Products = productsVM;
            ViewBag.SelectedRegionPage = GetSelectedRegionFromSession(); // Set the selected region in ViewBag

            var regions = await _mediator.Send(new RegionQuery());
            var regionsVM = _mapper.Map<List<RegionVM>>(regions);
            ViewBag.Regions = regionsVM;

            return View();
        }

        public async Task<IActionResult> Buy(int id)
        {
            var categories = await _mediator.Send(new CategoriesQuery());
            var categoriesVM = _mapper.Map<List<CategoryVM>>(categories);

            var regions = await _mediator.Send(new RegionQuery());
            var regionsVM = _mapper.Map<List<RegionVM>>(regions);
            ViewBag.Regions = regionsVM;

            var product = await _mediator.Send(new ProductDetailsQuery(id));
            var productVM = _mapper.Map<ProductVM>(product);

            var sizes = await _mediator.Send(new SizeQuery());
            var sizesVM = _mapper.Map<List<SizeVM>>(sizes);

            var colors = await _mediator.Send(new GetColorQuery());
            var colorsVM = _mapper.Map<List<ColorVM>>(colors);

            ViewBag.Product = productVM;
            ViewBag.Sizes = sizesVM;
            ViewBag.Colors = colorsVM;
            ViewBag.ProductCategory = categoriesVM;
            ViewBag.SelectedRegionPage = GetSelectedRegionFromSession(); // Set the selected region in ViewBag

            return View();
        }

        [HttpPost]
        public IActionResult OrderRequest([FromForm] OrderDetails orderDetails)
        {
            HttpContext.Session.SetString("OrderDetails", JsonConvert.SerializeObject(orderDetails));

            return Json(new { success = true }); // Respond with success for the AJAX request
        }
        [HttpPost]
        public IActionResult SubOrderRequest([FromForm] SubOrderDetails subOrderDetails)
        {
            HttpContext.Session.SetString("SubOrderDetails", JsonConvert.SerializeObject(subOrderDetails));
            return Json(new { success = true }); // Respond with success for the AJAX request
        }
        [HttpGet]
        [Route("order")]
        public async Task<IActionResult> Order(string Details)
        {
            ViewBag.SelectedRegionPage = GetSelectedRegionFromSession(); // Set the selected region in ViewBag
            var regions = await _mediator.Send(new RegionQuery());
            var regionsVM = _mapper.Map<List<RegionVM>>(regions);
            ViewBag.Regions = regionsVM;
            if (Details == "SubOrderDetails")
            {
                var SubOrderDetailsJson = HttpContext.Session.GetString("SubOrderDetails");
                var SubOrderDetails = SubOrderDetailsJson != null ? JsonConvert.DeserializeObject<SubOrderDetails>(SubOrderDetailsJson) : null;


                // Fetch payment options and map to ViewModel
                var payments = await _mediator.Send(new PaymentQuery());
                var paymentsVM = _mapper.Map<List<deliveryFee>>(payments);
                ViewBag.Payments = paymentsVM.FirstOrDefault(x => x.NameEn == "Delivery Fee" || x.NameAr == "رسوم التوصيل");
                // Attempt to find the selected region by its Id
                //var selectedRegion = regionsVM.FirstOrDefault(x => x.Id == regionId)?.NameEn ?? "Jordan";
                var orderSummary = await calculateOrder.SubOrderSummaryDetails(SubOrderDetails, ViewBag.SelectedRegionPage);
                ViewBag.OrderSummary = orderSummary; // Pass OrderSummary to the view
            }
            if (Details == "OrderDetails")
            {
                var orderDetailsJson = HttpContext.Session.GetString("OrderDetails");
                var orderDetails = orderDetailsJson != null ? JsonConvert.DeserializeObject<OrderDetails>(orderDetailsJson) : null;


                // Fetch payment options and map to ViewModel
                var payments = await _mediator.Send(new PaymentQuery());
                var paymentsVM = _mapper.Map<List<deliveryFee>>(payments);
                ViewBag.Payments = paymentsVM.FirstOrDefault(x => x.NameEn == "Delivery Fee" || x.NameAr == "رسوم التوصيل");

                ViewBag.SelectedColorId = orderDetails?.ColorId;

                // Attempt to find the selected region by its Id
                //var selectedRegion = regionsVM.FirstOrDefault(x => x.Id == regionId)?.NameEn ?? "Jordan";
                var orderSummary = await calculateOrder.NormalOrderSummaryDetails(orderDetails, ViewBag.SelectedRegionPage);
                ViewBag.OrderSummary = orderSummary; // Pass OrderSummary to the view

            }

            return View();
        }
    }


}

