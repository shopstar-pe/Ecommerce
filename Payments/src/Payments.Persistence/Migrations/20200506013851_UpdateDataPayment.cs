using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Persistence.Migrations
{
    public partial class UpdateDataPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 244, DateTimeKind.Utc).AddTicks(3450));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 244, DateTimeKind.Utc).AddTicks(6570));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 246, DateTimeKind.Utc).AddTicks(6050));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 246, DateTimeKind.Utc).AddTicks(8190));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 246, DateTimeKind.Utc).AddTicks(8240));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 246, DateTimeKind.Utc).AddTicks(8240));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 246, DateTimeKind.Utc).AddTicks(8250));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 246, DateTimeKind.Utc).AddTicks(8250));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 246, DateTimeKind.Utc).AddTicks(8250));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 246, DateTimeKind.Utc).AddTicks(8250));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 246, DateTimeKind.Utc).AddTicks(1050));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 246, DateTimeKind.Utc).AddTicks(4380));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 246, DateTimeKind.Utc).AddTicks(4450));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 246, DateTimeKind.Utc).AddTicks(4450));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 246, DateTimeKind.Utc).AddTicks(4460));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 247, DateTimeKind.Utc).AddTicks(3460));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 247, DateTimeKind.Utc).AddTicks(3980));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 247, DateTimeKind.Utc).AddTicks(3990));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 247, DateTimeKind.Utc).AddTicks(3990));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 247, DateTimeKind.Utc).AddTicks(3990));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 247, DateTimeKind.Utc).AddTicks(5340));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 247, DateTimeKind.Utc).AddTicks(7850));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 247, DateTimeKind.Utc).AddTicks(7890));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 247, DateTimeKind.Utc).AddTicks(7900));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 247, DateTimeKind.Utc).AddTicks(7900));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 247, DateTimeKind.Utc).AddTicks(7900));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 247, DateTimeKind.Utc).AddTicks(7900));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 6, 1, 38, 50, 247, DateTimeKind.Utc).AddTicks(7900));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Key", "Label" },
                values: new object[] { new DateTime(2020, 5, 6, 1, 38, 50, 247, DateTimeKind.Utc).AddTicks(7900), "CaptureType", "Capture Type" });

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Key" },
                values: new object[] { new DateTime(2020, 5, 6, 1, 38, 50, 247, DateTimeKind.Utc).AddTicks(7900), "Countable" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 208, DateTimeKind.Utc).AddTicks(6930));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 209, DateTimeKind.Utc).AddTicks(80));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 210, DateTimeKind.Utc).AddTicks(8710));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 211, DateTimeKind.Utc).AddTicks(840));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 211, DateTimeKind.Utc).AddTicks(890));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 211, DateTimeKind.Utc).AddTicks(890));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 211, DateTimeKind.Utc).AddTicks(890));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 211, DateTimeKind.Utc).AddTicks(1010));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 211, DateTimeKind.Utc).AddTicks(1020));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 211, DateTimeKind.Utc).AddTicks(1020));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 210, DateTimeKind.Utc).AddTicks(3600));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 210, DateTimeKind.Utc).AddTicks(7240));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 210, DateTimeKind.Utc).AddTicks(7320));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 210, DateTimeKind.Utc).AddTicks(7320));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 210, DateTimeKind.Utc).AddTicks(7320));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 211, DateTimeKind.Utc).AddTicks(6120));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 211, DateTimeKind.Utc).AddTicks(6610));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 211, DateTimeKind.Utc).AddTicks(6620));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 211, DateTimeKind.Utc).AddTicks(6620));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 211, DateTimeKind.Utc).AddTicks(6620));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 211, DateTimeKind.Utc).AddTicks(7890));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 212, DateTimeKind.Utc).AddTicks(280));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 212, DateTimeKind.Utc).AddTicks(340));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 212, DateTimeKind.Utc).AddTicks(340));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 212, DateTimeKind.Utc).AddTicks(340));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 212, DateTimeKind.Utc).AddTicks(340));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 212, DateTimeKind.Utc).AddTicks(340));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 5, 22, 16, 39, 212, DateTimeKind.Utc).AddTicks(340));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 9,
                columns: new[] { "CreatedOn", "Key", "Label" },
                values: new object[] { new DateTime(2020, 5, 5, 22, 16, 39, 212, DateTimeKind.Utc).AddTicks(350), "Channel", "CaptureType" });

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 10,
                columns: new[] { "CreatedOn", "Key" },
                values: new object[] { new DateTime(2020, 5, 5, 22, 16, 39, 212, DateTimeKind.Utc).AddTicks(350), "Channel" });
        }
    }
}
