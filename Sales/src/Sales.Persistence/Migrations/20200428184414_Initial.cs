using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sales.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.CreateTable(
                name: "AppSetting",
                schema: "Sales",
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
                name: "Client",
                schema: "Sales",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    IdentificationNumber = table.Column<string>(nullable: true),
                    IdentificationType = table.Column<string>(nullable: true),
                    EntityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "ClientSeller",
                schema: "Sales",
                columns: table => new
                {
                    SellerId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSeller", x => new { x.ClientId, x.SellerId });
                    table.ForeignKey(
                        name: "FK_ClientSeller_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "Sales",
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleOrder",
                schema: "Sales",
                columns: table => new
                {
                    SaleOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    TransactionId = table.Column<string>(nullable: true),
                    CheckOutId = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    SaleOrderStatus = table.Column<int>(nullable: false),
                    OrderType = table.Column<int>(nullable: false),
                    EntityName = table.Column<string>(nullable: true),
                    EntityIdentificationNumber = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    PreOrderOrderDate = table.Column<DateTime>(nullable: true),
                    ConfirmedOrderDate = table.Column<DateTime>(nullable: true),
                    PaymentOrderDate = table.Column<DateTime>(nullable: true),
                    ShippingOrderDate = table.Column<DateTime>(nullable: true),
                    ClosedOrderDate = table.Column<DateTime>(nullable: true),
                    CanceledOrderDate = table.Column<DateTime>(nullable: true),
                    OrderGroup = table.Column<string>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    SellerId = table.Column<int>(nullable: false),
                    SellerName = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: false),
                    CountryIsoCode = table.Column<string>(nullable: true),
                    CurrencyIsoCode = table.Column<string>(nullable: true),
                    PaymentMethodId = table.Column<string>(nullable: true),
                    PaymentMethodName = table.Column<string>(nullable: true),
                    ShippingMethodId = table.Column<string>(nullable: true),
                    ShippingMethodName = table.Column<string>(nullable: true),
                    CarrierId = table.Column<string>(nullable: true),
                    CarrierName = table.Column<string>(nullable: true),
                    CouponCode = table.Column<string>(nullable: true),
                    SubTotal = table.Column<decimal>(nullable: false),
                    Shipping = table.Column<decimal>(nullable: false),
                    Tax = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    ServiceFee = table.Column<decimal>(nullable: false),
                    Tips = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    IsPrePaid = table.Column<bool>(nullable: false),
                    IsPreOrder = table.Column<bool>(nullable: false),
                    IsPickUp = table.Column<bool>(nullable: false),
                    TrackingCode = table.Column<string>(nullable: true),
                    TrackingLink = table.Column<string>(nullable: true),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    BillingFirstName = table.Column<string>(nullable: true),
                    BillingLastName = table.Column<string>(nullable: true),
                    BillingPhone = table.Column<string>(nullable: true),
                    BillingCellPhone = table.Column<string>(nullable: true),
                    BillingAddressLine = table.Column<string>(nullable: true),
                    BillingReference = table.Column<string>(nullable: true),
                    BillingCountryIsoCode = table.Column<string>(nullable: true),
                    BillingPostalCode = table.Column<string>(nullable: true),
                    ShippingFirstName = table.Column<string>(nullable: true),
                    ShippingLastName = table.Column<string>(nullable: true),
                    ShippingPhone = table.Column<string>(nullable: true),
                    ShippingCellPhone = table.Column<string>(nullable: true),
                    ShippingAddressLine = table.Column<string>(nullable: true),
                    ShippingAddressNumber = table.Column<string>(nullable: true),
                    ShippingReference = table.Column<string>(nullable: true),
                    ShippingCountryIsoCode = table.Column<string>(nullable: true),
                    ShippingPostalCode = table.Column<string>(nullable: true),
                    ShippingLatitude = table.Column<string>(nullable: true),
                    ShippingLongitude = table.Column<string>(nullable: true),
                    ShippingDepartment = table.Column<string>(nullable: true),
                    ShippingProvince = table.Column<string>(nullable: true),
                    ShippingDistrict = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrder", x => x.SaleOrderId);
                    table.ForeignKey(
                        name: "FK_SaleOrder_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "Sales",
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleOrderItem",
                schema: "Sales",
                columns: table => new
                {
                    SaleOrderItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    SaleOrderId = table.Column<int>(nullable: false),
                    SaleOrderItemStatus = table.Column<int>(nullable: false),
                    ProductId = table.Column<string>(nullable: true),
                    SkuId = table.Column<string>(nullable: true),
                    SKU = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    ProductImage = table.Column<string>(nullable: true),
                    BasePrice = table.Column<decimal>(nullable: false),
                    SpecialPrice = table.Column<decimal>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    AdditionalNote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrderItem", x => x.SaleOrderItemId);
                    table.ForeignKey(
                        name: "FK_SaleOrderItem_SaleOrder_SaleOrderId",
                        column: x => x.SaleOrderId,
                        principalSchema: "Sales",
                        principalTable: "SaleOrder",
                        principalColumn: "SaleOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleOrderTracking",
                schema: "Sales",
                columns: table => new
                {
                    SaleOrderTrackingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    SaleOrderId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    TrackingType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrderTracking", x => x.SaleOrderTrackingId);
                    table.ForeignKey(
                        name: "FK_SaleOrderTracking_SaleOrder_SaleOrderId",
                        column: x => x.SaleOrderId,
                        principalSchema: "Sales",
                        principalTable: "SaleOrder",
                        principalColumn: "SaleOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleOrderItemService",
                schema: "Sales",
                columns: table => new
                {
                    SaleOrderItemServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    ServiceId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    BasePrice = table.Column<decimal>(nullable: false),
                    SpecialPrice = table.Column<decimal>(nullable: false),
                    FinalPrice = table.Column<decimal>(nullable: false),
                    SaleOrderItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrderItemService", x => x.SaleOrderItemServiceId);
                    table.ForeignKey(
                        name: "FK_SaleOrderItemService_SaleOrderItem_SaleOrderItemId",
                        column: x => x.SaleOrderItemId,
                        principalSchema: "Sales",
                        principalTable: "SaleOrderItem",
                        principalColumn: "SaleOrderItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Sales",
                table: "AppSetting",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedOn", "EntityStatus", "Group", "IsReadOnly", "Name", "UpdatedBy", "UpdatedOn", "Value" },
                values: new object[] { 1, null, new DateTime(2020, 4, 28, 18, 44, 13, 456, DateTimeKind.Utc).AddTicks(9360), null, 0, "Application", true, "Version", null, null, "v1" });

            migrationBuilder.InsertData(
                schema: "Sales",
                table: "AppSetting",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedOn", "EntityStatus", "Group", "IsReadOnly", "Name", "UpdatedBy", "UpdatedOn", "Value" },
                values: new object[] { 2, null, new DateTime(2020, 4, 28, 18, 44, 13, 457, DateTimeKind.Utc).AddTicks(3010), null, 0, "Application", true, "Owner", null, null, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrder_ClientId",
                schema: "Sales",
                table: "SaleOrder",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderItem_SaleOrderId",
                schema: "Sales",
                table: "SaleOrderItem",
                column: "SaleOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderItemService_SaleOrderItemId",
                schema: "Sales",
                table: "SaleOrderItemService",
                column: "SaleOrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderTracking_SaleOrderId",
                schema: "Sales",
                table: "SaleOrderTracking",
                column: "SaleOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSetting",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "ClientSeller",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SaleOrderItemService",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SaleOrderTracking",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SaleOrderItem",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "SaleOrder",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "Sales");
        }
    }
}
