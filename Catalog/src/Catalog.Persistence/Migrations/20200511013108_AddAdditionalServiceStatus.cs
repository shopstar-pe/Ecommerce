using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Migrations
{
    public partial class AddAdditionalServiceStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdditionalServiceStatus",
                schema: "Catalog",
                table: "AdditionalServicePrice",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "Catalog",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 11, 1, 31, 7, 497, DateTimeKind.Utc).AddTicks(7610));

            migrationBuilder.UpdateData(
                schema: "Catalog",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 11, 1, 31, 7, 498, DateTimeKind.Utc).AddTicks(810));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalServiceStatus",
                schema: "Catalog",
                table: "AdditionalServicePrice");

            migrationBuilder.UpdateData(
                schema: "Catalog",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 9, 23, 31, 30, 352, DateTimeKind.Utc).AddTicks(9250));

            migrationBuilder.UpdateData(
                schema: "Catalog",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 9, 23, 31, 30, 353, DateTimeKind.Utc).AddTicks(2880));
        }
    }
}
