namespace OceanaAura.Web.Models.BuyVM
{
    public class OrderDetails
    {
       public  int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int Quantity { get; set; }
        public int LidId { get; set; }
        public bool IsCustomize { get; set; } = false;
        public string? Text { get; set; }
        public string? FontFamily { get; set; }

    }
}
