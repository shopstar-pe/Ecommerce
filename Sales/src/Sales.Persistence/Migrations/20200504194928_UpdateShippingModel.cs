using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sales.Persistence.Migrations
{
    public partial class UpdateShippingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingCellPhone",
                schema: "Sales",
                table: "SaleOrder");

            migrationBuilder.AddColumn<string>(
                name: "ShippingIdentificationNumber",
                schema: "Sales",
                table: "SaleOrder",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingIdentificationType",
                schema: "Sales",
                table: "SaleOrder",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Sales",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 19, 49, 28, 295, DateTimeKind.Utc).AddTicks(7160));

            migrationBuilder.UpdateData(
                schema: "Sales",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 4, 19, 49, 28, 296, DateTimeKind.Utc).AddTicks(1120));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingIdentificationNumber",
                schema: "Sales",
                table: "SaleOrder");

            migrationBuilder.DropColumn(
                name: "ShippingIdentificationType",
                schema: "Sales",
                table: "SaleOrder");

            migrationBuilder.AddColumn<string>(
                name: "ShippingCellPhone",
                schema: "Sales",
                table: "SaleOrder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Sales",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 18, 44, 13, 456, DateTimeKind.Utc).AddTicks(9360));

            migrationBuilder.UpdateData(
                schema: "Sales",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 18, 44, 13, 457, DateTimeKind.Utc).AddTicks(3010));
        }
    }
}
