using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OceanaAura.Application.Contracts.Identity;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Features.BottleImg.Command.AddBottleImg;
using OceanaAura.Application.Features.BottleImg.Command.DeleteBottleImg;
using OceanaAura.Application.Features.BottleImg.Queries.GetAllBottleImg;
using OceanaAura.Application.Features.ContactUs.Commands.DeleteContactUs;
using OceanaAura.Application.Features.ContactUs.Queries.GetAllContactUs;
using OceanaAura.Application.Features.ContactUs.Queries.GetContactUsWithDetails;
using OceanaAura.Application.Features.Feedback.Command.DeleteFeedback;
using OceanaAura.Application.Features.Feedback.Command.UpdateVisabilityFeedback;
using OceanaAura.Application.Features.Feedback.Queries.GetAllFeedback;
using OceanaAura.Application.Features.Feedback.Queries.GetFeedbacks;
using OceanaAura.Application.Features.Invoice.Queries.GetAllInvoices;
using OceanaAura.Application.Features.Invoice.Queries.GetInvoices;
using OceanaAura.Application.Features.LidProduct.Command.AddLid;
using OceanaAura.Application.Features.LookUp.Commands.AddCagegory;
using OceanaAura.Application.Features.LookUp.Commands.Additional;
using OceanaAura.Application.Features.LookUp.Commands.DeleteAdditional;
using OceanaAura.Application.Features.LookUp.Commands.DeleteCategory;
using OceanaAura.Application.Features.LookUp.Queries.GetAllAdditinalProduct;
using OceanaAura.Application.Features.LookUp.Queries.GetAllPayment;
using OceanaAura.Application.Features.LookUp.Queries.GetAllProductCategories;
using OceanaAura.Application.Features.LookUp.Queries.GetAllRegions;
using OceanaAura.Application.Features.LookUp.Queries.GetAllStatus;
using OceanaAura.Application.Features.LookUp.Queries.GetProductCategories;
using OceanaAura.Application.Features.Order.Commands.DeleteOrder;
using OceanaAura.Application.Features.Order.Commands.UpdateOrder;
using OceanaAura.Application.Features.Order.Queries.GetAllOrder;
using OceanaAura.Application.Features.Order.Queries.GetOrders;
using OceanaAura.Application.Features.Order.Queries.GetOrdersWithStatus;
using OceanaAura.Application.Features.Product.Command.AddProduct;
using OceanaAura.Application.Features.Product.Command.DeleteImg;
using OceanaAura.Application.Features.Product.Command.DeleteProduct;
using OceanaAura.Application.Features.Product.Command.EditProduct;
using OceanaAura.Application.Features.Product.Queries.GetAllProduct;
using OceanaAura.Application.Features.Product.Queries.GetCategoryWithNumberProduct;
using OceanaAura.Application.Features.Product.Queries.GetProduct;
using OceanaAura.Application.Features.Product.Queries.GetProductDetails;
using OceanaAura.Application.Features.Product.Queries.NormalBuy.GetColors;
using OceanaAura.Application.Features.Product.Queries.NormalBuy.GetSize;
using OceanaAura.Application.Features.ProductColor.Commands.AddColor;
using OceanaAura.Application.Features.ProductColor.Commands.DeleteColor;
using OceanaAura.Application.Features.ProductColor.Commands.UpdateColor;
using OceanaAura.Application.Features.ProductColor.Commands.UpdateSoldOutColor;
using OceanaAura.Application.Features.ProductColor.Queries.GetAllProductColors;
using OceanaAura.Application.Features.ProductSize.Command.AddSize;
using OceanaAura.Application.Features.ProductSize.Command.DeleteSize;
using OceanaAura.Application.Features.ProductSize.Queries.GetAllSize;
using OceanaAura.Application.Models.Identity.Password;
using OceanaAura.Application.Models.Identity.UserInfo;
using OceanaAura.Domain.Entities.ProductsEntities;
using OceanaAura.Domain.Enums;
using OceanaAura.Web.Extensions;
using OceanaAura.Web.Models.Auth;
using OceanaAura.Web.Models.BuyVM;
using OceanaAura.Web.Models.Colors;
using OceanaAura.Web.Models.Lookup;
using OceanaAura.Web.Models.Products;
using OceanaAura.Web.Models.Size;
using System.Drawing;
using System.Linq;
using System.Security.Policy;

namespace OceanaAura.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AdminController(IAuthService authService, IMapper mapper, IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _authService = authService;
            _mapper = mapper;
            _mediator = mediator;
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Dashboard()
        {
            var ProductNumber = await _mediator.Send(new ProductQuery());
            var OrderNumber  = await _mediator.Send(new OrdersQuery());
            var FeedbackNumber = await _mediator.Send(new GetAllFeedbacksQuery());
            var InvoiceNumber = await _mediator.Send(new InvoicesQuery());
            var OrdersWithStatus = await _mediator.Send(new GetOrdersWithStatusQuery());
            var CategoryWithNumberProduct = await _mediator.Send(new GetCategoryWithNumberProductQuery());

            var DashboardVM = new DashboardVM()
            {
                ProductNumber = ProductNumber.Count(),
                OrderNumber = OrderNumber.Count(),
                FeedbackNumber = FeedbackNumber.Count(),
                InvoiceNumber = InvoiceNumber.Count(),
                OrdersWithStatus = OrdersWithStatus,
                CategoryWithNumberProduct = CategoryWithNumberProduct

            };
            return View(DashboardVM);
        }
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout();
            return RedirectToAction("Login", "Auth");
        }
        public async Task<IActionResult> Profile()
        {
            var userDto = await _authService.GetUserInfo(User.Identity.Name);
            var UserVM = _mapper.Map<UpdateInfo>(userDto);
            return View(UserVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF Protection
        public async Task<IActionResult> Profile(UpdateInfo request)
        {
            if (!ModelState.IsValid)
                return View(request);

            try
            {
                var updateInfoRequest = _mapper.Map<UpdateInfoRequest>(request);
                await _authService.UpdateInfo(updateInfoRequest);
                TempData["UpdateProfile"] = "Profile updated successfully!";
                return RedirectToAction("Profile");
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(request);
            }
            catch (BadRequestException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(request);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again later.");
                return View(request);
            }
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var ChangeNewPasswordRequest = _mapper.Map<ChangeNewPassowrd>(model);
                var result = await _authService.ChangeNewPassowrd(ChangeNewPasswordRequest);
                if (result.Succeeded)
                {
                    TempData["ChangePassword"] = "Password has been successfully changed!";
                    return RedirectToAction("Profile", "Admin");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            catch (BadRequestException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again.");
            }
            return View(model);
        }

        public async Task<IActionResult> ContactMessages()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ContactsUs()
        {
            var draw = int.Parse(Request.Form["draw"].FirstOrDefault() ?? "0");
            var start = int.Parse(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = int.Parse(Request.Form["length"].FirstOrDefault() ?? "0");
            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];
            var searchValue = Request.Form["search[value]"];
            var searchDate = Request.Form["searchDate"];  // Capture the searchDate parameter
            // Fetch paginated data using Mediator
            var (contactsUs, totalRecords) = await _mediator.Send(new PaginatedContactUsQuery
            {
                Start = start,
                Length = length,
                SearchValue = searchValue,
                SearchDate = searchDate,  // Include the searchDate filter here
                SortColumn = sortColumn,
                SortDirection = sortColumnDirection
            });

            // Prepare JSON response for DataTable
            var jsonData = new
            {
                draw,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
                data = contactsUs
            };

            return Ok(jsonData);
        }
        [HttpGet]
        public async Task<IActionResult> GetContactMessageDetails(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { Message = "Invalid message ID provided." });
            }

            var contactUsDetails = await _mediator.Send(new ContactUsDetailsQuery(id));

            if (contactUsDetails == null)
            {
                return NotFound(new { Message = "Contact message not found." });
            }
            return Json(contactUsDetails);
        }
        [HttpPost]
        public async Task<JsonResult> DeleteContactMessage(int id)
        {
            try
            {
                var command = new DeleteContactUsCommand { Id = id };
                await _mediator.Send(command);
                return Json(new { success = true, message = "Message deleted successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while deleting the message." });
            }
        }
        public async Task<IActionResult> Products()
        {
            var categories = await _mediator.Send(new CategoriesQuery());
            var CategoriesVM = _mapper.Map<List<CategoryVM>>(categories);
            ViewBag.Categories = CategoriesVM;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetAllProducts()
        {
            var draw = int.Parse(Request.Form["draw"].FirstOrDefault() ?? "0");
            var start = int.Parse(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = int.Parse(Request.Form["length"].FirstOrDefault() ?? "0");
            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];
            var searchValue = Request.Form["search[value]"];
            var searchDate = Request.Form["searchDate"];  // Capture the searchDate parameter
            // Fetch paginated data using Mediator
            var (products, totalRecords) = await _mediator.Send(new PaginatedProductQuery
            {
                Start = start,
                Length = length,
                SearchValue = searchValue,
                SortColumn = sortColumn,
                SortDirection = sortColumnDirection
            });

            // Prepare JSON response for DataTable
            var jsonData = new
            {
                draw,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
                data = products
            };

            return Ok(jsonData);
        }
        public async Task<IActionResult> EditProduct(int id)
        {


            if (id <= 0)
            {
                ViewBag.ErrorMessage = "Invalid product ID provided.";
                return RedirectToAction("Products");
            }

            var productDetailsDto = await _mediator.Send(new ProductDetailsQuery(id));

            if (productDetailsDto == null)
            {
                ViewBag.ErrorMessage = "Product not found.";
                return RedirectToAction("Products");
            }

            // Map ProductDetailsDto to ProductVM
            var productVM = _mapper.Map<EditProductVM>(productDetailsDto);

            var categories = await _mediator.Send(new CategoriesQuery());
            var CategoriesVM = _mapper.Map<List<CategoryVM>>(categories);
            productVM.categoryVMs = CategoriesVM;
            return View(productVM);
        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(EditProductVM productVM)
        {
            var categories = await _mediator.Send(new CategoriesQuery());
            var CategoriesVM = _mapper.Map<List<CategoryVM>>(categories);
            productVM.categoryVMs = CategoriesVM;
            var imgs = await _mediator.Send(new ProductDetailsQuery(productVM.Id));
            productVM.ImageUrls = imgs.ImageUrls;
            // Validate the model using FluentValidation
            var validator = new EditProductVMalidator(_mediator);
            var validationResult = await validator.ValidateAsync(productVM);

            if (!validationResult.IsValid)
            {
                // If validation fails, return the view with error messages
                foreach (var failure in validationResult.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }

                return View(productVM); // Return the productVM with validation errors
            }
            var imageUrls = new List<string>();

            if (productVM.Images != null && productVM.Images.Any())
            {
                foreach (var image in productVM.Images)
                {
                    if (image.Length > 0)
                    {
                        var imageUrl = await FileExtensions.ConvertFileToStringAsync(image, webHostEnvironment);
                        if (!string.IsNullOrEmpty(imageUrl))
                        {
                            imageUrls.Add(imageUrl);
                        }
                    }
                }
            }

            var productCommand = _mapper.Map<EditProductCommand>(productVM);
            productCommand.ImageUrls = imageUrls;
            productCommand.IsHide = productVM.IsHide;
            var result = await _mediator.Send(productCommand);
            return RedirectToAction("Products", "Admin");

        }
        [HttpPost]
        public async Task<IActionResult> DeleteImage(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return Json(new { success = false, message = "Image URL is required." });
            }

            try
            {
                var deleteCommand = new DeleteImageCommand { Url = url };
                await _mediator.Send(deleteCommand);
                FileExtensions.DeleteFileFromFileFolder(url, webHostEnvironment);
                // Return success response
                return Json(new { success = true, message = "Image deleted successfully." });
            }
            catch (NotFoundException ex)
            {
                // Return error message if image is not found
                return Json(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                // Return a generic error message
                return Json(new { success = false, message = "An error occurred while deleting the image." });
            }
        }
        public async Task<IActionResult> AddProduct()
        {
            var categories = await _mediator.Send(new CategoriesQuery());
            var CategoriesVM = _mapper.Map<List<CategoryVM>>(categories);
            ViewBag.Categories = CategoriesVM;
            return View();
        }
        public async Task<IActionResult> AddBottleImg()
        {
            var sizes = await _mediator.Send(new SizeQuery());
            var sizesVM = _mapper.Map<List<SizeVM>>(sizes);
            ViewBag.Sizes = sizesVM;

            var colors = await _mediator.Send(new GetColorQuery());
            var colorsVM = _mapper.Map<List<ColorVM>>(colors);
            ViewBag.Colors = colorsVM;

            var products = await _mediator.Send(new ProductQuery());
            products = products.Where(p => p.CategoryId == (int)LookUpEnums.ProductCategory.Lids).ToList();
            var productsVM = _mapper.Map<List<ProductVMHome>>(products);
            ViewBag.Products = productsVM;
            return View();
        }

        // POST: AddBottleImg
[HttpPost]
public async Task<IActionResult> AddBottleImg(AddBottleImg model)
{
    // Validate the model
    var validator = new AddBottleImgValidator();
    var validationResult = await validator.ValidateAsync(model);

    if (!validationResult.IsValid)
    {
        // Add validation errors to ModelState
        foreach (var error in validationResult.Errors)
        {
            ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }

        // Repopulate ViewBag data for the form
        var sizes = await _mediator.Send(new SizeQuery());
        var sizesVM = _mapper.Map<List<SizeVM>>(sizes);
        ViewBag.Sizes = sizesVM;

        var colors = await _mediator.Send(new GetColorQuery());
        var colorsVM = _mapper.Map<List<ColorVM>>(colors);
        ViewBag.Colors = colorsVM;

        var products = await _mediator.Send(new ProductQuery());
        products = products.Where(p => p.CategoryId == (int)LookUpEnums.ProductCategory.Lids).ToList();
        var productsVM = _mapper.Map<List<ProductVMHome>>(products);
        ViewBag.Products = productsVM;

        // Return the view with the model and validation errors
        return View(model);
    }

    // Process the form data if validation passes
    if (model.Img != null)
    {
        model.ImgUrl = await FileExtensions.ConvertFileToStringAsync(model.Img, webHostEnvironment);
    }

    var addBottleImgDto = _mapper.Map<AddBottleImgDto>(model);
    var bottleImgId = await _mediator.Send(addBottleImgDto);

    return RedirectToAction("BottleImg", "Admin");
}
        [HttpPost]
        public async Task<IActionResult> DeleteBottleImg(int id, string imgUrl)
        {
            try
            {
                // Delete the database record
                var result = await _mediator.Send(new DeleteBottleImg { BottleImgId = id });

                // Delete the image file from the server
                if (!string.IsNullOrEmpty(imgUrl))
                {
                    FileExtensions.DeleteFileFromFileFolder(imgUrl, webHostEnvironment);
                }

                return Json(new { success = true, message = "Bottle image deleted successfully." });
            }
            catch (NotFoundException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while deleting the bottle image." });
            }
        }
        // GET: BottleImg
        public async Task<IActionResult> BottleImg()
        {
            var sizes = await _mediator.Send(new SizeQuery());
            var sizesVM = _mapper.Map<List<SizeVM>>(sizes);
            ViewBag.Sizes = sizesVM;

            var colors = await _mediator.Send(new GetColorQuery());
            var colorsVM = _mapper.Map<List<ColorVM>>(colors);
            ViewBag.Colors = colorsVM;

            var products = await _mediator.Send(new ProductQuery());
            products = products.Where(p => p.CategoryId == (int)LookUpEnums.ProductCategory.Lids).ToList();

            var productsVM = _mapper.Map<List<ProductVMHome>>(products);
            ViewBag.Products = productsVM;

            return View();
        }

        // POST: BottleImg (Fetch paginated data for DataTables)
        [HttpPost]
        public async Task<IActionResult> GetAllBottleImg()
        {
            // Parse DataTables parameters
            var draw = int.Parse(Request.Form["draw"].FirstOrDefault() ?? "0");
            var start = int.Parse(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = int.Parse(Request.Form["length"].FirstOrDefault() ?? "0");

            // Fetch paginated data using Mediator
            var (bottleImgs, totalRecords) = await _mediator.Send(new PaginatedBottleImg
            {
                Start = start,
                Length = length
            });
            // Prepare JSON response for DataTables
            var jsonData = new
            {
                draw,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
                data = bottleImgs
            };

            return Ok(jsonData);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductVM productVM)
        {
            var categories = await _mediator.Send(new CategoriesQuery());
            var CategoriesVM = _mapper.Map<List<CategoryVM>>(categories);
            ViewBag.Categories = CategoriesVM;
            // Validate the model using FluentValidation
            var validator = new ProductVMalidator(_mediator);
            var validationResult = await validator.ValidateAsync(productVM);

            if (!validationResult.IsValid)
            {
                // If validation fails, return the view with error messages
                foreach (var failure in validationResult.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }

                return View(); // Return the productVM with validation errors
            }
            var imageUrls = new List<string>();

            if (productVM.Images != null && productVM.Images.Any())
            {
                foreach (var image in productVM.Images)
                {
                    if (image.Length > 0)
                    {
                        var imageUrl = await FileExtensions.ConvertFileToStringAsync(image, webHostEnvironment);
                        if (!string.IsNullOrEmpty(imageUrl))
                        {
                            imageUrls.Add(imageUrl);
                        }
                    }
                }
            }

            var productCommand = _mapper.Map<AddProductCommand>(productVM);
            productCommand.ImageUrls = imageUrls;
            productCommand.IsMagneticLid = productVM.IsMagneticLid;

            var result = await _mediator.Send(productCommand);
            return RedirectToAction("Products", "Admin");
        }
        [HttpPost]
        public async Task<JsonResult> DeleteProduct(int id, string imgurls)
        {
            try
            {
                var ImgUrls = new List<string>();

                if (!string.IsNullOrEmpty(imgurls))
                {
                    ImgUrls = imgurls.Split(',').ToList();
                }
                var command = new DeleteProductCommand { Id = id };
                await _mediator.Send(command);
                foreach (var img in ImgUrls)
                {
                    FileExtensions.DeleteFileFromFileFolder(img, webHostEnvironment);
                }
                // Return success message
                return Json(new { success = true, message = "Product deleted successfully!" });
            }
            catch (NotFoundException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while deleting the Product." });
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateColorSoldOutStatus(int id, bool isSoldOut)
        {
            try
            {
                var updateColorSoldOutStatusDto = new SoldOutColorCommand
                {
                    Id = id,
                    IsSoldOut = isSoldOut
                };

                var updatedColorId = await _mediator.Send(updateColorSoldOutStatusDto);
                return Ok(new { Message = "Color status updated successfully", ColorId = updatedColorId });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An unexpected error occurred", Details = ex.Message });
            }
        }
        public async Task<IActionResult> Colors()
        {
            // Return the view for displaying colors.
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAllColors()
        {
            var draw = int.Parse(Request.Form["draw"].FirstOrDefault() ?? "0");
            var start = int.Parse(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = int.Parse(Request.Form["length"].FirstOrDefault() ?? "0");
            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];
            var searchValue = Request.Form["search[value]"];

            // Fetch paginated data using Mediator
            var (productColors, totalRecords) = await _mediator.Send(new PaginatedProductColorQuery
            {
                Start = start,
                Length = length,
                SearchValue = searchValue,
                SortColumn = sortColumn,
                SortDirection = sortColumnDirection
            });

            // Prepare JSON response for DataTable
            var jsonData = new
            {
                draw,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
                data = productColors
            };

            return Ok(jsonData);
        }

        public IActionResult AddColor()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddColor(ColorVM colorVM)
        {
            try
            {
                colorVM.IsSoldOut = false;
                // Step 1: Validate the ViewModel using FluentValidation
                var validator = new ColorVMValidator();
                var validationResult = await validator.ValidateAsync(colorVM);

                if (!validationResult.IsValid)
                {
                    // If validation fails, return with errors
                    foreach (var error in validationResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.ErrorMessage);
                    }
                    return View(colorVM); // Return the view with validation errors
                }

                // Step 2: Convert file to base64 string
                colorVM.ImageURL = await FileExtensions.ConvertFileToStringAsync(colorVM.FormFile, webHostEnvironment);

                // Step 3: Map the ViewModel to Command
                var addColorCommand = _mapper.Map<AddColorCommand>(colorVM);

                // Step 4: Use MediatR to validate and handle the command
                var colorId = await _mediator.Send(addColorCommand);

                TempData["SuccessMessage"] = "Color added successfully!";
                return RedirectToAction("Colors", "Admin");
            }
            catch (BadRequestException ex)
            {
                // Handle validation errors from MediatR
                foreach (var errorMessage in ex.ErrorMessages)
                {
                    ModelState.AddModelError(string.Empty, errorMessage);
                }
                FileExtensions.DeleteFileFromFileFolder(colorVM.ImageURL, webHostEnvironment);
                return View(colorVM); // Return with validation errors
            }
            catch (Exception ex)
            {
                // Handle unexpected errors
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again later.");
                return View(colorVM); // Return with general error message
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateColor([FromForm] UpdateColorCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                return Json(new { success = true, message = "Color updated successfully." });
            }
            catch (BadRequestException ex)
            {
                return Json(new { success = false, message = ex.ErrorMessages });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred. Please try again later." });
            }
        }


        [HttpPost]
        public async Task<JsonResult> DeleteColor(int id, string? imgUrl)
        {
            try
            {
                var command = new DeleteColorCommand { Id = id };
                await _mediator.Send(command); // Use MediatR to handle the command
                if (!string.IsNullOrEmpty(imgUrl))
                {
                    FileExtensions.DeleteFileFromFileFolder(imgUrl, webHostEnvironment);
                }
                return Json(new { success = true, message = "Message deleted successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while deleting the message." });
            }
        }

        public async Task<IActionResult> Sizes()
        {
            // Return the view for displaying colors.
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAllSizes()
        {
            var draw = int.Parse(Request.Form["draw"].FirstOrDefault() ?? "0");
            var start = int.Parse(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = int.Parse(Request.Form["length"].FirstOrDefault() ?? "0");
            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];
            var searchValue = Request.Form["search[value]"];

            // Fetch paginated data using Mediator
            var (productSizes, totalRecords) = await _mediator.Send(new PaginatedProductSizeQuery
            {
                Start = start,
                Length = length,
                SearchValue = searchValue,
                SortColumn = sortColumn,
                SortDirection = sortColumnDirection
            });

            // Prepare JSON response for DataTable
            var jsonData = new
            {
                draw,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
                data = productSizes
            };

            return Ok(jsonData);
        }
        [HttpPost]
        public async Task<JsonResult> DeleteSize(int id)
        {
            try
            {
                var command = new DeleteSizeCommand { Id = id };
                await _mediator.Send(command); // Use MediatR to handle the command
                return Json(new { success = true, message = "Message deleted successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while deleting the message." });
            }
        }

        public IActionResult AddSize()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSize(SizeVM sizeVM)
        {
            try
            {
                // Validate the SizeVM using the validator
                var validator = new SizeVMValidator();
                var validationResult = await validator.ValidateAsync(sizeVM);

                if (!validationResult.IsValid)
                {
                    // Clear any existing model errors before adding new ones
                    ModelState.Clear();

                    // Add validation errors to ModelState for specific properties
                    foreach (var error in validationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }

                    // Return the view with validation errors
                    return View(sizeVM);
                }

                var addSizeCommand = _mapper.Map<AddSizeCommand>(sizeVM);

                var sizeId = await _mediator.Send(addSizeCommand);

                TempData["SuccessMessage"] = "Size added successfully!";

                return RedirectToAction("Sizes", "Admin");
            }
            catch (BadRequestException ex)
            {
                // Assuming the exception contains a list of error messages
                foreach (var errorMessage in ex.ErrorMessages)
                {
                    ModelState.AddModelError(string.Empty, errorMessage);
                }

                return View(sizeVM);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again later.");
                return View(sizeVM);
            }
        }
        public async Task<IActionResult> ProductsCategory()
        {
            // Return the view for displaying colors.
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetProductsCategory()
        {
            var draw = int.Parse(Request.Form["draw"].FirstOrDefault() ?? "0");
            var start = int.Parse(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = int.Parse(Request.Form["length"].FirstOrDefault() ?? "0");
            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];
            var searchValue = Request.Form["search[value]"];

            // Fetch paginated data using Mediator
            var (productCategory, totalRecords) = await _mediator.Send(new PaginatedProductCategoriesQuery
            {
                Start = start,
                Length = length,
                SearchValue = searchValue,
                SortColumn = sortColumn,
                SortDirection = sortColumnDirection
            });

            // Prepare JSON response for DataTable
            var jsonData = new
            {
                draw,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
                data = productCategory
            };

            return Ok(jsonData);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] AddProductCategoryCommad command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Json(new { success = true, message = "Category added successfully", id = result });
            }
            catch (BadRequestException ex)
            {
                return Json(new { success = false, message = ex.ErrorMessages });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var command = new DeleteCategoryCommad { Id = id };
                await _mediator.Send(command);
                return Json(new { success = true, message = "Category deleted successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        public async Task<IActionResult> AdditionalProduct()
        {
            // Return the view for displaying colors.
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetAdditionalProducts()
        {
            var draw = int.Parse(Request.Form["draw"].FirstOrDefault() ?? "0");
            var start = int.Parse(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = int.Parse(Request.Form["length"].FirstOrDefault() ?? "0");
            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];
            var searchValue = Request.Form["search[value]"];

            // Fetch paginated data using Mediator
            var (additionalProduct, totalRecords) = await _mediator.Send(new PaginatedAdditionalQuery
            {
                Start = start,
                Length = length,
                SearchValue = searchValue,
                SortColumn = sortColumn,
                SortDirection = sortColumnDirection
            });

            // Prepare JSON response for DataTable
            var jsonData = new
            {
                draw,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
                data = additionalProduct
            };

            return Ok(jsonData);
        }
        [HttpPost]
        public async Task<IActionResult> AddAdditionalProduct(AddAdditionalCommad command)
        {
            try
            {
                var productId = await _mediator.Send(command);
                return Json(new { success = true, productId = productId });
            }
            catch (BadRequestException ex)
            {
                return Json(new { success = false, message = ex.ErrorMessages });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<JsonResult> DeleteAdditionalProduct(int id, int lookUpId)
        {
            try
            {
                var command = new DeleteAdditionalCommand { Id = id, LookUpId = lookUpId };
                await _mediator.Send(command);

                // Return success message
                return Json(new { success = true, message = "Additional product deleted successfully!" });
            }
            catch (NotFoundException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while deleting the additional product." });
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            // Create the DeleteOrderCommand
            var command = new DeleteOrderCommand { Id = orderId };

            try
            {
                // Send the command to the MediatR handler
                await _mediator.Send(command);

                // Return success response
                return Json(new { success = true });
            }
            catch (NotFoundException ex)
            {
                // Log and return failure response if order is not found
                return Json(new { success = false, message = "Order not found" });
            }
            catch (Exception ex)
            {
                // Log and return failure response for general errors
                return Json(new { success = false, message = "An error occurred while deleting the order" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderStatus(int id, int statusId)
        {
            try
            {
                var updateOrderDto = new UpdateOrderDto { Id = id, StatusId = statusId };
                var updatedOrderId = await _mediator.Send(updateOrderDto);
                return Ok(new { Message = "Order status updated successfully", OrderId = updatedOrderId });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An unexpected error occurred", Details = ex.Message });
            }
        }



        public async Task<IActionResult> Orders()
        {
            var Status = await _mediator.Send(new StatusQuery());
            var StatusVM = _mapper.Map<List<StatusVM>>(Status);
            ViewBag.Status = StatusVM;
            var regions = await _mediator.Send(new RegionQuery());
            var regionsVM = _mapper.Map<List<RegionVM>>(regions);
            ViewBag.Regions = regionsVM;
            var payments = await _mediator.Send(new PaymentQuery());
            var paymentsVM = _mapper.Map<List<deliveryFee>>(payments);
            ViewBag.Payments = paymentsVM;
            var colors = await _mediator.Send(new GetColorQuery());
            var colorsVM = _mapper.Map<List<ColorVM>>(colors);
            ViewBag.Colors = colorsVM;
            var sizes = await _mediator.Send(new SizeQuery());
            var sizesVM = _mapper.Map<List<SizeVM>>(sizes);
            ViewBag.Sizes = sizesVM;
            var products = await _mediator.Send(new ProductQuery());
            var productsVM = _mapper.Map<List<ProductVMHome>>(products);
            ViewBag.Products = productsVM;

            // Return the view for displaying colors.
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetOrders()
        {
            var draw = int.Parse(Request.Form["draw"].FirstOrDefault() ?? "0");
            var start = int.Parse(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = int.Parse(Request.Form["length"].FirstOrDefault() ?? "0");
            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];
            var searchValue = Request.Form["search[value]"];

            // Fetch paginated data using Mediator
            var (Orders, totalRecords) = await _mediator.Send(new PaginatedOrdersQuery
            {
                Start = start,
                Length = length,
                SearchValue = searchValue,

            });

            // Prepare JSON response for DataTable
            var jsonData = new
            {
                draw,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
                data = Orders
            };
            return Ok(jsonData);
        }
        public IActionResult Invoice()
        {
            return View();
        }
        public async Task<IActionResult> GetInvoices()
        {
            var draw = int.Parse(Request.Form["draw"].FirstOrDefault() ?? "0");
            var start = int.Parse(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = int.Parse(Request.Form["length"].FirstOrDefault() ?? "0");
            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];
            var searchValue = Request.Form["search[value]"];

            // Fetch paginated data using Mediator
            var (Invoices, totalRecords) = await _mediator.Send(new PaginatedInvoiceDetails
            {
                Start = start,
                Length = length,
                SearchValue = searchValue,
                SortColumn = sortColumn,
                SortDirection = sortColumnDirection
            });

            // Prepare JSON response for DataTable
            var jsonData = new
            {
                draw,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
                data = Invoices
            };
            return Ok(jsonData);
        }
        // Action to render the Feedback view
        public IActionResult Feedback()
        {
            return View();
        }

        public async Task<IActionResult> GetFeedbacks()
        {
            var draw = int.Parse(Request.Form["draw"].FirstOrDefault() ?? "0");
            var start = int.Parse(Request.Form["start"].FirstOrDefault() ?? "0");
            var length = int.Parse(Request.Form["length"].FirstOrDefault() ?? "0");
            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"].FirstOrDefault(), "][name]")].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            var (feedbacks, totalRecords) = await _mediator.Send(new PaginatedFeedback
            {
                Start = start,
                Length = length,
                SearchValue = searchValue,
                SortColumn = sortColumn,
                SortDirection = sortColumnDirection
            });

            var jsonData = new
            {
                draw,
                recordsTotal = totalRecords,
                recordsFiltered = totalRecords,
                data = feedbacks
            };

            return Ok(jsonData);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var result = await _mediator.Send(new DeleteFeedbackCommand { FeedbackId = id });
            return Json(new { success = result });
        }
        [HttpPut]
        public async Task<IActionResult> UpdateVisibilityFeedback(int id, bool statusId)
        {
            try
            {
                var updateVisibilityFeedback = new VisibilityFeedback { FeedbackId = id, IsShow = statusId };
                var VisibilityFeedbackId = await _mediator.Send(updateVisibilityFeedback);
                return Ok(new { Message = "Visibility Feedback updated successfully", FeedbackId = VisibilityFeedbackId });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An unexpected error occurred", Details = ex.Message });
            }
        }
    }
}
