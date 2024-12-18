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
                    { 1, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6819), "Region Country", 0, false, null, null, "المنطقة", "Region" },
                    { 2, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6832), "Payment", 0, false, null, null, "طرق الدفع", "Payment" },
                    { 3, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6836), "Language", 0, false, null, null, "لغة", "Language" },
                    { 4, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6834), "PriceCountry", 0, false, null, null, "عملة البلد", "Price Country" },
                    { 5, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6838), "Product Color", 0, false, null, null, "لون المنتج", "Product Color" },
                    { 6, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6839), "Product Size", 0, false, null, null, "حجم المنتج", "Product Size" },
                    { 7, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6840), "Product Additional", 0, false, null, null, "اضافات للمنتج", "Product Additional" },
                    { 8, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6842), "Order Status", 0, false, null, null, "حالات الطلب", "Order Status" },
                    { 9, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6843), "Product Category", 0, false, null, null, "نوع المنتج", "Product Category" }
                });

            migrationBuilder.InsertData(
                table: "lookups",
                columns: new[] { "LookUpId", "CreatedBy", "CreatedOn", "Details", "Id", "IsDeleted", "LookupCategoryId", "ModifyBy", "ModifyOn", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { 100, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6952), null, 0, false, 1, null, null, "الأردن", "Jordan" },
                    { 101, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6954), null, 0, false, 1, null, null, "الإمارات العربية المتحدة", "United Arab Emirates" },
                    { 200, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6956), null, 0, false, 2, null, null, "دفع كاش", "Cash On Delivery" },
                    { 300, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6962), null, 0, false, 3, null, null, "الأنجليزي", "En" },
                    { 301, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6964), null, 0, false, 3, null, null, "العربية", "Ar" },
                    { 400, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6957), null, 0, false, 4, null, null, "الأردن", "JOR" },
                    { 401, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6959), null, 0, false, 4, null, null, "الإمارات العربية المتحدة", "UAE" },
                    { 402, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6961), null, 0, false, 4, null, null, "دولار", "USD" },
                    { 500, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6965), null, 0, false, 5, null, null, "أسود", "Black" },
                    { 501, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6967), null, 0, false, 5, null, null, "وردي فاتح", "Light Pink" },
                    { 502, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6968), null, 0, false, 5, null, null, "أزرق كحلي", "Navy Blue" },
                    { 503, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6970), null, 0, false, 5, null, null, "أخضر عسكري", "Army Green" },
                    { 504, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6971), null, 0, false, 5, null, null, "أزرق فاتح", "Baby Blue" },
                    { 505, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6973), null, 0, false, 5, null, null, "أزرق", "Blue" },
                    { 506, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6974), null, 0, false, 5, null, null, "أخضر", "Green" },
                    { 507, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6976), null, 0, false, 5, null, null, "بنفسجي", "Purple" },
                    { 508, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6977), null, 0, false, 5, null, null, "أزرق سماوي", "Aqua Blue" },
                    { 509, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6979), null, 0, false, 5, null, null, "وردي", "Pink" },
                    { 510, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6980), null, 0, false, 5, null, null, "برتقالي", "Orange" },
                    { 511, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6981), null, 0, false, 5, null, null, "أصفر", "Yellow" },
                    { 512, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6983), null, 0, false, 5, null, null, "أحمر", "Red" },
                    { 513, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6986), null, 0, false, 5, null, null, "لون متدرج", "Gradient Color" },
                    { 514, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6988), null, 0, false, 5, null, null, "بامبي", "Bambi" },
                    { 515, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6989), null, 0, false, 5, null, null, "لون البشرة", "Nude" },
                    { 516, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6991), null, 0, false, 5, null, null, "أزرق كوبالت", "Cobalt Blue" },
                    { 701, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6992), null, 0, false, 7, null, null, "تخصيص", "Customization" },
                    { 702, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6993), null, 0, false, 7, null, null, "رسوم التوصيل", "Delivery Fee" },
                    { 800, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6995), null, 0, false, 8, null, null, "معلق", "Pending" },
                    { 801, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6996), null, 0, false, 8, null, null, "تم التأكيد", "Confirmed" },
                    { 802, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6997), null, 0, false, 8, null, null, "تم الشحن", "Shipped" },
                    { 803, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6999), null, 0, false, 8, null, null, "قيد التوصيل", "Out for Delivery" },
                    { 804, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(7000), null, 0, false, 8, null, null, "تم التوصيل", "Delivered" },
                    { 805, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(7001), null, 0, false, 8, null, null, "مكتمل", "Completed" },
                    { 806, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(7003), null, 0, false, 8, null, null, "ملغى", "Cancelled" },
                    { 900, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(7004), null, 0, false, 9, null, null, "مطرة ماء", "Bottle" },
                    { 901, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(7059), null, 0, false, 9, null, null, "غطاء", "lid" },
                    { 902, "admin", new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(7061), null, 0, false, 9, null, null, "المحاية", "Rubber" }
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
                name: "products");

            migrationBuilder.DropTable(
                name: "lookups");

            migrationBuilder.DropTable(
                name: "lookUpCategories");
        }
    }
}
