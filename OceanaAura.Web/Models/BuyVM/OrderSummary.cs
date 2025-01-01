using OceanaAura.Web.Models.Products;

namespace OceanaAura.Web.Models.BuyVM
{
    public class OrderSummary
    {
        public decimal deliveryFee { get; set; }

        public decimal ProductPrice{ get; set; }
        public int? Discount { get; set; }
        public decimal Total { get; set; }
        public ProductVM Product { get; set; }
        public int Quantity { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
    }
}
