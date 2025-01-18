using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Domain.Enums
{
    public static class LookUpEnums
    {
        // LookUp Category
        public enum CategoryCode
        {
            Region = 1,
            Payment = 2,
            Language = 3,
            PriceCountry = 4,
            ProductColor = 5,
            ProductSize = 6,
            ProductAdditional= 7,
            OrderStatus = 8,
            ProductCategory = 9,
            MagneticLid = 10
        }

        // LookUp 
        public enum RegionCategory
        {
            JOR = 100,
            UAE = 101
        }
        public enum PaymentCategory
        {
            CashOnDelivery = 200
        }
        public enum LanguageCategory
        {
            En = 300,
            Ar =301
        }
        public enum PriceCountryCategory
        {
            JOR = 400,
            UAE = 401,
            USD = 402
        }

        public enum ProductColorCategory
        {
            Black = 500,
            LightPink = 501,
            NavyBlue = 502,
            ArmyGreen = 503,
            BabyBlue = 504,
            Blue = 505,
            Green = 506,
            Purple = 507,
            AquaBlue = 508,
            Pink = 509,
            Orange = 510,
            Yellow = 511,
            Red = 512,
            GradientColor = 513,
            Bambi = 514,
            Nude = 515,
            CobaltBlue = 516
        }
        public enum ProductSizeCategory
        {
            ML355 = 600,
            ML650 = 601,
            ML740 = 602,
            Liter1 = 603,
            Liter1_2 = 604
        }
        public enum ProductAdditionalCategory
        {
            Customization = 701,
            DeliveryFee = 702

        }
        public enum OrderStatusCategory
        {
            Pending = 800,
            InProgress =801,
            Completed = 802,
            Cancelled = 803
        }
        public enum ProductCategory
        {
            Bottle = 900,
            Lids = 901,
            Rubber = 902
        }
    }
}
