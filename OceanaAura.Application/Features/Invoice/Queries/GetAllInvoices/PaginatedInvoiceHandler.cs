using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OceanaAura.Application.Contracts;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.Order.Queries.GetAllOrder;
using OceanaAura.Application.Features.Product.Queries.GetAllProduct;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Invoice.Queries.GetAllInvoices
{
    public class PaginatedInvoiceHandler : IRequestHandler<PaginatedInvoiceDetails, (List<InvoiceDetailsDto> invoiceDetailsDtos, int TotalRecords)>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<PaginatedInvoiceHandler> _appLogger;
        private readonly CalculateOrder _calculateOrder;

        public PaginatedInvoiceHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<PaginatedInvoiceHandler> appLogger, CalculateOrder calculateOrder)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
            _calculateOrder = calculateOrder;
        }

        public async Task<(List<InvoiceDetailsDto> invoiceDetailsDtos, int TotalRecords)> Handle(PaginatedInvoiceDetails request, CancellationToken cancellationToken)
        {
            var invoiceRepository = _unitOfWork.GenericRepository<Domain.Entities.Invoice>();
            var query = invoiceRepository.Query();

            // Include related entities
            query = query.Include(i => i.Order)
                         .ThenInclude(o => o.carts);

            // Apply search filter
            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                query = query.Where(i =>
                    i.Order.Email.Contains(request.SearchValue) ||
                    i.Order.FirstName.Contains(request.SearchValue) ||
                    i.Order.LastName.Contains(request.SearchValue) ||
                    i.Order.PhoneNumber.Contains(request.SearchValue) ||
                    i.Order.OrderId.ToString().Contains(request.SearchValue) || // Search by OrderId
                    i.InvoiceId.ToString().Contains(request.SearchValue) // Search by InvoiceId
                );
            }

            // Apply date filter if provided
            if (!string.IsNullOrEmpty(request.SearchDate) && DateTime.TryParse(request.SearchDate, out var searchDate))
            {
                query = query.Where(i =>
                    i.CreateOn.Date == searchDate.Date || // Filter by CreatedDate
                    i.Order.OrderId.ToString().Contains(request.SearchDate) || // Filter by OrderId
                    i.InvoiceId.ToString().Contains(request.SearchDate) // Filter by InvoiceId
                );
            }

            // Apply sorting
            if (!string.IsNullOrEmpty(request.SortColumn) && !string.IsNullOrEmpty(request.SortDirection))
            {
                switch (request.SortColumn.ToLower())
                {
                    case "email":
                        query = request.SortDirection.ToLower() == "asc"
                            ? query.OrderBy(i => i.Order.Email)
                            : query.OrderByDescending(i => i.Order.Email);
                        break;
                    case "firstname":
                        query = request.SortDirection.ToLower() == "asc"
                            ? query.OrderBy(i => i.Order.FirstName)
                            : query.OrderByDescending(i => i.Order.FirstName);
                        break;
                    case "lastname":
                        query = request.SortDirection.ToLower() == "asc"
                            ? query.OrderBy(i => i.Order.LastName)
                            : query.OrderByDescending(i => i.Order.LastName);
                        break;
                    case "createon":
                        query = request.SortDirection.ToLower() == "asc"
                            ? query.OrderBy(i => i.CreateOn)
                            : query.OrderByDescending(i => i.CreateOn);
                        break;
                    default:
                        query = query.OrderByDescending(i => i.CreateOn);
                        break;
                }
            }
            else
            {
                query = query.OrderByDescending(i => i.CreateOn);
            }

            // Get total records count
            var totalRecords = await query.CountAsync(cancellationToken);

            // Apply pagination
            var invoices = await query.Skip(request.Start)
                                      .Take(request.Length)
                                      .ToListAsync(cancellationToken);

            // Map invoices to InvoiceDetailsDto
            var invoiceDetailsDtos = new List<InvoiceDetailsDto>();
            foreach (var invoice in invoices)
            {
                var orderDto = new GetOrdersDto
                {
                    Id = invoice.Order.OrderId,
                    Email = invoice.Order.Email,
                    Region = invoice.Order.Region,
                    FirstName = invoice.Order.FirstName,
                    LastName = invoice.Order.LastName,
                    PhoneNumber = invoice.Order.PhoneNumber,
                    RegionId = invoice.Order.RegionId,
                    Address = invoice.Order.Address,
                    City = invoice.Order.City,
                    PostalCode = invoice.Order.PostalCode,
                    Apartment = invoice.Order.Apartment,
                    StatusId = invoice.Order.StatusId,
                    Carts = invoice.Order.carts.Select(cart => new CartDto
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
                        TotalPrice = cart.TotalPrice,
                        LidName = cart.LidName,
                        LidPrice = cart.LidPrice,
                        LidId = (int)cart.LidId,
                        Text = cart.Text,
                        FontFamily = cart.FontFamily,
                        CustomizationFees = cart.CustomizationFees,
                        IsCustomize = cart.IsCustomize
                    }).ToList()
                };

                var invoiceDetails = await _calculateOrder.InvoiceResult(orderDto);
                invoiceDetails.CreateOn = invoice.CreateOn.ToString("dd/MM/yyyy hh:mm tt");
                invoiceDetails.InvoiceId = invoice.InvoiceId;
                var invoiceDetailsDto = _mapper.Map<InvoiceDetailsDto>(invoiceDetails);
                invoiceDetailsDto.TotalLidPriceString = invoiceDetails.TotalLidPriceString;
                invoiceDetailsDto.CustomizationFees = invoiceDetails.TotalCustomization;
                invoiceDetailsDto.CustomizationFeesPriceString = invoiceDetails.TotalCustomizationString;
                invoiceDetailsDtos.Add(invoiceDetailsDto);
            }
            return (invoiceDetailsDtos, totalRecords);
        }
    }
}