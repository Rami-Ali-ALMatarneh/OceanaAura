using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanaAura.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update1DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6073));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6086));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6090));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6093));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6094));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6095));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6097));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 100,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6209));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 101,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6212));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 200,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6213));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 300,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6219));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 301,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6221));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 400,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6215));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 401,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6216));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 402,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6218));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 500,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6222));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 501,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6223));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 502,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6225));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 503,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6226));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 504,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6228));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 505,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6229));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 506,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6230));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 507,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 508,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6233));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 509,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6234));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 510,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6236));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 511,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6237));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 512,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 513,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6240));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 514,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 515,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6243));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 516,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6244));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 701,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6290));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 702,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6291));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 800,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6293));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 801,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6294));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 802,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6296));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 803,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6297));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 804,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6298));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 805,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6300));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 806,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6301));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 900,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6303));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 901,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6304));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 902,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 34, 21, 677, DateTimeKind.Local).AddTicks(6305));

            migrationBuilder.CreateIndex(
                name: "IX_productSizes_SizeId",
                table: "productSizes",
                column: "SizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productSizes");

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(656));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(675));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(679));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(677));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(680));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(682));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(683));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(685));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(686));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 100,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(829));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 101,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(831));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 200,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(833));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 300,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(899));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 301,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(900));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 400,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(895));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 401,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(896));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 402,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(898));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 500,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(903));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 501,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(904));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 502,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(906));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 503,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(907));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 504,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(908));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 505,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(910));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 506,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(911));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 507,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(912));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 508,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(914));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 509,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(915));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 510,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(916));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 511,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(918));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 512,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(919));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 513,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(921));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 514,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(922));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 515,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(924));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 516,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(925));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 701,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(926));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 702,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(927));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 800,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(929));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 801,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(930));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 802,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(931));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 803,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(933));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 804,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(934));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 805,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(935));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 806,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(937));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 900,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(938));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 901,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(939));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 902,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 32, 23, 40, DateTimeKind.Local).AddTicks(941));
        }
    }
}
