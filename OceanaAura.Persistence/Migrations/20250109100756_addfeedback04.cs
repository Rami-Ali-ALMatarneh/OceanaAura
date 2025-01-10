using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanaAura.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addfeedback04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShow",
                table: "feedbacks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8203));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8201));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8205));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8206));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8208));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8209));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 100,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8324));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 101,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8326));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 200,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8328));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 300,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8334));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 301,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8335));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 400,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8329));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 401,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8331));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 402,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8332));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 500,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8337));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 501,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8338));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 502,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 503,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8341));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 504,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8343));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 505,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8345));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 506,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8346));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 507,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8348));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 508,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8349));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 509,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8350));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 510,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8352));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 511,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8353));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 512,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8355));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 513,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8356));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 514,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8357));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 515,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8359));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 516,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8360));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 701,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8362));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 702,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8363));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 800,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8364));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 801,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8366));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 802,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8367));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 803,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8368));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 900,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 901,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8371));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 902,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 13, 7, 55, 423, DateTimeKind.Local).AddTicks(8373));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShow",
                table: "feedbacks");

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2378));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2391));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2393));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2396));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2398));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2399));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2400));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2402));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 100,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2500));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 101,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2502));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 200,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2503));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 300,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2509));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 301,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2511));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 400,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2505));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 401,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2506));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 402,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2508));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 500,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2512));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 501,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2513));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 502,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2515));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 503,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2516));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 504,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2517));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 505,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2519));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 506,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 507,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2522));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 508,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2523));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 509,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2524));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 510,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2526));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 511,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2527));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 512,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2528));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 513,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2530));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 514,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2531));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 515,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2532));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 516,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2533));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 701,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2535));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 702,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2536));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 800,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2537));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 801,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2539));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 802,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2540));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 803,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2541));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 900,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2543));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 901,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2544));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 902,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 9, 12, 49, 4, 305, DateTimeKind.Local).AddTicks(2545));
        }
    }
}
