using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanaAura.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddImgUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "productSizes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7468));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7471));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7478));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7475));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7481));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7484));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7486));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7489));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7450));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 100,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 101,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7707));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 200,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 300,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 301,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 400,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 401,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7716));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 402,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7719));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 500,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7727));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 501,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7730));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 502,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7733));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 503,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7735));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 504,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7738));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 505,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 506,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7745));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 507,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7747));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 508,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7750));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 509,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7753));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 510,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7756));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 511,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7758));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 512,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7761));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 513,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7764));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 514,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7766));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 515,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7769));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 516,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 701,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7774));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 702,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7777));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 800,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 801,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7782));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 802,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7785));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 803,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7788));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 900,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7791));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 901,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7793));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 902,
                column: "CreatedOn",
                value: new DateTime(2025, 2, 3, 21, 44, 17, 884, DateTimeKind.Local).AddTicks(7796));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "productSizes");

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 725, DateTimeKind.Local).AddTicks(9663));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 725, DateTimeKind.Local).AddTicks(9668));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 725, DateTimeKind.Local).AddTicks(9677));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 725, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 725, DateTimeKind.Local).AddTicks(9682));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 725, DateTimeKind.Local).AddTicks(9686));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 725, DateTimeKind.Local).AddTicks(9690));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 725, DateTimeKind.Local).AddTicks(9694));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 725, DateTimeKind.Local).AddTicks(9698));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 725, DateTimeKind.Local).AddTicks(9636));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 100,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(12));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 101,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(19));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 200,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(23));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 300,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(227));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 301,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(231));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 400,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(28));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 401,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(218));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 402,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(223));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 500,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(235));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 501,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(241));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 502,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(245));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 503,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 504,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(253));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 505,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 506,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(261));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 507,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(265));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 508,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(270));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 509,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(274));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 510,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(278));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 511,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(282));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 512,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(286));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 513,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(290));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 514,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(296));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 515,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(300));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 516,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(304));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 701,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(308));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 702,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(312));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 800,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(316));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 801,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(320));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 802,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(324));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 803,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 900,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(332));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 901,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(336));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 902,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 27, 20, 55, 15, 726, DateTimeKind.Local).AddTicks(341));
        }
    }
}
