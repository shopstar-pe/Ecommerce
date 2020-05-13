using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shippings.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Shipping");

            migrationBuilder.CreateTable(
                name: "AppSetting",
                schema: "Shipping",
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
                name: "Provider",
                schema: "Shipping",
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
                name: "ShippingMethod",
                schema: "Shipping",
                columns: table => new
                {
                    ShippingMethodId = table.Column<int>(nullable: false)
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
                    IsPublished = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethod", x => x.ShippingMethodId);
                });

            migrationBuilder.CreateTable(
                name: "ProviderSetting",
                schema: "Shipping",
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
                        principalSchema: "Shipping",
                        principalTable: "Provider",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProviderTenant",
                schema: "Shipping",
                columns: table => new
                {
                    ProviderTenantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    ProviderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderTenant", x => x.ProviderTenantId);
                    table.ForeignKey(
                        name: "FK_ProviderTenant_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalSchema: "Shipping",
                        principalTable: "Provider",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shipment",
                schema: "Shipping",
                columns: table => new
                {
                    ShipmentId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    OrderId = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    ShipmentDate = table.Column<DateTime>(nullable: false),
                    ShipmentExternalId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    AddressLine = table.Column<string>(nullable: true),
                    CurrencyIsoCode = table.Column<string>(nullable: true),
                    CountryIsoCode = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    SellerId = table.Column<int>(nullable: false),
                    SellerName = table.Column<string>(nullable: true),
                    ProviderId = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.ShipmentId);
                    table.ForeignKey(
                        name: "FK_Shipment_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalSchema: "Shipping",
                        principalTable: "Provider",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethodTenant",
                schema: "Shipping",
                columns: table => new
                {
                    ShippingMethodTenantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    ShippingMethodId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethodTenant", x => x.ShippingMethodTenantId);
                    table.ForeignKey(
                        name: "FK_ShippingMethodTenant_ShippingMethod_ShippingMethodId",
                        column: x => x.ShippingMethodId,
                        principalSchema: "Shipping",
                        principalTable: "ShippingMethod",
                        principalColumn: "ShippingMethodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProviderSettingTenant",
                schema: "Shipping",
                columns: table => new
                {
                    ProviderSettingTenantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    ProviderSettingId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderSettingTenant", x => x.ProviderSettingTenantId);
                    table.ForeignKey(
                        name: "FK_ProviderSettingTenant_ProviderSetting_ProviderSettingId",
                        column: x => x.ProviderSettingId,
                        principalSchema: "Shipping",
                        principalTable: "ProviderSetting",
                        principalColumn: "ProviderSettingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Shipping",
                table: "AppSetting",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedOn", "EntityStatus", "Group", "IsReadOnly", "Name", "UpdatedBy", "UpdatedOn", "Value" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 4, 28, 16, 18, 10, 620, DateTimeKind.Utc).AddTicks(8070), null, 0, "Application", true, "Version", null, null, "v1" },
                    { 2, null, new DateTime(2020, 4, 28, 16, 18, 10, 621, DateTimeKind.Utc).AddTicks(1240), null, 0, "Application", true, "Owner", null, null, "admin" }
                });

            migrationBuilder.InsertData(
                schema: "Shipping",
                table: "Provider",
                columns: new[] { "ProviderId", "Active", "CountryIsoCode", "CreatedBy", "CreatedOn", "DeletedOn", "Description", "EntityStatus", "Icon", "Image", "Label", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, true, "PE", "System", new DateTime(2020, 4, 28, 16, 18, 10, 623, DateTimeKind.Utc).AddTicks(3990), null, "Chazki", 0, "chazki", "chazki", "Chazki", "Chazki", null, null },
                    { 2, true, "PE", "System", new DateTime(2020, 4, 28, 16, 18, 10, 623, DateTimeKind.Utc).AddTicks(4700), null, "Rappi", 0, "rappi", "rappi", "Rappi", "Rappi", null, null },
                    { 3, true, "PE", "System", new DateTime(2020, 4, 28, 16, 18, 10, 623, DateTimeKind.Utc).AddTicks(4710), null, "Glovo", 0, "glovo", "glovo", "Glovo", "Glovo", null, null }
                });

            migrationBuilder.InsertData(
                schema: "Shipping",
                table: "ShippingMethod",
                columns: new[] { "ShippingMethodId", "CountryIsoCode", "CreatedBy", "CreatedOn", "DeletedOn", "Description", "EntityStatus", "IsPublished", "Label", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, "PE", null, new DateTime(2020, 4, 28, 16, 18, 10, 622, DateTimeKind.Utc).AddTicks(5620), null, "Envio de productos gratis a tus compradores. Miralo como una inversión, asumes el valor del envio y mejora tus ventas. Es muy recomendado que tengas envios gratis en tu tienda para fidelizar tus clientes y aumentar tus ventas.", 0, false, "Envío Gratis", "Free", null, null },
                    { 2, "PE", null, new DateTime(2020, 4, 28, 16, 18, 10, 622, DateTimeKind.Utc).AddTicks(8240), null, "El valor del envio siempre sera el mismo, sin importar el numero de articulos, peso o precio de la compra. Aparecera un valor fijo para ciudades principales y otro para el resto del país.", 0, false, "Tarifa Plana", "Flat", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProviderSetting_ProviderId",
                schema: "Shipping",
                table: "ProviderSetting",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderSettingTenant_ProviderSettingId",
                schema: "Shipping",
                table: "ProviderSettingTenant",
                column: "ProviderSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderTenant_ProviderId",
                schema: "Shipping",
                table: "ProviderTenant",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_ProviderId",
                schema: "Shipping",
                table: "Shipment",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingMethodTenant_ShippingMethodId",
                schema: "Shipping",
                table: "ShippingMethodTenant",
                column: "ShippingMethodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSetting",
                schema: "Shipping");

            migrationBuilder.DropTable(
                name: "ProviderSettingTenant",
                schema: "Shipping");

            migrationBuilder.DropTable(
                name: "ProviderTenant",
                schema: "Shipping");

            migrationBuilder.DropTable(
                name: "Shipment",
                schema: "Shipping");

            migrationBuilder.DropTable(
                name: "ShippingMethodTenant",
                schema: "Shipping");

            migrationBuilder.DropTable(
                name: "ProviderSetting",
                schema: "Shipping");

            migrationBuilder.DropTable(
                name: "ShippingMethod",
                schema: "Shipping");

            migrationBuilder.DropTable(
                name: "Provider",
                schema: "Shipping");
        }
    }
}
