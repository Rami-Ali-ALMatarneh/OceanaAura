using OceanaAura.Application.Features.Order.Queries.GetOrdersWithStatus;
using OceanaAura.Application.Features.Product.Queries.GetCategoryWithNumberProduct;

namespace OceanaAura.Web.Models.Auth
{
    public class DashboardVM
    {
        public int ProductNumber { get; set; }
        public int OrderNumber {  get; set; }
        public int FeedbackNumber { get; set; }
        public int InvoiceNumber { get; set; }
        public List<GetOrdersWithStatusDto> OrdersWithStatus { get; set; }
        public List<CategoryWithNumberProductDto> CategoryWithNumberProduct { get; set; }


    }
}
