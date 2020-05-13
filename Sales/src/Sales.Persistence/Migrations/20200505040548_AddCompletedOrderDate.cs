using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sales.Persistence.Migrations
{
    public partial class AddCompletedOrderDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedOrderDate",
                schema: "Sales",
                table: "SaleOrder",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Sales",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 4, 5, 48, 96, DateTimeKind.Utc).AddTicks(1190));

            migrationBuilder.UpdateData(
                schema: "Sales",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 4, 5, 48, 96, DateTimeKind.Utc).AddTicks(6840));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedOrderDate",
                schema: "Sales",
                table: "SaleOrder");

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
    }
}
