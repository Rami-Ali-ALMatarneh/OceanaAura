﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Features.Order.Queries.GetAllOrder
{
    public class CartDto
    {
        public int OrderId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int PaymentId { get; set; }

        //  منتج البيع القالب 
        public int Quantity { get; set; }
        public int LidId { get; set; }
        public string LidName { get; set; }
        public decimal LidPrice { get; set; }
        public string LidPriceString { get; set; }

        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductPriceString { get; set; }

        public decimal Shipping { get; set; }
        public string ShippingString { get; set; }

        public decimal TotalPrice { get; set; }
        public string TotalPriceString { get; set; }
        public bool IsCustomize { get; set; } = false;
        public string? FontFamily { get; set; }
        public string? Text { get; set; }
        public decimal? CustomizationFees { get; set; }
        public string? CustomizationFeesPriceString { get; set; }
    }
}
