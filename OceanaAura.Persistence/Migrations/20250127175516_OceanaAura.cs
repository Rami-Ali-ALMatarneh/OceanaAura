using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OceanaAura.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OceanaAura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bottleImgs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgUrlFront = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrlBack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    LidId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bottleImgs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lookUpCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lookUpCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "lookups",
                columns: table => new
                {
                    LookUpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSoldOut = table.Column<bool>(type: "bit", nullable: false),
                    LookupCategoryId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lookups", x => x.LookUpId);
                    table.ForeignKey(
                        name: "FK_lookups_lookUpCategories_LookupCategoryId",
                        column: x => x.LookupCategoryId,
                        principalTable: "lookUpCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    LidId = table.Column<int>(type: "int", nullable: true),
                    LidName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LidPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Shipping = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsCustomize = table.Column<bool>(type: "bit", nullable: false),
                    FontFamily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomizationFees = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_invoices_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "additionalProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LookUpId = table.Column<int>(type: "int", nullable: false),
                    PriceJOR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceUAE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_additionalProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_additionalProducts_lookups_LookUpId",
                        column: x => x.LookUpId,
                        principalTable: "lookups",
                        principalColumn: "LookUpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceJOR = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceUAE = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GradientColor = table.Column<bool>(type: "bit", nullable: false),
                    IsMagneticLid = table.Column<bool>(type: "bit", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsHide = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_lookups_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "lookups",
                        principalColumn: "LookUpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    PriceJOR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceUAE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productSizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productSizes_lookups_SizeId",
                        column: x => x.SizeId,
                        principalTable: "lookups",
                        principalColumn: "LookUpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    IsShow = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbacks", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_feedbacks_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "lookUpCategories",
                columns: new[] { "CategoryId", "CreatedBy", "CreatedOn", "Description", "Id", "IsDeleted", "ModifyBy", "ModifyOn", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { 1, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 725, DateTimeKind.Local).AddTicks(9663), "Region Country", 0, false, null, null, "المنطقة", "Region" },
                    { 2, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 725, DateTimeKind.Local).AddTicks(9668), "Payment", 0, false, null, null, "طرق الدفع", "Payment" },
                    { 3, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 725, DateTimeKind.Local).AddTicks(9677), "Language", 0, false, null, null, "لغة", "Language" },
                    { 4, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 725, DateTimeKind.Local).AddTicks(9673), "PriceCountry", 0, false, null, null, "عملة البلد", "Price Country" },
                    { 5, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 725, DateTimeKind.Local).AddTicks(9682), "Product Color", 0, false, null, null, "لون المنتج", "Product Color" },
                    { 6, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 725, DateTimeKind.Local).AddTicks(9686), "Product Size", 0, false, null, null, "حجم المنتج", "Product Size" },
                    { 7, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 725, DateTimeKind.Local).AddTicks(9690), "Product Additional", 0, false, null, null, "اضافات للمنتج", "Product Additional" },
                    { 8, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 725, DateTimeKind.Local).AddTicks(9694), "Order Status", 0, false, null, null, "حالات الطلب", "Order Status" },
                    { 9, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 725, DateTimeKind.Local).AddTicks(9698), "Product Category", 0, false, null, null, "نوع المنتج", "Product Category" },
                    { 10, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 725, DateTimeKind.Local).AddTicks(9636), "MagneticLid", 0, false, null, null, "غطاء مغناطيسي", "Magnetic Lid" }
                });

            migrationBuilder.InsertData(
                table: "lookups",
                columns: new[] { "LookUpId", "CreatedBy", "CreatedOn", "Details", "Id", "IsDeleted", "IsSoldOut", "LookupCategoryId", "ModifyBy", "ModifyOn", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { 100, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(12), null, 0, false, false, 1, null, null, "الأردن", "Jordan" },
                    { 101, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(19), null, 0, false, false, 1, null, null, "الإمارات العربية المتحدة", "United Arab Emirates" },
                    { 200, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(23), null, 0, false, false, 2, null, null, "دفع كاش", "Cash On Delivery" },
                    { 300, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(227), null, 0, false, false, 3, null, null, "الأنجليزي", "En" },
                    { 301, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(231), null, 0, false, false, 3, null, null, "العربية", "Ar" },
                    { 400, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(28), null, 0, false, false, 4, null, null, "الأردن", "JOR" },
                    { 401, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(218), null, 0, false, false, 4, null, null, "الإمارات العربية المتحدة", "UAE" },
                    { 402, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(223), null, 0, false, false, 4, null, null, "دولار", "USD" },
                    { 500, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(235), null, 0, false, false, 5, null, null, "أسود", "Black" },
                    { 501, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(241), null, 0, false, false, 5, null, null, "وردي فاتح", "Light Pink" },
                    { 502, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(245), null, 0, false, false, 5, null, null, "أزرق كحلي", "Navy Blue" },
                    { 503, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(249), null, 0, false, false, 5, null, null, "أخضر عسكري", "Army Green" },
                    { 504, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(253), null, 0, false, false, 5, null, null, "أزرق فاتح", "Baby Blue" },
                    { 505, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(257), null, 0, false, false, 5, null, null, "أزرق", "Blue" },
                    { 506, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(261), null, 0, false, false, 5, null, null, "أخضر", "Green" },
                    { 507, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(265), null, 0, false, false, 5, null, null, "بنفسجي", "Purple" },
                    { 508, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(270), null, 0, false, false, 5, null, null, "أزرق سماوي", "Aqua Blue" },
                    { 509, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(274), null, 0, false, false, 5, null, null, "وردي", "Pink" },
                    { 510, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(278), null, 0, false, false, 5, null, null, "برتقالي", "Orange" },
                    { 511, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(282), null, 0, false, false, 5, null, null, "أصفر", "Yellow" },
                    { 512, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(286), null, 0, false, false, 5, null, null, "أحمر", "Red" },
                    { 513, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(290), null, 0, false, false, 5, null, null, "لون متدرج", "Gradient Color" },
                    { 514, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(296), null, 0, false, false, 5, null, null, "بامبي", "Bambi" },
                    { 515, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(300), null, 0, false, false, 5, null, null, "لون البشرة", "Nude" },
                    { 516, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(304), null, 0, false, false, 5, null, null, "أزرق كوبالت", "Cobalt Blue" },
                    { 701, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(308), null, 0, false, false, 7, null, null, "تخصيص", "Customization" },
                    { 702, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(312), null, 0, false, false, 2, null, null, "رسوم التوصيل", "Delivery Fee" },
                    { 800, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(316), null, 0, false, false, 8, null, null, "معلق", "Pending" },
                    { 801, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(320), null, 0, false, false, 8, null, null, "قيد العمل", "InProgress" },
                    { 802, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(324), null, 0, false, false, 8, null, null, "مكتمل", "Completed" },
                    { 803, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(328), null, 0, false, false, 8, null, null, "ملغى", "Cancelled" },
                    { 900, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(332), null, 0, false, false, 9, null, null, "مطرة ماء", "Bottle" },
                    { 901, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(336), null, 0, false, false, 9, null, null, "غطاء", "lid" },
                    { 902, "admin", new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(341), null, 0, false, false, 9, null, null, "المحاية", "Rubber" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_additionalProducts_LookUpId",
                table: "additionalProducts",
                column: "LookUpId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_OrderId",
                table: "Carts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_feedbacks_ProductId",
                table: "feedbacks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_OrderId",
                table: "invoices",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_lookups_LookupCategoryId",
                table: "lookups",
                column: "LookupCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_productSizes_SizeId",
                table: "productSizes",
                column: "SizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "additionalProducts");

            migrationBuilder.DropTable(
                name: "bottleImgs");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "feedbacks");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropTable(
                name: "productSizes");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "lookups");

            migrationBuilder.DropTable(
                name: "lookUpCategories");
        }
    }
}
