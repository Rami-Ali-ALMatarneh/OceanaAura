namespace OceanaAura.Web.Models.BuyVM
{
    public class LidsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? PriceJOR { get; set; }
        public decimal? PriceUAE { get; set; }
        public decimal? PriceUSD { get; set; }
        public bool IsMagneticLid { get; set; }
    }
}
