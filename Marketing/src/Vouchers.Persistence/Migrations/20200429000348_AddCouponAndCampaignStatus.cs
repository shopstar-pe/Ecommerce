using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vouchers.Persistence.Migrations
{
    public partial class AddCouponAndCampaignStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CouponStatus",
                schema: "Vouchers",
                table: "Coupon",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CampaignStatus",
                schema: "Vouchers",
                table: "Campaign",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "Vouchers",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 29, 0, 3, 48, 75, DateTimeKind.Utc).AddTicks(90));

            migrationBuilder.UpdateData(
                schema: "Vouchers",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 29, 0, 3, 48, 75, DateTimeKind.Utc).AddTicks(3260));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CouponStatus",
                schema: "Vouchers",
                table: "Coupon");

            migrationBuilder.DropColumn(
                name: "CampaignStatus",
                schema: "Vouchers",
                table: "Campaign");

            migrationBuilder.UpdateData(
                schema: "Vouchers",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 22, 57, 15, 77, DateTimeKind.Utc).AddTicks(1350));

            migrationBuilder.UpdateData(
                schema: "Vouchers",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 22, 57, 15, 77, DateTimeKind.Utc).AddTicks(4630));
        }
    }
}
