using Microsoft.EntityFrameworkCore;
using OceanaAura.Domain.Entities.LookUp;
using OceanaAura.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OceanaAura.Domain.Enums.LookUpEnums;

namespace OceanaAura.Persistence.Configurations
{
    public class SeedLookUp
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<LookUpCategory>().HasData(
                 new LookUpCategory
                 {
                     CategoryId = (int)LookUpEnums.CategoryCode.MagneticLid,
                     NameEn = "Magnetic Lid",
                     NameAr = "غطاء مغناطيسي",
                     Description = "MagneticLid",
                     CreatedBy = "admin",
                     IsDeleted = false,
                     CreatedOn = DateTime.Now,
                     ModifyBy = null,
                     ModifyOn = null,
                 },
                 //LookUpCategory
                 new LookUpCategory
                 {
                     CategoryId = (int)LookUpEnums.CategoryCode.Region,
                     NameEn = "Region",
                     NameAr = "المنطقة",
                     Description = "Region Country",
                     CreatedBy = "admin",
                     IsDeleted = false,
                     CreatedOn = DateTime.Now,
                     ModifyBy = null,
                     ModifyOn = null,
                 },
                 new LookUpCategory
                 {
                     CategoryId = (int)LookUpEnums.CategoryCode.Payment,
                     NameEn = "Payment",
                     NameAr = "طرق الدفع",
                     Description = "Payment",
                     CreatedBy = "admin",
                     IsDeleted = false,
                     CreatedOn = DateTime.Now,
                     ModifyBy = null,
                     ModifyOn = null,
                 },
                 new LookUpCategory
                 {
                     CategoryId = (int)LookUpEnums.CategoryCode.PriceCountry,
                     NameEn = "Price Country",
                     NameAr = "عملة البلد",
                     Description = "PriceCountry",
                     CreatedBy = "admin",
                     IsDeleted = false,
                     CreatedOn = DateTime.Now,
                     ModifyBy = null,
                     ModifyOn = null,
                 },
                 new LookUpCategory
                 {
                     CategoryId = (int)LookUpEnums.CategoryCode.Language,
                     NameEn = "Language",
                     NameAr = "لغة",
                     Description = "Language",
                     CreatedBy = "admin",
                     IsDeleted = false,
                     CreatedOn = DateTime.Now,
                     ModifyBy = null,
                     ModifyOn = null,
                 },
                new LookUpCategory
                {
                    CategoryId = (int)LookUpEnums.CategoryCode.ProductColor,
                    NameEn = "Product Color",
                    NameAr = "لون المنتج",
                    Description = "Product Color",
                    CreatedBy = "admin",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    ModifyOn = null,
                },
                new LookUpCategory
                {
                    CategoryId = (int)LookUpEnums.CategoryCode.ProductSize,
                    NameEn = "Product Size",
                    NameAr = "حجم المنتج",
                    Description = "Product Size",
                    CreatedBy = "admin",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    ModifyOn = null,
                },
                new LookUpCategory
                {
                    CategoryId = (int)LookUpEnums.CategoryCode.ProductAdditional,
                    NameEn = "Product Additional",
                    NameAr = "اضافات للمنتج",
                    Description = "Product Additional",
                    CreatedBy = "admin",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    ModifyOn = null,
                },
                new LookUpCategory
                {
                    CategoryId = (int)LookUpEnums.CategoryCode.OrderStatus,
                    NameEn = "Order Status",
                    NameAr = "حالات الطلب",
                    Description = "Order Status",
                    CreatedBy = "admin",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    ModifyOn = null,
                },
                 new LookUpCategory
                 {
                     CategoryId = (int)LookUpEnums.CategoryCode.ProductCategory,
                     NameEn = "Product Category",
                     NameAr = "نوع المنتج",
                     Description = "Product Category",
                     CreatedBy = "admin",
                     IsDeleted = false,
                     CreatedOn = DateTime.Now,
                     ModifyBy = null,
                     ModifyOn = null,
                 }
                );
            //LookUp
            builder.Entity<LookUpEntity>().HasData(
                ///////////////Region////////////////

                new LookUpEntity
                {
                    LookUpId = (int)LookUpEnums.RegionCategory.JOR,
                    NameEn = "Jordan",
                    NameAr = "الأردن",
                    LookupCategoryId = (int)LookUpEnums.CategoryCode.Region,
                    CreatedBy = "admin",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    ModifyOn = null,
                },
                new LookUpEntity
                {
                    LookUpId = (int)LookUpEnums.RegionCategory.UAE,
                    NameEn = "United Arab Emirates",
                    NameAr = "الإمارات العربية المتحدة",
                    LookupCategoryId = (int)LookUpEnums.CategoryCode.Region,
                    CreatedBy = "admin",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    ModifyOn = null,
                },
                //////// PaymentCategory /////////
                new LookUpEntity
                {
                    LookUpId = (int)LookUpEnums.PaymentCategory.CashOnDelivery,
                    NameEn = "Cash On Delivery",
                    NameAr = "دفع كاش",
                    LookupCategoryId = (int)LookUpEnums.CategoryCode.Payment,
                    CreatedBy = "admin",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    ModifyOn = null,
                },

                ///////////PriceCountry////////////
                new LookUpEntity
                {
                       LookUpId = (int)LookUpEnums.PriceCountryCategory.JOR,
                       NameEn = "JOR",
                       NameAr = "الأردن",
                       LookupCategoryId = (int)LookUpEnums.CategoryCode.PriceCountry,
                       CreatedBy = "admin",
                       IsDeleted = false,
                       CreatedOn = DateTime.Now,
                       ModifyBy = null,
                       ModifyOn = null,
                },
                new LookUpEntity
                {
                    LookUpId = (int)LookUpEnums.PriceCountryCategory.UAE,
                    NameEn = "UAE",
                    NameAr = "الإمارات العربية المتحدة",
                    LookupCategoryId = (int)LookUpEnums.CategoryCode.PriceCountry,
                    CreatedBy = "admin",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    ModifyOn = null,
                },
                new LookUpEntity
                {
                    LookUpId = (int)LookUpEnums.PriceCountryCategory.USD,
                    NameEn = "USD",
                    NameAr = "دولار",
                    LookupCategoryId = (int)LookUpEnums.CategoryCode.PriceCountry,
                    CreatedBy = "admin",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    ModifyOn = null,
                },
                /////////////Language///////////////
                new LookUpEntity
                {
                    LookUpId = (int)LookUpEnums.LanguageCategory.En,
                    NameEn = "En",
                    NameAr = "الأنجليزي",
                    LookupCategoryId = (int)LookUpEnums.CategoryCode.Language,
                    CreatedBy = "admin",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    ModifyOn = null,
                },
                new LookUpEntity
                {
                    LookUpId = (int)LookUpEnums.LanguageCategory.Ar,
                    NameEn = "Ar",
                    NameAr = "العربية",
                    LookupCategoryId = (int)LookUpEnums.CategoryCode.Language,
                    CreatedBy = "admin",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    ModifyOn = null,
                },
               //////////////////ProductColor///////////////////
               new LookUpEntity
               {
                   LookUpId = (int)LookUpEnums.ProductColorCategory.Black,
                   NameEn = "Black",
                   NameAr = "أسود",
                   LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductColor,
                   CreatedBy = "admin",
                   IsDeleted = false,
                   CreatedOn = DateTime.Now,
                   ModifyBy = null,
                   ModifyOn = null,
               },
                   new LookUpEntity
                   {
                       LookUpId = (int)LookUpEnums.ProductColorCategory.LightPink,
                       NameEn = "Light Pink",
                       NameAr = "وردي فاتح",
                       LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductColor,
                       CreatedBy = "admin",
                       IsDeleted = false,
                       CreatedOn = DateTime.Now,
                       ModifyBy = null,
                       ModifyOn = null,
                   },
                   new LookUpEntity
                   {
                       LookUpId = (int)LookUpEnums.ProductColorCategory.NavyBlue,
                       NameEn = "Navy Blue",
                       NameAr = "أزرق كحلي",
                       LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductColor,
                       CreatedBy = "admin",
                       IsDeleted = false,
                       CreatedOn = DateTime.Now,
                       ModifyBy = null,
                       ModifyOn = null,
                   },
                   new LookUpEntity
                   {
                       LookUpId = (int)LookUpEnums.ProductColorCategory.ArmyGreen,
                       NameEn = "Army Green",
                       NameAr = "أخضر عسكري",
                       LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductColor,
                       CreatedBy = "admin",
                       IsDeleted = false,
                       CreatedOn = DateTime.Now,
                       ModifyBy = null,
                       ModifyOn = null,
                   },
                   new LookUpEntity
                   {
                       LookUpId = (int)LookUpEnums.ProductColorCategory.BabyBlue,
                       NameEn = "Baby Blue",
                       NameAr = "أزرق فاتح",
                       LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductColor,
                       CreatedBy = "admin",
                       IsDeleted = false,
                       CreatedOn = DateTime.Now,
                       ModifyBy = null,
                       ModifyOn = null,
                   },
                   new LookUpEntity
                   {
                       LookUpId = (int)LookUpEnums.ProductColorCategory.Blue,
                       NameEn = "Blue",
                       NameAr = "أزرق",
                       LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductColor,
                       CreatedBy = "admin",
                       IsDeleted = false,
                       CreatedOn = DateTime.Now,
                       ModifyBy = null,
                       ModifyOn = null,
                   },
                   new LookUpEntity
                   {
                       LookUpId = (int)LookUpEnums.ProductColorCategory.Green,
                       NameEn = "Green",
                       NameAr = "أخضر",
                       LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductColor,
                       CreatedBy = "admin",
                       IsDeleted = false,
                       CreatedOn = DateTime.Now,
                       ModifyBy = null,
                       ModifyOn = null,
                   },
                   new LookUpEntity
                   {
                       LookUpId = (int)LookUpEnums.ProductColorCategory.Purple,
                       NameEn = "Purple",
                       NameAr = "بنفسجي",
                       LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductColor,
                       CreatedBy = "admin",
                       IsDeleted = false,
                       CreatedOn = DateTime.Now,
                       ModifyBy = null,
                       ModifyOn = null,
                   },
                   new LookUpEntity
                   {
                       LookUpId = (int)LookUpEnums.ProductColorCategory.AquaBlue,
                       NameEn = "Aqua Blue",
                       NameAr = "أزرق سماوي",
                       LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductColor,
                       CreatedBy = "admin",
                       IsDeleted = false,
                       CreatedOn = DateTime.Now,
                       ModifyBy = null,
                       ModifyOn = null,
                   },
                   new LookUpEntity
                   {
                       LookUpId = (int)LookUpEnums.ProductColorCategory.Pink,
                       NameEn = "Pink",
                       NameAr = "وردي",
                       LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductColor,
                       CreatedBy = "admin",
                       IsDeleted = false,
                       CreatedOn = DateTime.Now,
                       ModifyBy = null,
                       ModifyOn = null,
                   },
                   new LookUpEntity
                   {
                       LookUpId = (int)LookUpEnums.ProductColorCategory.Orange,
                       NameEn = "Orange",
                       NameAr = "برتقالي",
                       LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductColor,
                       CreatedBy = "admin",
                       IsDeleted = false,
                       CreatedOn = DateTime.Now,
                       ModifyBy = null,
                       ModifyOn = null,
                   },
                   new LookUpEntity
                   {
                       LookUpId = (int)LookUpEnums.ProductColorCategory.Yellow,
                       NameEn = "Yellow",
                       NameAr = "أصفر",
                       LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductColor,
                       CreatedBy = "admin",
                       IsDeleted = false,
                       CreatedOn = DateTime.Now,
                       ModifyBy = null,
                       ModifyOn = null,
                   },
                   new LookUpEntity
                   {
                       LookUpId = (int)LookUpEnums.ProductColorCategory.Red,
                       NameEn = "Red",
                       NameAr = "أحمر",
                       LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductColor,
                       CreatedBy = "admin",
                       IsDeleted = false,
                       CreatedOn = DateTime.Now,
                       ModifyBy = null,
                       ModifyOn = null,
                   },
                   new LookUpEntity
                   {
                       LookUpId = (int)LookUpEnums.ProductColorCategory.GradientColor,
                       NameEn = "Gradient Color",
                       NameAr = "لون متدرج",
                       LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductColor,
                       CreatedBy = "admin",
                       IsDeleted = false,
                       CreatedOn = DateTime.Now,
                       ModifyBy = null,
                       ModifyOn = null,
                   },
                   new LookUpEntity
                   {
                       LookUpId = (int)LookUpEnums.ProductColorCategory.Bambi,
                       NameEn = "Bambi",
                       NameAr = "بامبي",
                       LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductColor,
                       CreatedBy = "admin",
                       IsDeleted = false,
                       CreatedOn = DateTime.Now,
                       ModifyBy = null,
                       ModifyOn = null,
                   },
                   new LookUpEntity
                   {
                       LookUpId = (int)LookUpEnums.ProductColorCategory.Nude,
                       NameEn = "Nude",
                       NameAr = "لون البشرة",
                       LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductColor,
                       CreatedBy = "admin",
                       IsDeleted = false,
                       CreatedOn = DateTime.Now,
                       ModifyBy = null,
                       ModifyOn = null,
                   },
                   new LookUpEntity
                   {
                       LookUpId = (int)LookUpEnums.ProductColorCategory.CobaltBlue,
                       NameEn = "Cobalt Blue",
                       NameAr = "أزرق كوبالت",
                       LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductColor,
                       CreatedBy = "admin",
                       IsDeleted = false,
                       CreatedOn = DateTime.Now,
                       ModifyBy = null,
                       ModifyOn = null,
                   },

                // ProductAdditionalCategory
                new LookUpEntity
                {
                    LookUpId = (int)LookUpEnums.ProductAdditionalCategory.Customization,
                    NameEn = "Customization",
                    NameAr = "تخصيص",
                    LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductAdditional,
                    CreatedBy = "admin",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    ModifyOn = null,
                },
                new LookUpEntity
                {
                    LookUpId = (int)LookUpEnums.ProductAdditionalCategory.DeliveryFee,
                    NameEn = "Delivery Fee",
                    NameAr = "رسوم التوصيل",
                    LookupCategoryId = (int)LookUpEnums.CategoryCode.Payment,
                    CreatedBy = "admin",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    ModifyOn = null,
                },
                /////////////////Order Status///////////////////
                new LookUpEntity
                {
                    LookUpId = (int)OrderStatusCategory.Pending,
                    NameEn = "Pending",
                    NameAr = "معلق",
                    LookupCategoryId = (int)LookUpEnums.CategoryCode.OrderStatus,
                    CreatedBy = "admin",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    ModifyOn = null,
                },
                    new LookUpEntity
                    {
                        LookUpId = (int)OrderStatusCategory.InProgress,
                        NameEn = "InProgress",
                        NameAr = "قيد العمل",
                        LookupCategoryId = (int)LookUpEnums.CategoryCode.OrderStatus,
                        CreatedBy = "admin",
                        IsDeleted = false,
                        CreatedOn = DateTime.Now,
                        ModifyBy = null,
                        ModifyOn = null,
                    },

                new LookUpEntity
                {
                    LookUpId = (int)OrderStatusCategory.Completed,
                    NameEn = "Completed",
                    NameAr = "مكتمل",
                    LookupCategoryId = (int)LookUpEnums.CategoryCode.OrderStatus,
                    CreatedBy = "admin",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    ModifyOn = null,
                },
                new LookUpEntity
                {
                    LookUpId = (int)OrderStatusCategory.Cancelled,
                    NameEn = "Cancelled",
                    NameAr = "ملغى",
                    LookupCategoryId = (int)LookUpEnums.CategoryCode.OrderStatus,
                    CreatedBy = "admin",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    ModifyOn = null,
                },
                //////////////ProductCategory ////////////////
                new LookUpEntity
                {
                    LookUpId = (int)ProductCategory.Bottle,
                    NameEn = "Bottle",
                    NameAr = "مطرة ماء",
                    LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductCategory,
                    CreatedBy = "admin",
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifyBy = null,
                    ModifyOn = null,
                },
                 new LookUpEntity
                 {
                     LookUpId = (int)ProductCategory.Lids,
                     NameEn = "lid",
                     NameAr = "غطاء",
                     LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductCategory,
                     CreatedBy = "admin",
                     IsDeleted = false,
                     CreatedOn = DateTime.Now,
                     ModifyBy = null,
                     ModifyOn = null,
                 },
                 new LookUpEntity
                 {
                     LookUpId = (int)ProductCategory.Rubber,
                     NameEn = "Rubber",
                     NameAr = "المحاية",
                     LookupCategoryId = (int)LookUpEnums.CategoryCode.ProductCategory,
                     CreatedBy = "admin",
                     IsDeleted = false,
                     CreatedOn = DateTime.Now,
                     ModifyBy = null,
                     ModifyOn = null,
                 }
            );
        }
    }
}
