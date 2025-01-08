using AutoMapper;
using MediatR;
using OceanaAura.Application.Contracts.Email;
using OceanaAura.Application.Contracts.Logging;
using OceanaAura.Application.Contracts.RenderView;
using OceanaAura.Application.Features.Invoice.Commands.AddInvoice;
using OceanaAura.Application.Features.Order.Commands.CreateOrder;
using OceanaAura.Application.Features.Order.Queries.GetAllOrder;
using OceanaAura.Application.Features.Product.Queries.GetProductDetails;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.ProductsEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanaAura.Application.Contracts
{
    public class CalculateOrder
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public CalculateOrder( IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Features.Invoice.Commands.AddInvoice.InvoiceDetails> InvoiceResult(GetOrdersDto orderDto)
        {
            var PaymentMethod = await _unitOfWork.additionalProductsRepository.GetAllPaymentMethod();
            var Regions = await _unitOfWork.lookUpRepository.GetAllRegions();
            var sizes = await _unitOfWork.productSizeRepository.GetAllProductSizesAsync();
            var colors = await _unitOfWork.productColorRepository.GetALLColors();

            decimal subTotal = orderDto.Carts.Sum(cart => cart.ProductPrice);
            decimal shipping = 0;
            if (orderDto.Region == "Jordan")
            {
                shipping = PaymentMethod.FirstOrDefault()?.PriceJOR ?? 0; // Null safety
            }
            if (orderDto.Region == "United Arab Emirates")
            {
                shipping = PaymentMethod.FirstOrDefault()?.PriceUAE ?? 0; // Null safety
            }
            decimal totalPrice = subTotal + shipping;
            var deliveryRegion = Regions.Find(x => x.LookUpId == orderDto.RegionId)?.NameEn ?? "Unknown Region"; // Null safety

            // Fetch product details for all cart items
            var productRepository = _unitOfWork.GenericRepository<Product>();
            var productDetailsTasks = orderDto.Carts
                .Select(async cart => new
                {
                    Cart = cart,
                    Product = await productRepository.GetByIdAsync(cart.ProductId) // Fetch product details
                })
                .ToList();

            // Wait for all product details to be fetched
            var productDetailsResults = await Task.WhenAll(productDetailsTasks);

            // Determine the currency symbol based on the region
            string currencySymbol = orderDto.Region == "Jordan" ? "JOD" : "AED";

            // Create and return InvoiceDetails object
            return new Features.Invoice.Commands.AddInvoice.InvoiceDetails
            {
                OrderId = orderDto.Id,
                Email = orderDto.Email,
                PhoneNumber = orderDto.PhoneNumber,
                FirstName = orderDto.FirstName,
                LastName = orderDto.LastName,
                Address = orderDto.Address,
                City = orderDto.City,
                PostalCode = orderDto.PostalCode,
                Apartment = orderDto.Apartment,
                Region = orderDto.Region,
                RegionId = orderDto.RegionId,
                DeliveryRegion = deliveryRegion,
                Carts = productDetailsResults.Select(result => new CartDto
                {
                    CartId = result.Cart.CartId,
                    OrderId = result.Cart.OrderId,
                    ProductId = result.Cart.ProductId,
                    PaymentId = result.Cart.PaymentId,
                    Quantity = result.Cart.Quantity,
                    SizeId = result.Cart.SizeId,
                    ColorId = result.Cart.ColorId,
                    ProductName = result.Product?.Name ?? "Unknown Product", // Null safety
                    SizeName = sizes.FirstOrDefault(size => size.Id == result.Cart.SizeId)?.Size?.NameEn ?? "Unknown Size", // Null safety
                    ColorName = colors.FirstOrDefault(color => color.LookUpId == result.Cart.ColorId)?.NameEn ?? "Unknown Color", // Null safety
                    ProductPrice = result.Cart.ProductPrice,
                    ProductPriceString = $"{currencySymbol} {result.Cart.ProductPrice.ToString("N2")}", // Format with currency symbol
                    Shipping = result.Cart.Shipping,
                    ShippingString = $"{currencySymbol} {result.Cart.Shipping.ToString("N2")}", // Format with currency symbol
                    TotalPrice = result.Cart.TotalPrice,
                    TotalPriceString = $"{currencySymbol} {result.Cart.TotalPrice.ToString("N2")}" // Format with currency symbol
                }).ToList(),
                SubTotal = subTotal,
                SubTotalString = $"{currencySymbol} {subTotal.ToString("N2")}", // Format with currency symbol
                Shipping = shipping,
                ShippingString = $"{currencySymbol} {shipping.ToString("N2")}", // Format with currency symbol
                TotalPrice = totalPrice,
                TotalPriceString = $"{currencySymbol} {totalPrice.ToString("N2")}" // Format with currency symbol
            };
        }
    }
}