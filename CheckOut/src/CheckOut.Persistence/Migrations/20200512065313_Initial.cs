using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckOut.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CheckOut");

            migrationBuilder.CreateTable(
                name: "AppSetting",
                schema: "CheckOut",
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
                name: "Draft",
                schema: "CheckOut",
                columns: table => new
                {
                    DraftId = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    CustomerEmail = table.Column<string>(nullable: true),
                    CustomerFirstName = table.Column<string>(nullable: true),
                    CustomerLastName = table.Column<string>(nullable: true),
                    CustomerPhone = table.Column<string>(nullable: true),
                    CustomerIdentificationNumber = table.Column<string>(nullable: true),
                    CustomerIdentificationType = table.Column<string>(nullable: true),
                    CustomerEntityName = table.Column<string>(nullable: true),
                    CustomerEntityIdentificationNumber = table.Column<string>(nullable: true),
                    CountryIsoCode = table.Column<string>(nullable: true),
                    CurrencyIsoCode = table.Column<string>(nullable: true),
                    CouponCode = table.Column<string>(nullable: true),
                    ShippingFirstName = table.Column<string>(nullable: true),
                    ShippingLastName = table.Column<string>(nullable: true),
                    ShippingIdentificationNumber = table.Column<string>(nullable: true),
                    ShippingIdentificationType = table.Column<string>(nullable: true),
                    ShippingPhone = table.Column<string>(nullable: true),
                    ShippingAddressLine = table.Column<string>(nullable: true),
                    ShippingAddressNumber = table.Column<string>(nullable: true),
                    ShippingReference = table.Column<string>(nullable: true),
                    ShippingCountryIsoCode = table.Column<string>(nullable: true),
                    ShippingPostalCode = table.Column<string>(nullable: true),
                    ShippingLatitude = table.Column<decimal>(nullable: false),
                    ShippingLongitude = table.Column<decimal>(nullable: false),
                    ShippingDepartment = table.Column<string>(nullable: true),
                    ShippingProvince = table.Column<string>(nullable: true),
                    ShippingDistrict = table.Column<string>(nullable: true),
                    SubTotal = table.Column<decimal>(nullable: false),
                    TotalShipping = table.Column<decimal>(nullable: false),
                    TotalTax = table.Column<decimal>(nullable: false),
                    TotalDiscount = table.Column<decimal>(nullable: false),
                    GrandTotal = table.Column<decimal>(nullable: false),
                    ServiceFee = table.Column<decimal>(nullable: false),
                    Tip = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Draft", x => x.DraftId);
                });

            migrationBuilder.CreateTable(
                name: "DraftItem",
                schema: "CheckOut",
                columns: table => new
                {
                    DraftItemId = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    DraftId = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    ProductImage = table.Column<string>(nullable: true),
                    FinalPrice = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    AdditionalNote = table.Column<string>(nullable: true),
                    SellerId = table.Column<int>(nullable: false),
                    SellerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DraftItem", x => x.DraftItemId);
                    table.ForeignKey(
                        name: "FK_DraftItem_Draft_DraftId",
                        column: x => x.DraftId,
                        principalSchema: "CheckOut",
                        principalTable: "Draft",
                        principalColumn: "DraftId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DraftItemDiscount",
                schema: "CheckOut",
                columns: table => new
                {
                    DraftItemDiscountId = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    IsPercentual = table.Column<bool>(nullable: false),
                    DraftItemId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DraftItemDiscount", x => x.DraftItemDiscountId);
                    table.ForeignKey(
                        name: "FK_DraftItemDiscount_DraftItem_DraftItemId",
                        column: x => x.DraftItemId,
                        principalSchema: "CheckOut",
                        principalTable: "DraftItem",
                        principalColumn: "DraftItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DraftItemService",
                schema: "CheckOut",
                columns: table => new
                {
                    DraftItemServiceId = table.Column<string>(nullable: false),
                    DraftItemId = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    BasePrice = table.Column<decimal>(nullable: false),
                    SpecialPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DraftItemService", x => new { x.DraftItemId, x.DraftItemServiceId });
                    table.ForeignKey(
                        name: "FK_DraftItemService_DraftItem_DraftItemId",
                        column: x => x.DraftItemId,
                        principalSchema: "CheckOut",
                        principalTable: "DraftItem",
                        principalColumn: "DraftItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DraftItemVariant",
                schema: "CheckOut",
                columns: table => new
                {
                    DraftItemVariantId = table.Column<string>(nullable: false),
                    DraftItemId = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    SkuId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    BasePrice = table.Column<decimal>(nullable: false),
                    SpecialPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DraftItemVariant", x => new { x.DraftItemId, x.DraftItemVariantId });
                    table.ForeignKey(
                        name: "FK_DraftItemVariant_DraftItem_DraftItemId",
                        column: x => x.DraftItemId,
                        principalSchema: "CheckOut",
                        principalTable: "DraftItem",
                        principalColumn: "DraftItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "CheckOut",
                table: "AppSetting",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedOn", "EntityStatus", "Group", "IsReadOnly", "Name", "UpdatedBy", "UpdatedOn", "Value" },
                values: new object[] { 1, null, new DateTime(2020, 5, 12, 6, 53, 13, 182, DateTimeKind.Utc).AddTicks(3080), null, 0, "Application", true, "Version", null, null, "v1" });

            migrationBuilder.InsertData(
                schema: "CheckOut",
                table: "AppSetting",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedOn", "EntityStatus", "Group", "IsReadOnly", "Name", "UpdatedBy", "UpdatedOn", "Value" },
                values: new object[] { 2, null, new DateTime(2020, 5, 12, 6, 53, 13, 182, DateTimeKind.Utc).AddTicks(6270), null, 0, "Application", true, "Owner", null, null, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_DraftItem_DraftId",
                schema: "CheckOut",
                table: "DraftItem",
                column: "DraftId");

            migrationBuilder.CreateIndex(
                name: "IX_DraftItemDiscount_DraftItemId",
                schema: "CheckOut",
                table: "DraftItemDiscount",
                column: "DraftItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSetting",
                schema: "CheckOut");

            migrationBuilder.DropTable(
                name: "DraftItemDiscount",
                schema: "CheckOut");

            migrationBuilder.DropTable(
                name: "DraftItemService",
                schema: "CheckOut");

            migrationBuilder.DropTable(
                name: "DraftItemVariant",
                schema: "CheckOut");

            migrationBuilder.DropTable(
                name: "DraftItem",
                schema: "CheckOut");

            migrationBuilder.DropTable(
                name: "Draft",
                schema: "CheckOut");
        }
    }
}
