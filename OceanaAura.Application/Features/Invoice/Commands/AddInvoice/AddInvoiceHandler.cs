using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts;
using OceanaAura.Application.Contracts.Email;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Contracts.RenderView;
using OceanaAura.Application.Features.Order.Commands.CreateOrder;
using OceanaAura.Application.Features.Order.Commands.DeleteOrder;
using OceanaAura.Application.Features.Order.Queries.GetAllOrder;
using OceanaAura.Application.Models.Email;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities;
using PuppeteerSharp.Media;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Invoice.Commands.AddInvoice
{
    public class AddInvoiceHandler : IRequestHandler<InvoiceCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<AddInvoiceHandler> _appLogger;
        private readonly IViewRenderService _viewRenderService;
        private readonly CalculateOrder _calculateOrder;
        private readonly IEmailService _emailService;



        public AddInvoiceHandler(CalculateOrder calculateOrder,IEmailService emailService,IViewRenderService viewRenderService,IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<AddInvoiceHandler> appLogger)
        {
            _calculateOrder = calculateOrder;
            _emailService = emailService;
            _viewRenderService = viewRenderService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }


        public async Task<int> Handle(InvoiceCommand request, CancellationToken cancellationToken)
        {
            var OrderRepository = _unitOfWork.GenericRepository<Domain.Entities.Order>();
            var order =await OrderRepository.GetByIdAsync(request.OrderId);
            var ordersDto = new GetOrdersDto
            {
                Id = order.OrderId,
                Email = order.Email,
                Region = order.Region,
                FirstName = order.FirstName,
                LastName = order.LastName,
                PhoneNumber = order.PhoneNumber,
                RegionId = order.RegionId,
                Address = order.Address,
                City = order.City,
                PostalCode = order.PostalCode,
                Apartment = order.Apartment,
                StatusId = order.StatusId,
                Carts = order.carts.Select(cart => new CartDto
                {
                    CartId = cart.CartId,
                    OrderId = cart.OrderId,
                    ProductId = cart.ProductId,
                    PaymentId = cart.PaymentId,
                    Quantity = cart.Quantity,
                    SizeId = cart.SizeId,
                    ColorId = cart.ColorId,
                    ProductPrice = cart.ProductPrice,
                    Shipping = cart.Shipping,
                    TotalPrice = cart.TotalPrice
                }).ToList()
            };
            var Invoice = new OceanaAura.Domain.Entities.Invoice
            {
                OrderId = order.OrderId,
                Order = order
            };
            await _unitOfWork.GenericRepository<OceanaAura.Domain.Entities.Invoice>().AddAsync(Invoice);
            await _unitOfWork.CompleteSaveAppDbAsync();
            var InvoiceDetails = await _calculateOrder.InvoiceResult(ordersDto);
            InvoiceDetails.CreateOn = Invoice.CreateOn.ToString("dd/MM/yyyy hh:mm tt");
            var emailBody = await _viewRenderService.RenderToStringAsync("_OrderEmail", InvoiceDetails);
            // Convert HTML to PDF using PuppeteerSharp
            var pdfBytes = await ConvertHtmlToPdfAsync(emailBody);

            // Create email message
            var emailMessage = new EmailMessage
            {
                To = order.Email,
                Subject = "Request an Invoice",
                Body = emailBody,
                Attachments = new List<EmailAttachment>
        {
            new EmailAttachment
            {
                FileName = $"Invoice_{Invoice.InvoiceId}.pdf",
                ContentType = "application/pdf",
                Content = pdfBytes
            }
        }
            };
            await _emailService.SendEmailAsync(emailMessage);
            return Invoice.InvoiceId;
        }

        private async Task<byte[]> ConvertHtmlToPdfAsync(string htmlContent)
        {
            // Download the Chromium browser if not already installed
            await new BrowserFetcher().DownloadAsync();

            // Launch a headless browser instance
            using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
            using var page = await browser.NewPageAsync();

            // Set the HTML content of the page
            await page.SetContentAsync(htmlContent);

            // Generate PDF from the page
            var pdfBytes = await page.PdfDataAsync(new PdfOptions
            {
                Format = PaperFormat.A4,
                MarginOptions = new MarginOptions
                {
                    Top = "20px",
                    Right = "20px",
                    Bottom = "20px",
                    Left = "20px"
                }
            });

            return pdfBytes;
        }
    }
}
