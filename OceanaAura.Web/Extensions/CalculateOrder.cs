using AutoMapper;
using MediatR;
using OceanaAura.Application.Features.LookUp.Queries.CustomizationFees.Queries.GetCustomizationFees;
using OceanaAura.Application.Features.LookUp.Queries.GetAllPayment;
using OceanaAura.Application.Features.Product.Queries.GetProductDetails;
using OceanaAura.Application.Features.Product.Queries.NormalBuy.GetSize;
using OceanaAura.Application.Features.ProductSize.Queries.GetSizeDetails;
using OceanaAura.Domain.Entities.ProductsEntities;
using OceanaAura.Web.Models.BuyVM;
using OceanaAura.Web.Models.Products;

namespace OceanaAura.Web.Extensions
{
    public class CalculateOrder
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        // Constructor injection for IMediator
        public CalculateOrder(IMediator mediator,IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<OrderSummary> NormalOrderSummaryDetails(OrderDetails orderDetails ,string Region = "Jordan")
        {

            // Ensure that Region is not null or empty; if so, default to "Jordan"
            if (string.IsNullOrEmpty(Region))
            {
                Region = "Jordan";
            }

            var orderSummary = new OrderSummary();
            var product = await _mediator.Send(new ProductDetailsQuery(orderDetails.ProductId));
            var lid = await _mediator.Send(new ProductDetailsQuery(orderDetails.LidId));
            var paymentList = await _mediator.Send(new PaymentQuery());
            var size = await _mediator.Send(new SizeDetailsQuery(orderDetails.SizeId));
            var deliveryFee = paymentList?.FirstOrDefault();
            var CustomizationFees = await _mediator.Send(new CustomizationFeesQuery());

            orderSummary.Region = Region;
           
            if (orderDetails.SizeId > 0)
            {
                if (Region == "Jordan")
                {
                    orderSummary.CustomizationFees = CustomizationFees.PriceJor;
                    if (lid.PriceJOR != null)
                    {
                        orderSummary.LidPrice = lid.PriceJOR.Value;
                    }
                    orderSummary.ProductPrice = size.PriceJor;
                    orderSummary.deliveryFee = deliveryFee.PriceJOR;

                }
                if (Region == "United Arab Emirates")
                {
                    orderSummary.CustomizationFees = CustomizationFees.PriceUae;

                    if (lid.PriceUAE != null)
                    {
                        orderSummary.LidPrice = lid.PriceUAE.Value;
                    }
                    orderSummary.ProductPrice = size.PriceUae;
                    orderSummary.deliveryFee = deliveryFee.PriceUAE;

                }
                orderSummary.LidName = lid.Name;
                orderSummary.Total = (orderSummary.ProductPrice * orderDetails.Quantity)  + orderSummary.deliveryFee + orderSummary.LidPrice ;
                if (orderDetails.IsCustomize)
                {

                    orderSummary.IsCustomize = orderDetails.IsCustomize;
                    orderSummary.Text = orderDetails.Text;
                    orderSummary.FontFamily = orderDetails.FontFamily;
                    orderSummary.Total += orderSummary.CustomizationFees;
                }
            }
            else
            {
                if (Region == "Jordan")
                {
                    orderSummary.CustomizationFees = CustomizationFees.PriceJor;

                    orderSummary.ProductPrice = (decimal)product.PriceJOR;
                    orderSummary.deliveryFee = deliveryFee.PriceJOR;

                }
                if (Region == "United Arab Emirates")
                {
                    orderSummary.CustomizationFees = CustomizationFees.PriceJor;

                    orderSummary.ProductPrice = (decimal)product.PriceUAE;
                    orderSummary.deliveryFee = deliveryFee.PriceUAE;

                }
                orderSummary.Total = (orderSummary.ProductPrice * orderDetails.Quantity) + orderSummary.deliveryFee;
            }
            orderSummary.Product = _mapper.Map<ProductVM>(product);
            orderSummary.SizeId = size.Id;
            orderSummary.Quantity = orderDetails.Quantity;
            orderSummary.ColorId = orderDetails.ColorId;
            orderSummary.LidId = orderDetails.LidId;
            if (orderDetails.IsCustomize)
            {

                orderSummary.IsCustomize = orderDetails.IsCustomize;
                orderSummary.Text = orderDetails.Text;
                orderSummary.FontFamily = orderDetails.FontFamily;
            }
            return orderSummary;
        }
        public async Task<OrderSummary> SubOrderSummaryDetails(SubOrderDetails  subOrderDetails, string Region = "Jordan")
        {

            // Ensure that Region is not null or empty; if so, default to "Jordan"
            if (string.IsNullOrEmpty(Region))
            {
                Region = "Jordan";
            }

            var orderSummary = new OrderSummary();
            var product = await _mediator.Send(new ProductDetailsQuery(subOrderDetails.ProductId));
            var paymentList = await _mediator.Send(new PaymentQuery());
            var deliveryFee = paymentList?.FirstOrDefault();
            orderSummary.Region = Region;

            if (Region == "Jordan")
                {
                    orderSummary.ProductPrice = product.PriceJOR ?? 0;
                orderSummary.deliveryFee = deliveryFee.PriceJOR;

                }
                if (Region == "United Arab Emirates")
                {
                    orderSummary.ProductPrice = product.PriceUAE ?? 0;
                orderSummary.deliveryFee = deliveryFee.PriceUAE;

                }
            orderSummary.Total = ((orderSummary.ProductPrice * subOrderDetails.Quantity) ) + orderSummary.deliveryFee;
            orderSummary.Product = _mapper.Map<ProductVM>(product);
            orderSummary.Quantity = subOrderDetails.Quantity;
            return orderSummary;
        }
    }
}
