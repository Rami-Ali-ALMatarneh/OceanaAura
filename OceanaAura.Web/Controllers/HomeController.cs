using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OceanaAura.Application.Features.ContactUs.Commands.AddContactUs;
using OceanaAura.Web.Models;
using OceanaAura.Web.Models.Home;
using System.Diagnostics;

namespace OceanaAura.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public HomeController(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
            [HttpPost]
            public async Task<IActionResult> ContactUs(ContactUsVM contactUsVM)
            {
                if (ModelState.IsValid)
                {
                    try
                    {

                    var ContactUsDto = _mapper.Map<AddContactUsCommand>(contactUsVM);
                        var result = await _mediator.Send(ContactUsDto);

                        TempData["SuccessMessage"] = "Your message has been sent successfully!";
                        return RedirectToAction("ContactUs","Home");
                    }
                    catch (Exception ex)
                    {
                        TempData["ErrorMessage"] = "There was an error processing your request. Please try again.";
                        return View(contactUsVM);
                    }
                }
                return View(contactUsVM);
            }
        }
}
