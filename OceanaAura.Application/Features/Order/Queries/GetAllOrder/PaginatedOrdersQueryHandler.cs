using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Features.Product.Queries.GetAllProduct;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Order.Queries.GetAllOrder
{
    public class PaginatedOrdersQueryHandler : IRequestHandler<PaginatedOrdersQuery, (List<GetOrdersDto> getOrdersDtos, int TotalRecords)>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<PaginatedOrdersQueryHandler> _appLogger;

        public PaginatedOrdersQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IAppLogger<PaginatedOrdersQueryHandler> appLogger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appLogger = appLogger;
        }

        public async Task<(List<GetOrdersDto> getOrdersDtos, int TotalRecords)> Handle(PaginatedOrdersQuery request, CancellationToken cancellationToken)
        {
            var ProductRepository = _unitOfWork.GenericRepository<Domain.Entities.Order>();
            var query = ProductRepository.Query();
            query = query.Include(x => x.carts);
            // Apply search filtering
            if (!string.IsNullOrWhiteSpace(request.SearchValue))
            {
                query = query.Where(p => p.Email.Contains(request.SearchValue) ||
                                         p.PhoneNumber.Contains(request.SearchValue) ||
                                         (p.RegionId.ToString().Contains(request.SearchValue)) ||
                                         (p.carts.Any(x => x.TotalPrice.ToString().Contains(request.SearchValue))));
            }




            // Get total record count (before pagination)
            int totalRecords = await query.CountAsync(cancellationToken);
            // Apply pagination
            query = query.Skip(request.Start).Take(request.Length);
            // Execute the query and project to DTO
            var orders = await query.ToListAsync(cancellationToken);
            // Map to DTOs
            var ordersDto = orders.Select(order => new GetOrdersDto
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
                    LidName = cart.LidName,
                    LidPrice = cart.LidPrice,
                    ProductPrice = cart.ProductPrice,
                    Shipping = cart.Shipping,
                    TotalPrice = cart.TotalPrice,
                    Text = cart.Text,
                    FontFamily = cart.FontFamily,
                    CustomizationFees = cart.CustomizationFees,
                    IsCustomize = cart.IsCustomize
                }).ToList()
            }).ToList();

            return (ordersDto, totalRecords);
        }
    }
}