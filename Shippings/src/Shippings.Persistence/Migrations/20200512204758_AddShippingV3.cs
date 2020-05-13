using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shippings.Persistence.Migrations
{
    public partial class AddShippingV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courier",
                schema: "Shipping",
                columns: table => new
                {
                    CourierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SellerId = table.Column<int>(nullable: false),
                    SellerName = table.Column<string>(nullable: true),
                    ExternalId = table.Column<string>(nullable: true),
                    ExternalName = table.Column<string>(nullable: true),
                    ClientId = table.Column<string>(nullable: true),
                    ClientCredentials = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courier", x => x.CourierId);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                schema: "Shipping",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ExternalId = table.Column<string>(nullable: true),
                    ExternalName = table.Column<string>(nullable: true),
                    CourierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.BranchId);
                    table.ForeignKey(
                        name: "FK_Branch_Courier_CourierId",
                        column: x => x.CourierId,
                        principalSchema: "Shipping",
                        principalTable: "Courier",
                        principalColumn: "CourierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                schema: "Shipping",
                columns: table => new
                {
                    DriverId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    IdentificationType = table.Column<string>(nullable: true),
                    IdentificationNumber = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DriverType = table.Column<int>(nullable: false),
                    ExternalId = table.Column<string>(nullable: true),
                    ExternalName = table.Column<string>(nullable: true),
                    CourierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.DriverId);
                    table.ForeignKey(
                        name: "FK_Driver_Courier_CourierId",
                        column: x => x.CourierId,
                        principalSchema: "Shipping",
                        principalTable: "Courier",
                        principalColumn: "CourierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coverage",
                schema: "Shipping",
                columns: table => new
                {
                    CoverageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    CoverageType = table.Column<int>(nullable: false),
                    CoverageValue = table.Column<string>(nullable: true),
                    ExternalId = table.Column<string>(nullable: true),
                    ExternalName = table.Column<string>(nullable: true),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coverage", x => x.CoverageId);
                    table.ForeignKey(
                        name: "FK_Coverage_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Shipping",
                        principalTable: "Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rate",
                schema: "Shipping",
                columns: table => new
                {
                    RateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    SupportCashOnDelivery = table.Column<bool>(nullable: false),
                    OriginId = table.Column<int>(nullable: false),
                    DestinationId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    ExternalId = table.Column<string>(nullable: true),
                    ExternalName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.RateId);
                    table.ForeignKey(
                        name: "FK_Rate_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Shipping",
                        principalTable: "Branch",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RatePrice",
                schema: "Shipping",
                columns: table => new
                {
                    RatePriceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingMethodTenantId = table.Column<int>(nullable: false),
                    MinWeight = table.Column<decimal>(nullable: false),
                    MaxWeight = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PriceCOD = table.Column<decimal>(nullable: false),
                    RateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatePrice", x => x.RatePriceId);
                    table.ForeignKey(
                        name: "FK_RatePrice_Rate_RateId",
                        column: x => x.RateId,
                        principalSchema: "Shipping",
                        principalTable: "Rate",
                        principalColumn: "RateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RatePrice_ShippingMethodTenant_ShippingMethodTenantId",
                        column: x => x.ShippingMethodTenantId,
                        principalSchema: "Shipping",
                        principalTable: "ShippingMethodTenant",
                        principalColumn: "ShippingMethodTenantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 12, 20, 47, 57, 928, DateTimeKind.Utc).AddTicks(9140));

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 12, 20, 47, 57, 929, DateTimeKind.Utc).AddTicks(2240));

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 12, 20, 47, 57, 931, DateTimeKind.Utc).AddTicks(2200));

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 12, 20, 47, 57, 931, DateTimeKind.Utc).AddTicks(2710));

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 12, 20, 47, 57, 931, DateTimeKind.Utc).AddTicks(2720));

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 12, 20, 47, 57, 931, DateTimeKind.Utc).AddTicks(2720));

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 12, 20, 47, 57, 931, DateTimeKind.Utc).AddTicks(2720));

            migrationBuilder.InsertData(
                schema: "Shipping",
                table: "Provider",
                columns: new[] { "ProviderId", "Active", "CountryIsoCode", "CreatedBy", "CreatedOn", "DeletedOn", "Description", "EntityStatus", "Icon", "Image", "Label", "Name", "ProviderType", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 6, true, "PE", "System", new DateTime(2020, 5, 12, 20, 47, 57, 931, DateTimeKind.Utc).AddTicks(2720), null, "Kurumi", 0, "kurumi", "kurumi", "Kurumi", "Kurumi", 1, null, null });

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "ShippingMethod",
                keyColumn: "ShippingMethodId",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Description", "Label", "Name" },
                values: new object[] { new DateTime(2020, 5, 12, 20, 47, 57, 930, DateTimeKind.Utc).AddTicks(4930), "Express", "Express", "Express" });

            migrationBuilder.InsertData(
                schema: "Shipping",
                table: "ShippingMethod",
                columns: new[] { "ShippingMethodId", "CountryIsoCode", "CreatedBy", "CreatedOn", "DeletedOn", "Description", "EntityStatus", "IsPublished", "Label", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 2, "PE", null, new DateTime(2020, 5, 12, 20, 47, 57, 930, DateTimeKind.Utc).AddTicks(7130), null, "Regular", 0, false, "Regular", "Regular", null, null },
                    { 3, "PE", null, new DateTime(2020, 5, 12, 20, 47, 57, 930, DateTimeKind.Utc).AddTicks(7180), null, "Mismo o al día siguiente", 0, false, "Same Or Next Day", "SameOrNextDay", null, null },
                    { 4, "PE", null, new DateTime(2020, 5, 12, 20, 47, 57, 930, DateTimeKind.Utc).AddTicks(7180), null, "Programado", 0, false, "Programado", "Scheduled", null, null }
                });

            migrationBuilder.InsertData(
                schema: "Shipping",
                table: "ProviderSetting",
                columns: new[] { "ProviderSettingId", "CreatedBy", "CreatedOn", "DeletedOn", "EntityStatus", "IsReadOnly", "Key", "Label", "ProviderId", "UpdatedBy", "UpdatedOn", "Value" },
                values: new object[] { 1, null, new DateTime(2020, 5, 12, 20, 47, 57, 931, DateTimeKind.Utc).AddTicks(4090), null, 0, true, "ClientId", "Client Id", 6, null, null, "DF7BD349-1CFA-4B72-B612-376B5A1E76C9" });

            migrationBuilder.InsertData(
                schema: "Shipping",
                table: "ProviderSetting",
                columns: new[] { "ProviderSettingId", "CreatedBy", "CreatedOn", "DeletedOn", "EntityStatus", "IsReadOnly", "Key", "Label", "ProviderId", "UpdatedBy", "UpdatedOn", "Value" },
                values: new object[] { 2, null, new DateTime(2020, 5, 12, 20, 47, 57, 931, DateTimeKind.Utc).AddTicks(6510), null, 0, true, "ClientSecret", "Client Secret", 6, null, null, "s5E5s3hgBZL6Hqc" });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_CourierId",
                schema: "Shipping",
                table: "Branch",
                column: "CourierId");

            migrationBuilder.CreateIndex(
                name: "IX_Coverage_BranchId",
                schema: "Shipping",
                table: "Coverage",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_CourierId",
                schema: "Shipping",
                table: "Driver",
                column: "CourierId");

            migrationBuilder.CreateIndex(
                name: "IX_Rate_BranchId",
                schema: "Shipping",
                table: "Rate",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_RatePrice_RateId",
                schema: "Shipping",
                table: "RatePrice",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_RatePrice_ShippingMethodTenantId",
                schema: "Shipping",
                table: "RatePrice",
                column: "ShippingMethodTenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coverage",
                schema: "Shipping");

            migrationBuilder.DropTable(
                name: "Driver",
                schema: "Shipping");

            migrationBuilder.DropTable(
                name: "RatePrice",
                schema: "Shipping");

            migrationBuilder.DropTable(
                name: "Rate",
                schema: "Shipping");

            migrationBuilder.DropTable(
                name: "Branch",
                schema: "Shipping");

            migrationBuilder.DropTable(
                name: "Courier",
                schema: "Shipping");

            migrationBuilder.DeleteData(
                schema: "Shipping",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Shipping",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Shipping",
                table: "ShippingMethod",
                keyColumn: "ShippingMethodId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Shipping",
                table: "ShippingMethod",
                keyColumn: "ShippingMethodId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Shipping",
                table: "ShippingMethod",
                keyColumn: "ShippingMethodId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Shipping",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 6);

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 12, 2, 7, 57, 990, DateTimeKind.Utc).AddTicks(4140));

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 12, 2, 7, 57, 990, DateTimeKind.Utc).AddTicks(7280));

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 12, 2, 7, 57, 992, DateTimeKind.Utc).AddTicks(8360));

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 12, 2, 7, 57, 992, DateTimeKind.Utc).AddTicks(8920));

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 12, 2, 7, 57, 992, DateTimeKind.Utc).AddTicks(9050));

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 12, 2, 7, 57, 992, DateTimeKind.Utc).AddTicks(9050));

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 12, 2, 7, 57, 992, DateTimeKind.Utc).AddTicks(9050));

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "ShippingMethod",
                keyColumn: "ShippingMethodId",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Description", "Label", "Name" },
                values: new object[] { new DateTime(2020, 5, 12, 2, 7, 57, 992, DateTimeKind.Utc).AddTicks(660), "El valor del envio siempre sera el mismo, sin importar el numero de articulos, peso o precio de la compra. Aparecera un valor fijo para ciudades principales y otro para el resto del país.", "Tarifa Plana", "Flat" });
        }
    }
}
