using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Migrations
{
    public partial class AddBannerToSeller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Banner",
                schema: "Catalog",
                table: "Seller",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Banner",
                schema: "Catalog",
                table: "Seller");

            migrationBuilder.UpdateData(
                schema: "Catalog",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 21, 15, 41, 976, DateTimeKind.Utc).AddTicks(3340));

            migrationBuilder.UpdateData(
                schema: "Catalog",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 21, 15, 41, 976, DateTimeKind.Utc).AddTicks(6580));
        }
    }
}
