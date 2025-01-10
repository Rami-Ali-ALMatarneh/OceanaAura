namespace OceanaAura.Web.Models.BuyVM
{
    public class CartVM
    {
        public int SizeId { get; set; }
        public decimal Shipping { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public int ColorId { get; set; }
        public int PaymentId { get; set; }
        public int ProductId { get; set; }
    }
}
