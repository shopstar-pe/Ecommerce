using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Migrations
{
    public partial class AddMealVariantName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VariantName",
                schema: "Catalog",
                table: "Sku",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VariantName",
                schema: "Catalog",
                table: "Sku");

            migrationBuilder.UpdateData(
                schema: "Catalog",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 8, 0, 1, 20, 415, DateTimeKind.Utc).AddTicks(540));

            migrationBuilder.UpdateData(
                schema: "Catalog",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 8, 0, 1, 20, 415, DateTimeKind.Utc).AddTicks(4190));
        }
    }
}
