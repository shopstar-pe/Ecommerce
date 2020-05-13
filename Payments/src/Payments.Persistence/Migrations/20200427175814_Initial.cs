using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Payments");

            migrationBuilder.CreateTable(
                name: "AppSetting",
                schema: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    Group = table.Column<string>(maxLength: 40, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Value = table.Column<string>(maxLength: 500, nullable: false),
                    IsReadOnly = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethodGroup",
                schema: "Payments",
                columns: table => new
                {
                    PaymentMethodGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CountryIsoCode = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethodGroup", x => x.PaymentMethodGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                schema: "Payments",
                columns: table => new
                {
                    ProviderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    CountryIsoCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.ProviderId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                schema: "Payments",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    CountryIsoCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false),
                    IconLink = table.Column<string>(nullable: true),
                    PaymentMethodGroupId = table.Column<int>(nullable: false),
                    ValidatorCardCodeMask = table.Column<string>(nullable: true),
                    ValidatorCardCodeRegex = table.Column<string>(nullable: true),
                    ValidatorCardMask = table.Column<string>(nullable: true),
                    ValidatorCardRegex = table.Column<string>(nullable: true),
                    ValidatorCardUseCvv = table.Column<bool>(nullable: false),
                    ValidatorCardUseExpirationDate = table.Column<bool>(nullable: false),
                    ValidatorCardUseBillingAddress = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.PaymentMethodId);
                    table.ForeignKey(
                        name: "FK_PaymentMethod_PaymentMethodGroup_PaymentMethodGroupId",
                        column: x => x.PaymentMethodGroupId,
                        principalSchema: "Payments",
                        principalTable: "PaymentMethodGroup",
                        principalColumn: "PaymentMethodGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProviderSetting",
                schema: "Payments",
                columns: table => new
                {
                    ProviderSettingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    Label = table.Column<string>(nullable: true),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IsReadOnly = table.Column<bool>(nullable: false),
                    ProviderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderSetting", x => x.ProviderSettingId);
                    table.ForeignKey(
                        name: "FK_ProviderSetting_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalSchema: "Payments",
                        principalTable: "Provider",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                schema: "Payments",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    OrderId = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    TransactionExternalId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    AddressLine = table.Column<string>(nullable: true),
                    CurrencyIsoCode = table.Column<string>(nullable: true),
                    CountryIsoCode = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TransactionStatusType = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    SellerId = table.Column<int>(nullable: false),
                    SellerName = table.Column<string>(nullable: true),
                    PlaceHolder = table.Column<string>(nullable: true),
                    CreditCardNumber = table.Column<string>(nullable: true),
                    Month = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Cvv = table.Column<string>(nullable: true),
                    BrandName = table.Column<string>(nullable: true),
                    ProviderId = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transaction_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalSchema: "Payments",
                        principalTable: "Provider",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Payments",
                table: "AppSetting",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedOn", "EntityStatus", "Group", "IsReadOnly", "Name", "UpdatedBy", "UpdatedOn", "Value" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 4, 27, 17, 58, 13, 484, DateTimeKind.Utc).AddTicks(6130), null, 0, "Application", true, "Version", null, null, "v1" },
                    { 2, null, new DateTime(2020, 4, 27, 17, 58, 13, 484, DateTimeKind.Utc).AddTicks(9550), null, 0, "Application", true, "Owner", null, null, "admin" }
                });

            migrationBuilder.InsertData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                columns: new[] { "PaymentMethodGroupId", "Active", "CountryIsoCode", "CreatedBy", "CreatedOn", "DeletedOn", "Description", "EntityStatus", "Label", "Name", "Order", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, true, "PE", null, new DateTime(2020, 4, 27, 17, 58, 13, 486, DateTimeKind.Utc).AddTicks(3430), null, "Tarjeta de Credito", 0, "Tarjeta de Credito", "CreditCard", 0, null, null },
                    { 2, true, "PE", null, new DateTime(2020, 4, 27, 17, 58, 13, 486, DateTimeKind.Utc).AddTicks(6760), null, "Pago en banco", 0, "Pago en banco", "CashOnBank", 1, null, null },
                    { 3, true, "PE", null, new DateTime(2020, 4, 27, 17, 58, 13, 486, DateTimeKind.Utc).AddTicks(6830), null, "Pago contra entrega", 0, "Pago contra entrega", "CashOnDelivery", 2, null, null },
                    { 4, true, "PE", null, new DateTime(2020, 4, 27, 17, 58, 13, 486, DateTimeKind.Utc).AddTicks(6830), null, "Deposito en Banco", 0, "Deposito en Banco", "BankDeposit", 3, null, null },
                    { 5, true, "PE", null, new DateTime(2020, 4, 27, 17, 58, 13, 486, DateTimeKind.Utc).AddTicks(6830), null, "Confirmación Manual", 0, "Confirmación Manual", "Manual", 4, null, null }
                });

            migrationBuilder.InsertData(
                schema: "Payments",
                table: "Provider",
                columns: new[] { "ProviderId", "Active", "CountryIsoCode", "CreatedBy", "CreatedOn", "DeletedOn", "Description", "EntityStatus", "Icon", "Image", "Label", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, true, "PE", "System", new DateTime(2020, 4, 27, 17, 58, 13, 487, DateTimeKind.Utc).AddTicks(4800), null, "VisaNet", 0, "visanet", "visanet", "Visa Net", "VisaNet", null, null },
                    { 2, false, "PE", "System", new DateTime(2020, 4, 27, 17, 58, 13, 487, DateTimeKind.Utc).AddTicks(5300), null, "PayU", 0, "payu", "payu", "PayU", "PayU", null, null },
                    { 3, false, "PE", "System", new DateTime(2020, 4, 27, 17, 58, 13, 487, DateTimeKind.Utc).AddTicks(5310), null, "Culqi", 0, "culqi", "culqi", "Culqi", "Culqi", null, null },
                    { 4, false, "PE", "System", new DateTime(2020, 4, 27, 17, 58, 13, 487, DateTimeKind.Utc).AddTicks(5310), null, "Mercado Pagos", 0, "mercadopago", "mercadopago", "Mercado Pagos", "MercadoPago", null, null }
                });

            migrationBuilder.InsertData(
                schema: "Payments",
                table: "PaymentMethod",
                columns: new[] { "PaymentMethodId", "Code", "CountryIsoCode", "CreatedBy", "CreatedOn", "DeletedOn", "Description", "EntityStatus", "IconLink", "IsPublished", "Name", "PaymentMethodGroupId", "UpdatedBy", "UpdatedOn", "ValidatorCardCodeMask", "ValidatorCardCodeRegex", "ValidatorCardMask", "ValidatorCardRegex", "ValidatorCardUseBillingAddress", "ValidatorCardUseCvv", "ValidatorCardUseExpirationDate" },
                values: new object[,]
                {
                    { 1, null, "PE", null, new DateTime(2020, 4, 27, 17, 58, 13, 486, DateTimeKind.Utc).AddTicks(8160), null, "Visa", 0, null, false, "Visa", 1, null, null, null, null, null, null, false, false, false },
                    { 2, null, "PE", null, new DateTime(2020, 4, 27, 17, 58, 13, 487, DateTimeKind.Utc).AddTicks(220), null, "Master Card", 0, null, false, "Master Card", 1, null, null, null, null, null, null, false, false, false },
                    { 3, null, "PE", null, new DateTime(2020, 4, 27, 17, 58, 13, 487, DateTimeKind.Utc).AddTicks(280), null, "American Express", 0, null, false, "American Express", 1, null, null, null, null, null, null, false, false, false },
                    { 4, null, "PE", null, new DateTime(2020, 4, 27, 17, 58, 13, 487, DateTimeKind.Utc).AddTicks(280), null, "Pago Efectivo", 0, null, false, "Pago Efectivo", 2, null, null, null, null, null, null, false, false, false },
                    { 5, null, "PE", null, new DateTime(2020, 4, 27, 17, 58, 13, 487, DateTimeKind.Utc).AddTicks(280), null, "Pago con Tarjeta Credito", 0, null, false, "Pago con Tarjeta Credito", 3, null, null, null, null, null, null, false, false, false },
                    { 6, null, "PE", null, new DateTime(2020, 4, 27, 17, 58, 13, 487, DateTimeKind.Utc).AddTicks(280), null, "Pago Efectivo", 0, null, false, "Pago Efectivo", 3, null, null, null, null, null, null, false, false, false },
                    { 7, null, "PE", null, new DateTime(2020, 4, 27, 17, 58, 13, 487, DateTimeKind.Utc).AddTicks(280), null, "Deposito en cuenta bancaria", 0, null, false, "Deposito en cuenta bancaria", 4, null, null, null, null, null, null, false, false, false },
                    { 8, null, "PE", null, new DateTime(2020, 4, 27, 17, 58, 13, 487, DateTimeKind.Utc).AddTicks(280), null, "Confirmación Manual", 0, null, false, "Confirmación Manual", 5, null, null, null, null, null, null, false, false, false }
                });

            migrationBuilder.InsertData(
                schema: "Payments",
                table: "ProviderSetting",
                columns: new[] { "ProviderSettingId", "CreatedBy", "CreatedOn", "DeletedOn", "EntityStatus", "IsReadOnly", "Key", "Label", "ProviderId", "UpdatedBy", "UpdatedOn", "Value" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 4, 27, 17, 58, 13, 487, DateTimeKind.Utc).AddTicks(6580), null, 0, false, "UserName", "Nombre Usuario", 1, null, null, "" },
                    { 2, null, new DateTime(2020, 4, 27, 17, 58, 13, 487, DateTimeKind.Utc).AddTicks(9010), null, 0, false, "Password", "Password", 1, null, null, "" },
                    { 3, null, new DateTime(2020, 4, 27, 17, 58, 13, 487, DateTimeKind.Utc).AddTicks(9160), null, 0, false, "MerchantId", "Merchant Id", 1, null, null, "" },
                    { 4, null, new DateTime(2020, 4, 27, 17, 58, 13, 487, DateTimeKind.Utc).AddTicks(9170), null, 0, true, "AuthorizeUrl", "Authorize Url", 1, null, null, "https://apitestenv.vnforapps.com/api.authorization/v3" },
                    { 5, null, new DateTime(2020, 4, 27, 17, 58, 13, 487, DateTimeKind.Utc).AddTicks(9170), null, 0, true, "ConfirmationUrl", "Confirmation Url", 1, null, null, "https://apitestenv.vnforapps.com/api.confirmation/v1" },
                    { 6, null, new DateTime(2020, 4, 27, 17, 58, 13, 487, DateTimeKind.Utc).AddTicks(9170), null, 0, true, "VoidUrl", "Void Url", 1, null, null, "https://apitestenv.vnforapps.com/api.authorization/v3" },
                    { 7, null, new DateTime(2020, 4, 27, 17, 58, 13, 487, DateTimeKind.Utc).AddTicks(9170), null, 0, true, "SecurityUrl", "Security Url", 1, null, null, "https://apitestenv.vnforapps.com/api.security/v1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_PaymentMethodGroupId",
                schema: "Payments",
                table: "PaymentMethod",
                column: "PaymentMethodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderSetting_ProviderId",
                schema: "Payments",
                table: "ProviderSetting",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ProviderId",
                schema: "Payments",
                table: "Transaction",
                column: "ProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSetting",
                schema: "Payments");

            migrationBuilder.DropTable(
                name: "PaymentMethod",
                schema: "Payments");

            migrationBuilder.DropTable(
                name: "ProviderSetting",
                schema: "Payments");

            migrationBuilder.DropTable(
                name: "Transaction",
                schema: "Payments");

            migrationBuilder.DropTable(
                name: "PaymentMethodGroup",
                schema: "Payments");

            migrationBuilder.DropTable(
                name: "Provider",
                schema: "Payments");
        }
    }
}
