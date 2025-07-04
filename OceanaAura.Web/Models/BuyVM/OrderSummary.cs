﻿using OceanaAura.Web.Models.Products;

namespace OceanaAura.Web.Models.BuyVM
{
    public class OrderSummary
    {
        public int? OrderNumber { get; set; }
        public decimal deliveryFee { get; set; }
        public decimal CustomizationFees { get; set; } = 0;
        public decimal ProductPrice{ get; set; }
        public decimal LidPrice { get; set; }
        public string LidName { get; set; }
        public decimal Total { get; set; }
        public ProductVM Product { get; set; }
        public int Quantity { get; set; }
        public int LidId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int ProductId { get; set; }
        public int PaymentId { get; set; }
        public string? Region { get; set; }
        public bool IsCustomize { get; set; } = false;
        public string? Text { get; set; }
        public string? FontFamily { get; set; }
    }
}
