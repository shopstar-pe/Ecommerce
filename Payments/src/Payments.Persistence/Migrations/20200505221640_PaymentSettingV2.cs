using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Persistence.Migrations
{
    public partial class PaymentSettingV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine",
                schema: "Payments",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "BrandName",
                schema: "Payments",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "CreditCardNumber",
                schema: "Payments",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "Payments",
                table: "Transaction");

            migrationBuilder.AlterColumn<string>(
                name: "Year",
                schema: "Payments",
                table: "Transaction",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                schema: "Payments",
                table: "Transaction",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                schema: "Payments",
                table: "Transaction",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Month",
                schema: "Payments",
                table: "Transaction",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                schema: "Payments",
                table: "Transaction",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardType",
                schema: "Payments",
                table: "Transaction",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Payments",
                table: "Transaction",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentificationNumber",
                schema: "Payments",
                table: "Transaction",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentificationType",
                schema: "Payments",
                table: "Transaction",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Payments",
                table: "Transaction",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderGroup",
                schema: "Payments",
                table: "Transaction",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionExternalAuthCode",
                schema: "Payments",
                table: "Transaction",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionExternalToken",
                schema: "Payments",
                table: "Transaction",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PaymentCreditCard",
                schema: "Payments",
                table: "Provider",
                nullable: false,
                defaultValue: false);

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
                columns: new[] { "CreatedOn", "PaymentCreditCard" },
                values: new object[] { new DateTime(2020, 5, 5, 22, 16, 39, 211, DateTimeKind.Utc).AddTicks(6120), true });

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 2,
                columns: new[] { "CreatedOn", "PaymentCreditCard" },
                values: new object[] { new DateTime(2020, 5, 5, 22, 16, 39, 211, DateTimeKind.Utc).AddTicks(6610), true });

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 3,
                columns: new[] { "CreatedOn", "PaymentCreditCard" },
                values: new object[] { new DateTime(2020, 5, 5, 22, 16, 39, 211, DateTimeKind.Utc).AddTicks(6620), true });

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 4,
                columns: new[] { "CreatedOn", "PaymentCreditCard" },
                values: new object[] { new DateTime(2020, 5, 5, 22, 16, 39, 211, DateTimeKind.Utc).AddTicks(6620), true });

            migrationBuilder.InsertData(
                schema: "Payments",
                table: "Provider",
                columns: new[] { "ProviderId", "Active", "CountryIsoCode", "CreatedBy", "CreatedOn", "DeletedOn", "Description", "EntityStatus", "Icon", "Image", "Label", "Name", "PaymentCreditCard", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 5, true, "PE", "System", new DateTime(2020, 5, 5, 22, 16, 39, 211, DateTimeKind.Utc).AddTicks(6620), null, "Pago Efectivo", 0, "pagoefectivo", "pagoefectivo", "Pago Efectivo", "PagoEfectivo", false, null, null });

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

            migrationBuilder.InsertData(
                schema: "Payments",
                table: "ProviderSetting",
                columns: new[] { "ProviderSettingId", "CreatedBy", "CreatedOn", "DeletedOn", "EntityStatus", "IsReadOnly", "Key", "Label", "ProviderId", "UpdatedBy", "UpdatedOn", "Value" },
                values: new object[,]
                {
                    { 10, null, new DateTime(2020, 5, 5, 22, 16, 39, 212, DateTimeKind.Utc).AddTicks(350), null, 0, true, "Channel", "Countable", 1, null, null, "False" },
                    { 9, null, new DateTime(2020, 5, 5, 22, 16, 39, 212, DateTimeKind.Utc).AddTicks(350), null, 0, true, "Channel", "CaptureType", 1, null, null, "manual" },
                    { 8, null, new DateTime(2020, 5, 5, 22, 16, 39, 212, DateTimeKind.Utc).AddTicks(340), null, 0, true, "Channel", "Channel", 1, null, null, "web" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "CardNumber",
                schema: "Payments",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "CardType",
                schema: "Payments",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Payments",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "IdentificationNumber",
                schema: "Payments",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "IdentificationType",
                schema: "Payments",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Payments",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "OrderGroup",
                schema: "Payments",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "TransactionExternalAuthCode",
                schema: "Payments",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "TransactionExternalToken",
                schema: "Payments",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "PaymentCreditCard",
                schema: "Payments",
                table: "Provider");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                schema: "Payments",
                table: "Transaction",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SellerId",
                schema: "Payments",
                table: "Transaction",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderId",
                schema: "Payments",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Month",
                schema: "Payments",
                table: "Transaction",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine",
                schema: "Payments",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrandName",
                schema: "Payments",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreditCardNumber",
                schema: "Payments",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "Payments",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 66, DateTimeKind.Utc).AddTicks(9810));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 67, DateTimeKind.Utc).AddTicks(4960));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 70, DateTimeKind.Utc).AddTicks(1460));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 70, DateTimeKind.Utc).AddTicks(3860));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 70, DateTimeKind.Utc).AddTicks(3920));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 70, DateTimeKind.Utc).AddTicks(3920));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 70, DateTimeKind.Utc).AddTicks(3920));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 70, DateTimeKind.Utc).AddTicks(3930));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 70, DateTimeKind.Utc).AddTicks(3930));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 70, DateTimeKind.Utc).AddTicks(3930));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 69, DateTimeKind.Utc).AddTicks(5060));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 69, DateTimeKind.Utc).AddTicks(9530));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 69, DateTimeKind.Utc).AddTicks(9620));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 69, DateTimeKind.Utc).AddTicks(9620));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 69, DateTimeKind.Utc).AddTicks(9620));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 70, DateTimeKind.Utc).AddTicks(9070));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 70, DateTimeKind.Utc).AddTicks(9620));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 70, DateTimeKind.Utc).AddTicks(9640));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 70, DateTimeKind.Utc).AddTicks(9640));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 71, DateTimeKind.Utc).AddTicks(1090));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 71, DateTimeKind.Utc).AddTicks(4510));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 71, DateTimeKind.Utc).AddTicks(4750));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 71, DateTimeKind.Utc).AddTicks(4750));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 71, DateTimeKind.Utc).AddTicks(4750));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 71, DateTimeKind.Utc).AddTicks(4760));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 0, 29, 56, 71, DateTimeKind.Utc).AddTicks(4760));
        }
    }
}
