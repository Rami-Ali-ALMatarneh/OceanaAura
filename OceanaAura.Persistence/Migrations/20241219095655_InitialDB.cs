using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OceanaAura.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "lookups",
                columns: table => new
                {
                    LookUpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Discount = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
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
                    { 1, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8003), "Region Country", 0, false, null, null, "المنطقة", "Region" },
                    { 2, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8017), "Payment", 0, false, null, null, "طرق الدفع", "Payment" },
                    { 3, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8021), "Language", 0, false, null, null, "لغة", "Language" },
                    { 4, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8019), "PriceCountry", 0, false, null, null, "عملة البلد", "Price Country" },
                    { 5, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8022), "Product Color", 0, false, null, null, "لون المنتج", "Product Color" },
                    { 6, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8023), "Product Size", 0, false, null, null, "حجم المنتج", "Product Size" },
                    { 7, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8025), "Product Additional", 0, false, null, null, "اضافات للمنتج", "Product Additional" },
                    { 8, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8026), "Order Status", 0, false, null, null, "حالات الطلب", "Order Status" },
                    { 9, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8028), "Product Category", 0, false, null, null, "نوع المنتج", "Product Category" }
                });

            migrationBuilder.InsertData(
                table: "lookups",
                columns: new[] { "LookUpId", "CreatedBy", "CreatedOn", "Details", "Id", "IsDeleted", "LookupCategoryId", "ModifyBy", "ModifyOn", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { 100, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8334), null, 0, false, 1, null, null, "الأردن", "Jordan" },
                    { 101, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8336), null, 0, false, 1, null, null, "الإمارات العربية المتحدة", "United Arab Emirates" },
                    { 200, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8338), null, 0, false, 2, null, null, "دفع كاش", "Cash On Delivery" },
                    { 300, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8344), null, 0, false, 3, null, null, "الأنجليزي", "En" },
                    { 301, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8345), null, 0, false, 3, null, null, "العربية", "Ar" },
                    { 400, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8340), null, 0, false, 4, null, null, "الأردن", "JOR" },
                    { 401, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8341), null, 0, false, 4, null, null, "الإمارات العربية المتحدة", "UAE" },
                    { 402, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8342), null, 0, false, 4, null, null, "دولار", "USD" },
                    { 500, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8350), null, 0, false, 5, null, null, "أسود", "Black" },
                    { 501, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8351), null, 0, false, 5, null, null, "وردي فاتح", "Light Pink" },
                    { 502, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8352), null, 0, false, 5, null, null, "أزرق كحلي", "Navy Blue" },
                    { 503, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8406), null, 0, false, 5, null, null, "أخضر عسكري", "Army Green" },
                    { 504, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8407), null, 0, false, 5, null, null, "أزرق فاتح", "Baby Blue" },
                    { 505, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8409), null, 0, false, 5, null, null, "أزرق", "Blue" },
                    { 506, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8410), null, 0, false, 5, null, null, "أخضر", "Green" },
                    { 507, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8411), null, 0, false, 5, null, null, "بنفسجي", "Purple" },
                    { 508, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8413), null, 0, false, 5, null, null, "أزرق سماوي", "Aqua Blue" },
                    { 509, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8414), null, 0, false, 5, null, null, "وردي", "Pink" },
                    { 510, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8416), null, 0, false, 5, null, null, "برتقالي", "Orange" },
                    { 511, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8417), null, 0, false, 5, null, null, "أصفر", "Yellow" },
                    { 512, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8418), null, 0, false, 5, null, null, "أحمر", "Red" },
                    { 513, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8421), null, 0, false, 5, null, null, "لون متدرج", "Gradient Color" },
                    { 514, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8422), null, 0, false, 5, null, null, "بامبي", "Bambi" },
                    { 515, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8423), null, 0, false, 5, null, null, "لون البشرة", "Nude" },
                    { 516, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8425), null, 0, false, 5, null, null, "أزرق كوبالت", "Cobalt Blue" },
                    { 701, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8426), null, 0, false, 7, null, null, "تخصيص", "Customization" },
                    { 702, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8427), null, 0, false, 7, null, null, "رسوم التوصيل", "Delivery Fee" },
                    { 800, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8429), null, 0, false, 8, null, null, "معلق", "Pending" },
                    { 801, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8430), null, 0, false, 8, null, null, "تم التأكيد", "Confirmed" },
                    { 802, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8431), null, 0, false, 8, null, null, "تم الشحن", "Shipped" },
                    { 803, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8433), null, 0, false, 8, null, null, "قيد التوصيل", "Out for Delivery" },
                    { 804, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8434), null, 0, false, 8, null, null, "تم التوصيل", "Delivered" },
                    { 805, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8436), null, 0, false, 8, null, null, "مكتمل", "Completed" },
                    { 806, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8437), null, 0, false, 8, null, null, "ملغى", "Cancelled" },
                    { 900, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8438), null, 0, false, 9, null, null, "مطرة ماء", "Bottle" },
                    { 901, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8440), null, 0, false, 9, null, null, "غطاء", "lid" },
                    { 902, "admin", new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8441), null, 0, false, 9, null, null, "المحاية", "Rubber" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_additionalProducts_LookUpId",
                table: "additionalProducts",
                column: "LookUpId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

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
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "productSizes");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "lookups");

            migrationBuilder.DropTable(
                name: "lookUpCategories");
        }
    }
}
