using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Persistence.Migrations
{
    public partial class AddPaymentMethodTenantTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenantId",
                schema: "Payments",
                table: "PaymentMethodTenant",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 117, DateTimeKind.Utc).AddTicks(1910));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 117, DateTimeKind.Utc).AddTicks(4930));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 119, DateTimeKind.Utc).AddTicks(2330));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 119, DateTimeKind.Utc).AddTicks(4840));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 119, DateTimeKind.Utc).AddTicks(4890));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 119, DateTimeKind.Utc).AddTicks(4890));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 119, DateTimeKind.Utc).AddTicks(4890));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 119, DateTimeKind.Utc).AddTicks(4890));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 119, DateTimeKind.Utc).AddTicks(4890));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 119, DateTimeKind.Utc).AddTicks(4890));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 118, DateTimeKind.Utc).AddTicks(7790));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 119, DateTimeKind.Utc).AddTicks(900));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 119, DateTimeKind.Utc).AddTicks(970));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 119, DateTimeKind.Utc).AddTicks(970));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 119, DateTimeKind.Utc).AddTicks(970));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 120, DateTimeKind.Utc).AddTicks(10));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 120, DateTimeKind.Utc).AddTicks(480));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 120, DateTimeKind.Utc).AddTicks(490));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 120, DateTimeKind.Utc).AddTicks(500));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 120, DateTimeKind.Utc).AddTicks(1820));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 120, DateTimeKind.Utc).AddTicks(4540));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 120, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 120, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 120, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 120, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 23, 55, 37, 120, DateTimeKind.Utc).AddTicks(4700));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                schema: "Payments",
                table: "PaymentMethodTenant");

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 954, DateTimeKind.Utc).AddTicks(2550));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 954, DateTimeKind.Utc).AddTicks(5810));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 956, DateTimeKind.Utc).AddTicks(2890));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 956, DateTimeKind.Utc).AddTicks(5130));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 956, DateTimeKind.Utc).AddTicks(5180));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 956, DateTimeKind.Utc).AddTicks(5180));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 956, DateTimeKind.Utc).AddTicks(5180));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 956, DateTimeKind.Utc).AddTicks(5190));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 956, DateTimeKind.Utc).AddTicks(5190));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 956, DateTimeKind.Utc).AddTicks(5190));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 955, DateTimeKind.Utc).AddTicks(8410));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 956, DateTimeKind.Utc).AddTicks(1480));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 956, DateTimeKind.Utc).AddTicks(1550));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 956, DateTimeKind.Utc).AddTicks(1550));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 956, DateTimeKind.Utc).AddTicks(1550));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 957, DateTimeKind.Utc).AddTicks(660));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 957, DateTimeKind.Utc).AddTicks(1510));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 957, DateTimeKind.Utc).AddTicks(1520));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 957, DateTimeKind.Utc).AddTicks(1520));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 957, DateTimeKind.Utc).AddTicks(3050));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 957, DateTimeKind.Utc).AddTicks(5640));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 957, DateTimeKind.Utc).AddTicks(5710));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 957, DateTimeKind.Utc).AddTicks(5710));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 957, DateTimeKind.Utc).AddTicks(5710));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 957, DateTimeKind.Utc).AddTicks(5710));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 22, 25, 39, 957, DateTimeKind.Utc).AddTicks(5710));
        }
    }
}
