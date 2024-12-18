using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OceanaAura.Application.Contracts.Identity;
using OceanaAura.Application.Exceptions;
using OceanaAura.Application.Features.ContactUs.Commands.DeleteContactUs;
using OceanaAura.Application.Features.ContactUs.Queries.GetAllContactUs;
using OceanaAura.Application.Features.ContactUs.Queries.GetContactUsWithDetails;
using OceanaAura.Application.Features.LidProduct.Command.AddLid;
using OceanaAura.Application.Features.LookUp.Commands.AddCagegory;
using OceanaAura.Application.Features.LookUp.Commands.Additional;
using OceanaAura.Application.Features.LookUp.Commands.DeleteAdditional;
using OceanaAura.Application.Features.LookUp.Commands.DeleteCategory;
using OceanaAura.Application.Features.LookUp.Queries.GetAllAdditinalProduct;
using OceanaAura.Application.Features.LookUp.Queries.GetAllProductCategories;
using OceanaAura.Application.Features.LookUp.Queries.GetProductCategories;
using OceanaAura.Application.Features.Product.Command.AddProduct;
using OceanaAura.Application.Features.ProductColor.Commands.AddColor;
using OceanaAura.Application.Features.ProductColor.Commands.DeleteColor;
using OceanaAura.Application.Features.ProductColor.Commands.UpdateColor;
using OceanaAura.Application.Features.ProductColor.Queries.GetAllProductColors;
using OceanaAura.Application.Features.ProductSize.Command.AddSize;
using OceanaAura.Application.Features.ProductSize.Command.DeleteSize;
using OceanaAura.Application.Features.ProductSize.Queries.GetAllSize;
using OceanaAura.Application.Models.Identity.Password;
using OceanaAura.Application.Models.Identity.UserInfo;
using OceanaAura.Web.Extensions;
using OceanaAura.Web.Models.Auth;
using OceanaAura.Web.Models.Colors;
using OceanaAura.Web.Models.Lookup;
using OceanaAura.Web.Models.Products;
using OceanaAura.Web.Models.Size;
using System.Drawing;

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
        public IActionResult Dashboard()
        {
            return View();
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
        public async Task<IActionResult> AddProduct()
        {
            var categories = await _mediator.Send(new CategoriesQuery());
            var CategoriesVM = _mapper.Map<List<CategoryVM>>(categories);
            ViewBag.Categories = CategoriesVM;
            return View();
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

            var productCommand = _mapper.Map<AddProductCommand>(productVM);
            productCommand.ImageUrls = imageUrls;
            var result = await _mediator.Send(productCommand);

            if (result > 0)
            {
                return Json(new { success = true, message = "Product added successfully." });
            }
            else
            {
                return Json(new { success = false, message = "Failed to add product." });
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

    }
}
