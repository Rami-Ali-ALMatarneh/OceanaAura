using AutoMapper;
using OceanaAura.Application.Features.Invoice.Commands.AddInvoice;
using OceanaAura.Application.Features.Order.Queries.GetAllOrder;
using OceanaAura.Application.Persistence;
using OceanaAura.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OceanaAura.Application.Contracts
{
    public class CalculateOrder
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CalculateOrder(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<InvoiceDetails> InvoiceResult(GetOrdersDto orderDto)
        {
            var PaymentMethod = await _unitOfWork.additionalProductsRepository.GetAllPaymentMethod();
            var Regions = await _unitOfWork.lookUpRepository.GetAllRegions();
            var sizes = await _unitOfWork.productSizeRepository.GetAllProductSizesAsync();
            var colors = await _unitOfWork.productColorRepository.GetALLColors();

            decimal subTotal = orderDto.Carts.Sum(cart => (cart.ProductPrice * cart.Quantity));
            decimal TotalLidsPrice = orderDto.Carts.Sum(x => x.LidPrice);
            decimal shipping = 0;

            if (orderDto.Region == "Jordan")
            {
                shipping = PaymentMethod.FirstOrDefault()?.PriceJOR ?? 0; // Null safety
            }
            else if (orderDto.Region == "United Arab Emirates")
            {
                shipping = PaymentMethod.FirstOrDefault()?.PriceUAE ?? 0; // Null safety
            }

            decimal totalPrice = subTotal + shipping + TotalLidsPrice;
            var deliveryRegion = Regions.Find(x => x.LookUpId == orderDto.RegionId)?.NameEn ?? "Unknown Region"; // Null safety

            // Determine the currency symbol based on the region
            string currencySymbol = orderDto.Region == "Jordan" ? "JOD" : "AED";

            // Assuming productDetailsResults is a list of objects containing Cart and Product information
            var productDetailsResults = orderDto.Carts.Select(cart => new
            {
                Cart = cart,
                Product = _unitOfWork.productRepository.GetByIdAsync(cart.ProductId).Result // Assuming GetByIdAsync is available
            }).ToList();

            // Create and return InvoiceDetails object
            return new InvoiceDetails
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
                    LidId = result.Cart.LidId,
                    LidPrice =result.Cart.LidPrice,
                    LidName = result.Cart.LidName,
                    LidPriceString = $"{currencySymbol} {result.Cart.LidPrice.ToString("N2")}",
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
                TotalLidPriceString = $"{currencySymbol} {TotalLidsPrice.ToString("N2")}", // Format with currency symbol
                TotalPrice = totalPrice,
                TotalPriceString = $"{currencySymbol} {totalPrice.ToString("N2")}" // Format with currency symbol
            };
        }
    }
}