using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanaAura.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addResources : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ValueAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValueEn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Key);
                });

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8634));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8646));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8650));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8648));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8652));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8653));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8655));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8656));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8658));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 100,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8819));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 101,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 200,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8822));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 300,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8828));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 301,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 400,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8824));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 401,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 402,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8827));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 500,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8831));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 501,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8833));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 502,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8834));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 503,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8836));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 504,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8837));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 505,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8838));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 506,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8841));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 507,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8844));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 508,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8846));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 509,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8849));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 510,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8851));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 511,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8853));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 512,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8855));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 513,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8856));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 514,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8857));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 515,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8859));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 516,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8861));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 701,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8863));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 702,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8864));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 800,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8866));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 801,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8867));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 802,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8869));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 803,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8870));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 900,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 901,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8873));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 902,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 23, 16, 21, 420, DateTimeKind.Local).AddTicks(8874));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resources");

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
    }
}
