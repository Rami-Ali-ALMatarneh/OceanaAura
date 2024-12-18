using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanaAura.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6819));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6832));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6836));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6834));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6838));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6839));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6842));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6843));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 100,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6952));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 101,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6954));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 200,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6956));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 300,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6962));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 301,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6964));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 400,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6957));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 401,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6959));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 402,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6961));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 500,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6965));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 501,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6967));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 502,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6968));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 503,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 504,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6971));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 505,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6973));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 506,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6974));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 507,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6976));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 508,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6977));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 509,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6979));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 510,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6980));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 511,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6981));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 512,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6983));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 513,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6986));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 514,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6988));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 515,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 516,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6991));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 701,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6992));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 702,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6993));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 800,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6995));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 801,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6996));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 802,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 803,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(6999));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 804,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(7000));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 805,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(7001));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 806,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(7003));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 900,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(7004));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 901,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(7059));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 902,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 12, 28, 27, 187, DateTimeKind.Local).AddTicks(7061));
        }
    }
}
