using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OceanaAura.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddGradientColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "GradientColor",
                table: "products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(6902));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(6915));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(6919));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(6917));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(6922));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(6923));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(6925));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(6926));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 100,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7051));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 101,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7053));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 200,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7055));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 300,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7061));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 301,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7062));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 400,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7057));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 401,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7058));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 402,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7059));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 500,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7064));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 501,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7065));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 502,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 503,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7068));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 504,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7069));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 505,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7071));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 506,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 507,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7074));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 508,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 509,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7077));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 510,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7078));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 511,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7079));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 512,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7081));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 513,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7082));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 514,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7084));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 515,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7085));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 516,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7086));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 701,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7088));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 702,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 800,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 801,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7092));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 802,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7093));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 803,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7095));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 804,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7096));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 805,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7097));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 806,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7099));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 900,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7100));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 901,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7102));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 902,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 28, 17, 21, 55, 82, DateTimeKind.Local).AddTicks(7103));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradientColor",
                table: "products");

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8003));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8017));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8021));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8019));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8022));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8023));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8025));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8026));

            migrationBuilder.UpdateData(
                table: "lookUpCategories",
                keyColumn: "CategoryId",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8028));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 100,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8334));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 101,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8336));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 200,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8338));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 300,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8344));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 301,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8345));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 400,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8340));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 401,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8341));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 402,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8342));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 500,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8350));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 501,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8351));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 502,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8352));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 503,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8406));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 504,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8407));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 505,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8409));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 506,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8410));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 507,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8411));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 508,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8413));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 509,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8414));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 510,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8416));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 511,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8417));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 512,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8418));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 513,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 514,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8422));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 515,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8423));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 516,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8425));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 701,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8426));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 702,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8427));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 800,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8429));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 801,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 802,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8431));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 803,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8433));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 804,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8434));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 805,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8436));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 806,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 900,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8438));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 901,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "lookups",
                keyColumn: "LookUpId",
                keyValue: 902,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 12, 56, 55, 253, DateTimeKind.Local).AddTicks(8441));
        }
    }
}
