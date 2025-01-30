using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using OceanaAura.Application.Features.BottleImg.Queries.filteredBottleImg;
using OceanaAura.Application.Features.BottleImg.Queries.filteredBottleImgCustomize;
using OceanaAura.Application.Features.ContactUs.Commands.AddContactUs;
using OceanaAura.Application.Features.Feedback.Command.AddFeedback;
using OceanaAura.Application.Features.Feedback.Queries.GetIsShowFeedback;
using OceanaAura.Application.Features.Invoice.Commands.AddInvoice;
using OceanaAura.Application.Features.LookUp.Queries.CustomizationFees.Queries.GetCustomizationFees;
using OceanaAura.Application.Features.LookUp.Queries.GetAllPayment;
using OceanaAura.Application.Features.LookUp.Queries.GetAllProductCategories;
using OceanaAura.Application.Features.LookUp.Queries.GetAllRegions;
using OceanaAura.Application.Features.Order.Commands.CreateOrder;
using OceanaAura.Application.Features.Product.Queries.GetProduct;
using OceanaAura.Application.Features.Product.Queries.GetProductDetails;
using OceanaAura.Application.Features.Product.Queries.Lids;
using OceanaAura.Application.Features.Product.Queries.NormalBuy.GetColors;
using OceanaAura.Application.Features.Product.Queries.NormalBuy.GetSize;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.ProductsEntities;
using OceanaAura.Domain.Enums;
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

        [HttpPost]
        public IActionResult SetLanguage(string culture)
        {
            // Save the selected culture in the session
            HttpContext.Session.SetString("SelectedLanguage", culture);

            // Redirect to the previous page or home page
            return Json(new { success = true });
        }

        private string GetSelectedLanguageFromSession()
        {
            var selectedLanguage = HttpContext.Session.GetString("SelectedLanguage");
            if (string.IsNullOrEmpty(selectedLanguage))
            {
                selectedLanguage = "en"; // Default to English if not set
            }
            return selectedLanguage;
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

        [HttpPost]
        public IActionResult RemoveFromCart(int orderNumber)
        {
            // Logic to remove the product from the cart
            var cart = HttpContext.Session.GetObjectFromJson<List<OrderSummary>>("CartSummaryList") ?? new List<OrderSummary>();
            cart.RemoveAll(c => c.OrderNumber == orderNumber);
            HttpContext.Session.SetObjectAsJson("CartSummaryList", cart);

            return Json(new { success = true }); // Respond with success for the AJAX request
        }

        public async Task<IActionResult> Index()
        {
            var VisibilityFeedback = await _mediator.Send(new GetIsShowFeedbackQuery());
            var VisibilityFeedbackVM = _mapper.Map<List<VisibilityFeedbackVM>>(VisibilityFeedback);
            ViewBag.SelectedRegionPage = GetSelectedRegionFromSession(); // Set the selected region in ViewBag
            ViewBag.SelectedLanguage = GetSelectedLanguageFromSession(); // Set the selected language in ViewBag

            var categories = await _mediator.Send(new CategoriesQuery());
            var categoriesVM = _mapper.Map<List<CategoryVM>>(categories);

            var products = await _mediator.Send(new ProductQuery());
                    products = products.Where(x => !x.IsHide).ToList();

            var productsVM = _mapper.Map<List<ProductVMHome>>(products);

            var sizes = await _mediator.Send(new SizeQuery());
            var sizesVM = _mapper.Map<List<SizeVM>>(sizes);
            ViewBag.Sizes = sizesVM;

            var regions = await _mediator.Send(new RegionQuery());
            var regionsVM = _mapper.Map<List<RegionVM>>(regions);
            ViewBag.Regions = regionsVM;

            ViewBag.Products = productsVM;
            ViewBag.ProductCategory = categoriesVM;
            ViewBag.VisibilityFeedback = VisibilityFeedbackVM;

            ViewBag.CartSummaryList = GetCartSummaryFromSession(GetSelectedRegionFromSession());

            return View();
        }

        public async Task<IActionResult> ContactUs()
        {
            var regions = await _mediator.Send(new RegionQuery());
            var regionsVM = _mapper.Map<List<RegionVM>>(regions);
            ViewBag.Regions = regionsVM;

            ViewBag.CartSummaryList = GetCartSummaryFromSession(GetSelectedRegionFromSession());

            ViewBag.SelectedRegionPage = GetSelectedRegionFromSession(); // Set the selected region in ViewBag
            ViewBag.SelectedLanguage = GetSelectedLanguageFromSession(); // Set the selected language in ViewBag

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactUs(ContactUsVM contactUsVM)
        {
            var regions = await _mediator.Send(new RegionQuery());
            var regionsVM = _mapper.Map<List<RegionVM>>(regions);
            ViewBag.Regions = regionsVM;

            ViewBag.SelectedRegionPage = GetSelectedRegionFromSession(); // Set the selected region in ViewBag
            ViewBag.SelectedLanguage = GetSelectedLanguageFromSession(); // Set the selected language in ViewBag

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
            products = products.Where(x => !x.IsHide).ToList();

            var productsVM = _mapper.Map<List<ProductVMHome>>(products);

            ViewBag.Products = productsVM;
            ViewBag.SelectedRegionPage = GetSelectedRegionFromSession(); // Set the selected region in ViewBag
            ViewBag.SelectedLanguage = GetSelectedLanguageFromSession(); // Set the selected language in ViewBag

            var regions = await _mediator.Send(new RegionQuery());
            var regionsVM = _mapper.Map<List<RegionVM>>(regions);
            ViewBag.Regions = regionsVM;
            ViewBag.CartSummaryList = GetCartSummaryFromSession(GetSelectedRegionFromSession());

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetFilteredBottleImages(int productId, int sizeId, int? lidId, int? colorId)
        {
            try
            {
                // Call the handler to get filtered images
                var filteredImages = await _mediator.Send(new GetFilteredBottleImagesQuery
                {
                    SizeId = sizeId,
                    LidId = lidId,
                    ColorId = colorId
                });

                // If no filtered images are found, return the default product images
                if (filteredImages == null || !filteredImages.Any())
                {
                    var product = await _mediator.Send(new ProductDetailsQuery(productId));
                    var defaultImages = product.ImageUrls.Select(imgUrl => new BottleImgDto
                    {
                        ImgUrlFront = imgUrl
                    }).ToList();

                    return Ok(defaultImages);
                }

                return Ok(filteredImages);
            }
            catch (Exception ex)
            {
                // Log the error and return a 500 status code
                return StatusCode(500, ex.Message);
            }
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

            var Lids  = await _mediator.Send(new LidsQuery());
            var LidsVM = _mapper.Map<List<LidsVM>>(Lids);
            ViewBag.Lids = LidsVM;


            var sizes = await _mediator.Send(new SizeQuery());
            var sizesVM = _mapper.Map<List<SizeVM>>(sizes);
            ViewBag.Sizes = sizesVM;

            var colors = await _mediator.Send(new GetColorQuery());
            var colorsVM = _mapper.Map<List<ColorVM>>(colors);

            ViewBag.Product = productVM;
            ViewBag.Colors = colorsVM;
            ViewBag.ProductCategory = categoriesVM;
            ViewBag.SelectedRegionPage = GetSelectedRegionFromSession(); // Set the selected region in ViewBag
            ViewBag.SelectedLanguage = GetSelectedLanguageFromSession(); // Set the selected language in ViewBag
            ViewBag.CartSummaryList = GetCartSummaryFromSession(ViewBag.SelectedRegionPage);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OrderRequest([FromForm] OrderDetails orderDetails)
        {
            if (!string.IsNullOrEmpty(orderDetails.FontFamily))
            {
                orderDetails.IsCustomize = true;
                orderDetails.Quantity = 1;
                var products = await _mediator.Send(new ProductQuery());
                orderDetails.ProductId = products.FirstOrDefault(x => !x.IsHide).Id;
            }
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
            var colors = await _mediator.Send(new GetColorQuery());
            var colorsVM = _mapper.Map<List<ColorVM>>(colors);
            ViewBag.Colors = colorsVM;

            ViewBag.SelectedRegionPage = GetSelectedRegionFromSession(); // Set the selected region in ViewBag
            ViewBag.SelectedLanguage = GetSelectedLanguageFromSession(); // Set the selected language in ViewBag

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
                if (orderDetails.IsCustomize)
                {
                    var CustomizationFees = await _mediator.Send(new CustomizationFeesQuery());
                    var CustomizationFeesVM = _mapper.Map<CustomizationFeesVM>(CustomizationFees);
                    ViewBag.CustomizationFees = CustomizationFeesVM;
                }
                var orderSummary = await calculateOrder.NormalOrderSummaryDetails(orderDetails, ViewBag.SelectedRegionPage);
                ViewBag.OrderSummary = orderSummary; // Pass OrderSummary to the view
            }

            ViewBag.CartSummaryList = GetCartSummaryFromSession(GetSelectedRegionFromSession());
            ViewBag.Details = Details;

            return View();
        }

        [HttpPost]
        [Route("order")]
        public async Task<IActionResult> Order(OrderRequest orderRequest)
        {
            // Set ViewBag data similar to the GET request
            ViewBag.SelectedRegionPage = GetSelectedRegionFromSession(); // Set the selected region in ViewBag
            ViewBag.SelectedLanguage = GetSelectedLanguageFromSession(); // Set the selected language in ViewBag

            // Fetch color options
            var colors = await _mediator.Send(new GetColorQuery());
            var colorsVM = _mapper.Map<List<ColorVM>>(colors);
            ViewBag.Colors = colorsVM;

            // Fetch regions
            var regions = await _mediator.Send(new RegionQuery());
            var regionsVM = _mapper.Map<List<RegionVM>>(regions);
            ViewBag.Regions = regionsVM;
            if(ViewBag.SelectedRegionPage == "Jordan")
            {
                orderRequest.RegionId = regions.FirstOrDefault(x => x.NameEn == "Jordan").Id;
            }
            if (ViewBag.SelectedRegionPage == "United Arab Emirates")
            {
                orderRequest.RegionId = regions.FirstOrDefault(x => x.NameEn == "United Arab Emirates").Id;
            }
            // If Details is "SubOrderDetails", set SubOrderDetails and OrderSummary
            if (orderRequest.Details == "SubOrderDetails")
            {
                var SubOrderDetailsJson = HttpContext.Session.GetString("SubOrderDetails");
                var SubOrderDetails = SubOrderDetailsJson != null ? JsonConvert.DeserializeObject<SubOrderDetails>(SubOrderDetailsJson) : null;

                // Fetch payment options
                var payments = await _mediator.Send(new PaymentQuery());
                var paymentsVM = _mapper.Map<List<deliveryFee>>(payments);
                ViewBag.Payments = paymentsVM.FirstOrDefault(x => x.NameEn == "Delivery Fee" || x.NameAr == "رسوم التوصيل");

                // Calculate order summary and pass it to the view
                var orderSummary = await calculateOrder.SubOrderSummaryDetails(SubOrderDetails, ViewBag.SelectedRegionPage);
                ViewBag.OrderSummary = orderSummary;
            }

            // If Details is "OrderDetails", set OrderDetails and OrderSummary
            if (orderRequest.Details == "OrderDetails")
            {
                var orderDetailsJson = HttpContext.Session.GetString("OrderDetails");
                var orderDetails = orderDetailsJson != null ? JsonConvert.DeserializeObject<OrderDetails>(orderDetailsJson) : null;
                orderRequest.IsCustomize = orderDetails.IsCustomize;
                // Fetch payment options
                var payments = await _mediator.Send(new PaymentQuery());
                var paymentsVM = _mapper.Map<List<deliveryFee>>(payments);
                ViewBag.Payments = paymentsVM.FirstOrDefault(x => x.NameEn == "Delivery Fee" || x.NameAr == "رسوم التوصيل");

                if (orderDetails.IsCustomize)
                {
                    var CustomizationFees = await _mediator.Send(new CustomizationFeesQuery());
                    var CustomizationFeesVM = _mapper.Map<CustomizationFeesVM>(CustomizationFees);
                    ViewBag.CustomizationFees = CustomizationFeesVM;
                }

                ViewBag.SelectedColorId = orderDetails?.ColorId;

                // Calculate order summary and pass it to the view
                var orderSummary = await calculateOrder.NormalOrderSummaryDetails(orderDetails, ViewBag.SelectedRegionPage);
                ViewBag.OrderSummary = orderSummary;
            }

            ViewBag.Details = orderRequest.Details;
            // Set cart summary from session
            ViewBag.CartSummaryList = GetCartSummaryFromSession(ViewBag.SelectedRegionPage);

            if (!ModelState.IsValid)
            {
                // Return the view with validation errors.
                return View(orderRequest);
            }

            // Map OrderRequest to OrderDto
            var cartOrder = new cartCommand
            {
                PaymentId = orderRequest.PaymentId,
                Quantity = orderRequest.Quantity,
                SizeId = orderRequest.SizeId,
                ColorId = orderRequest.ColorId,
                TotalPrice = orderRequest.TotalPrice,
                Shipping = orderRequest.Shipping,
                ProductId = orderRequest.ProductId,
                ProductPrice = orderRequest.ProductPrice,
                LidName = orderRequest.LidName,
                LidId = orderRequest.LidId,
                LidPrice = orderRequest.LidPrice,
                Text = orderRequest.Text,
                IsCustomize = orderRequest.IsCustomize,
                FontFamily = orderRequest.FontFamily,
                CustomizationFees = orderRequest.CustomizationFees
            };

            var OrderDto = _mapper.Map<OrderDto>(orderRequest);

            var carts = new List<cartCommand>();
            carts.Add(cartOrder);
            OrderDto.carts = carts;
            var result = await _mediator.Send(OrderDto);
            await _mediator.Send(new InvoiceCommand() { OrderId = result });

            ViewBag.OrderSuccessMessage = "Your order has been placed successfully!";

            return View();
        }
        public async Task<IActionResult> Feedback()
        {
            var categories = await _mediator.Send(new CategoriesQuery());
            var categoriesVM = _mapper.Map<List<CategoryVM>>(categories);

            var regions = await _mediator.Send(new RegionQuery());
            var regionsVM = _mapper.Map<List<RegionVM>>(regions);
            ViewBag.Regions = regionsVM;

            var products = await _mediator.Send(new ProductQuery());

            // Filter products that are not hidden and get the first one (or null)
            var product = products.Where(x => !x.IsHide).FirstOrDefault();

            // Map the single product to ProductVMHome
            var productVM = _mapper.Map<ProductVMHome>(product);

            // Assign the mapped product to ViewBag.Product
            ViewBag.Product = productVM;

            var Lids = await _mediator.Send(new LidsQuery());
            var LidsVM = _mapper.Map<List<LidsVM>>(Lids);
            ViewBag.Lids = LidsVM;


            var sizes = await _mediator.Send(new SizeQuery());
            var sizesVM = _mapper.Map<List<SizeVM>>(sizes);
            ViewBag.Sizes = sizesVM;

            var colors = await _mediator.Send(new GetColorQuery());
            var colorsVM = _mapper.Map<List<ColorVM>>(colors);

            ViewBag.Colors = colorsVM;
            ViewBag.ProductCategory = categoriesVM;
            ViewBag.SelectedRegionPage = GetSelectedRegionFromSession(); // Set the selected region in ViewBag
            ViewBag.SelectedLanguage = GetSelectedLanguageFromSession(); // Set the selected language in ViewBag
            ViewBag.CartSummaryList = GetCartSummaryFromSession(ViewBag.SelectedRegionPage);
            return View();
        }
        private List<OrderSummary> GetCartSummaryFromSession(string region)
        {
            // Retrieve the cart summary list from session
            var cartSummaryList = HttpContext.Session.GetObjectFromJson<List<OrderSummary>>("CartSummaryList") ?? new List<OrderSummary>();

            // Filter the list based on the specified region
            return cartSummaryList.Where(order => order.Region == region).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart([FromForm] CartItem cartItem, string Details)
        {
            ViewBag.SelectedRegionPage = GetSelectedRegionFromSession(); // Set the selected region in ViewBag
            ViewBag.SelectedLanguage = GetSelectedLanguageFromSession(); // Set the selected language in ViewBag

            // Create a list to hold cart summaries if it doesn't exist in session
            var cartSummaryList = HttpContext.Session.GetObjectFromJson<List<OrderSummary>>("CartSummaryList") ?? new List<OrderSummary>();

            if (Details == "OrderDetails")
            {
                // Generate a random OrderNumber for this request
                var orderNumber = GenerateRandomOrderNumber();

                var orderDetails = new OrderDetails
                {
                    ColorId = cartItem.ColorId,
                    Quantity = cartItem.Quantity,
                    SizeId = cartItem.SizeId,
                    ProductId = cartItem.ProductId,
                    LidId = cartItem.LidId
                };

                var cartSummary1 = await calculateOrder.NormalOrderSummaryDetails(orderDetails, "Jordan");
                var cartSummary11 = await calculateOrder.NormalOrderSummaryDetails(orderDetails, "United Arab Emirates");

                // Assign the same OrderNumber to both summaries
                cartSummary1.OrderNumber = orderNumber;
                cartSummary11.OrderNumber = orderNumber;

                // Add the cart summaries to the list
                cartSummaryList.Add(cartSummary1);
                cartSummaryList.Add(cartSummary11);
            }

            if (Details == "SubOrderDetails")
            {
                // Generate a random OrderNumber for this request
                var orderNumber = GenerateRandomOrderNumber();

                var subOrderDetails = new SubOrderDetails
                {
                    Quantity = cartItem.Quantity,
                    ProductId = cartItem.ProductId
                };

                var cartSummary2 = await calculateOrder.SubOrderSummaryDetails(subOrderDetails, "Jordan");
                var cartSummary22 = await calculateOrder.SubOrderSummaryDetails(subOrderDetails, "United Arab Emirates");

                // Assign the same OrderNumber to both summaries
                cartSummary2.OrderNumber = orderNumber;
                cartSummary22.OrderNumber = orderNumber;

                // Add the cart summaries to the list
                cartSummaryList.Add(cartSummary2);
                cartSummaryList.Add(cartSummary22);
            }

            // Save the updated list back to session
            HttpContext.Session.SetObjectAsJson("CartSummaryList", cartSummaryList);

            return Json(new { success = true });
        }

        // Helper method to generate a random OrderNumber
        private int GenerateRandomOrderNumber()
        {
            var random = new Random();
            return random.Next(100000, 999999); // Generate a 6-digit random number
        }

        public async Task<IActionResult> BuyCartAsync()
       {
            var colors = await _mediator.Send(new GetColorQuery());
            var colorsVM = _mapper.Map<List<ColorVM>>(colors);
            ViewBag.Colors = colorsVM;

            var payments = await _mediator.Send(new PaymentQuery());
            var paymentsVM = _mapper.Map<List<deliveryFee>>(payments);
            ViewBag.Payments = paymentsVM.FirstOrDefault(x => x.NameEn == "Delivery Fee" || x.NameAr == "رسوم التوصيل");

            ViewBag.SelectedRegionPage = GetSelectedRegionFromSession(); // Set the selected region in ViewBag
            ViewBag.SelectedLanguage = GetSelectedLanguageFromSession(); // Set the selected language in ViewBag

            var regions = await _mediator.Send(new RegionQuery());
            var regionsVM = _mapper.Map<List<RegionVM>>(regions);
            ViewBag.Regions = regionsVM;

            ViewBag.CartSummaryList = GetCartSummaryFromSession(GetSelectedRegionFromSession());

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BuyCart(CartsOrder cartsOrder)
        {
            var colors = await _mediator.Send(new GetColorQuery());
            var colorsVM = _mapper.Map<List<ColorVM>>(colors);
            ViewBag.Colors = colorsVM;

            var payments = await _mediator.Send(new PaymentQuery());
            var paymentsVM = _mapper.Map<List<deliveryFee>>(payments);
            ViewBag.Payments = paymentsVM.FirstOrDefault(x => x.NameEn == "Delivery Fee" || x.NameAr == "رسوم التوصيل");

            var regions = await _mediator.Send(new RegionQuery());
            var regionsVM = _mapper.Map<List<RegionVM>>(regions);
            ViewBag.Regions = regionsVM;

            ViewBag.SelectedRegionPage = GetSelectedRegionFromSession(); // Set the selected region in ViewBag
            ViewBag.SelectedLanguage = GetSelectedLanguageFromSession(); // Set the selected language in ViewBag

            ViewBag.CartSummaryList = GetCartSummaryFromSession(GetSelectedRegionFromSession());

            if (!ModelState.IsValid)
            {
                return View(cartsOrder);
            }

            var OrderDto = _mapper.Map<OrderDto>(cartsOrder);
            var carts = new List<cartCommand>();
            var cartSummaryList = ViewBag.CartSummaryList as List<OrderSummary>; // Assuming CartSummary is the correct type
            if (cartSummaryList != null)
            {
                foreach (var item in cartSummaryList)
                {
                    var cart = new cartCommand
                    {
                        PaymentId = ViewBag.Payments.Id,
                        Quantity = item.Quantity,
                        SizeId = item.SizeId,
                        ColorId = item.ColorId,
                        TotalPrice = item.Total,
                        Shipping = item.deliveryFee,
                        ProductId = (int)item.Product.Id,
                        ProductPrice = item.ProductPrice,
                        LidName = item.LidName,
                        LidId = item.LidId,
                        LidPrice = item.LidPrice,
                    };
                    carts.Add(cart);
                }
            }

            OrderDto.carts = carts;
            OrderDto.Region = ViewBag.SelectedRegionPage;
            var result = await _mediator.Send(OrderDto);

            if (result > 0)
            {
                await _mediator.Send(new InvoiceCommand() { OrderId = result });
                ViewBag.OrderSuccessMessage = "Your order has been placed successfully!";

                var cartSession = HttpContext.Session.GetObjectFromJson<List<OrderSummary>>("CartSummaryList") ?? new List<OrderSummary>();
                // Remove all items from the cart
                cartSession.Clear();
                HttpContext.Session.SetObjectAsJson("CartSummaryList", cartSession);

                ViewBag.ShowSweetAlert = "Your order has been placed successfully and sent to your email"; // Set this based on your condition
                return View();
            }
            else
            {
                ViewBag.ShowSweetAlert = "Failed to place the order. Please try again."; // Set this based on your condition
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddFeedback([FromBody] AddFeedbackCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors if the model state is invalid
            }

            var feedbackId = await _mediator.Send(command); // Send the command to the handler

            return Ok(new { FeedbackId = feedbackId }); // Return the created feedback ID
        }

        public async Task<IActionResult> DesignEditor()
        {
            var colors = await _mediator.Send(new GetColorQuery());
            var colorsVM = _mapper.Map<List<ColorVM>>(colors);
            ViewBag.Colors = colorsVM;
            var lids = await _mediator.Send(new LidsQuery());
            var lidsVM = _mapper.Map<List<LidsVM>>(lids);
            ViewBag.Lids = lidsVM;
            var sizes = await _mediator.Send(new SizeQuery());
            var sizesVM = _mapper.Map<List<SizeVM>>(sizes);
            ViewBag.Sizes = sizesVM;
            var Lids = await _mediator.Send(new LidsQuery());
            var LidsVM = _mapper.Map<List<LidsVM>>(Lids);
            ViewBag.Lids = LidsVM;
            var regions = await _mediator.Send(new RegionQuery());
            var regionsVM = _mapper.Map<List<RegionVM>>(regions);
            ViewBag.Regions = regionsVM;
            ViewBag.SelectedRegionPage = GetSelectedRegionFromSession(); // Set the selected region in ViewBag
            ViewBag.SelectedLanguage = GetSelectedLanguageFromSession(); // Set the selected language in ViewBag
            ViewBag.CartSummaryList = GetCartSummaryFromSession(GetSelectedRegionFromSession());
            return View();
        }
        public async Task<IActionResult> GetFilteredBottleImg(int sizeId, int colorId, int lidId)
        {
            var query = new filteredBottleImgCustomizeQuery
            {
                SizeId = sizeId,
                ColorId = colorId,
                LidId = lidId
            };

            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        public async Task<IActionResult> Help()
        {
            var colors = await _mediator.Send(new GetColorQuery());
            var colorsVM = _mapper.Map<List<ColorVM>>(colors);
            ViewBag.Colors = colorsVM;
            var lids = await _mediator.Send(new LidsQuery());
            var lidsVM = _mapper.Map<List<LidsVM>>(lids);
            ViewBag.Lids = lidsVM;
            var sizes = await _mediator.Send(new SizeQuery());
            var sizesVM = _mapper.Map<List<SizeVM>>(sizes);
            ViewBag.Sizes = sizesVM;
            var Lids = await _mediator.Send(new LidsQuery());
            var LidsVM = _mapper.Map<List<LidsVM>>(Lids);
            ViewBag.Lids = LidsVM;
            var regions = await _mediator.Send(new RegionQuery());
            var regionsVM = _mapper.Map<List<RegionVM>>(regions);
            ViewBag.Regions = regionsVM;
            var products = await _mediator.Send(new ProductQuery());
            products = products.Where(x => !x.IsHide).ToList();
            var productsVM = _mapper.Map<List<ProductVMHome>>(products);
            ViewBag.Products = productsVM;

            ViewBag.SelectedRegionPage = GetSelectedRegionFromSession(); // Set the selected region in ViewBag
            ViewBag.SelectedLanguage = GetSelectedLanguageFromSession(); // Set the selected language in ViewBag
            ViewBag.CartSummaryList = GetCartSummaryFromSession(GetSelectedRegionFromSession());
            return View();
        }
    }
}