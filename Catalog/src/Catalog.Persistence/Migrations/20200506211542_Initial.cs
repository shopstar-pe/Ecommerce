using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "AppSetting",
                schema: "Catalog",
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
                name: "Brand",
                schema: "Catalog",
                columns: table => new
                {
                    BrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    BrandStatus = table.Column<int>(nullable: false),
                    MetaTitle = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Catalog",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    CategoryParentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    CategoryStatus = table.Column<int>(nullable: false),
                    MetaTitle = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Seller",
                schema: "Catalog",
                columns: table => new
                {
                    SellerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyTaxId = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    ContactPhone = table.Column<string>(nullable: true),
                    ExchangesAndReturns = table.Column<string>(nullable: true),
                    DeliveryPolicy = table.Column<string>(nullable: true),
                    PrivacyAndSecurityPolicy = table.Column<string>(nullable: true),
                    SellerStatus = table.Column<int>(nullable: false),
                    SellerType = table.Column<int>(nullable: false),
                    MetaTitle = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    CountryIsoCode = table.Column<string>(nullable: true),
                    CurrencyIsoCode = table.Column<string>(nullable: true),
                    BaseComission = table.Column<decimal>(nullable: false),
                    BaseMinimumOrderValue = table.Column<decimal>(nullable: false),
                    BaseShippingCost = table.Column<decimal>(nullable: false),
                    BaseDeliveryTimeInMinutes = table.Column<int>(nullable: false),
                    BaseLeadTimeInMinutes = table.Column<int>(nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    TotalReviews = table.Column<int>(nullable: false),
                    CountReviews = table.Column<int>(nullable: false),
                    AllowPreOrder = table.Column<bool>(nullable: false),
                    PreOrderTimeInAdvance = table.Column<int>(nullable: true),
                    PreOrderTimeAsMax = table.Column<int>(nullable: true),
                    AllowPickup = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.SellerId);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalService",
                schema: "Catalog",
                columns: table => new
                {
                    AdditionalServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsVisibleOnCart = table.Column<bool>(nullable: false),
                    IsGiftCard = table.Column<bool>(nullable: false),
                    IsRequired = table.Column<bool>(nullable: false),
                    IsVisibleOnProduct = table.Column<bool>(nullable: false),
                    IsVisibleOnService = table.Column<bool>(nullable: false),
                    IsMultiOption = table.Column<bool>(nullable: false),
                    SellerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalService", x => x.AdditionalServiceId);
                    table.ForeignKey(
                        name: "FK_AdditionalService_Seller_SellerId",
                        column: x => x.SellerId,
                        principalSchema: "Catalog",
                        principalTable: "Seller",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollectionGroup",
                schema: "Catalog",
                columns: table => new
                {
                    CollectionGroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    SellerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionGroup", x => x.CollectionGroupId);
                    table.ForeignKey(
                        name: "FK_CollectionGroup_Seller_SellerId",
                        column: x => x.SellerId,
                        principalSchema: "Catalog",
                        principalTable: "Seller",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "Catalog",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsPrincipal = table.Column<bool>(nullable: false),
                    IsWarehouse = table.Column<bool>(nullable: false),
                    CountryIsoCode = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    AddressNumber = table.Column<string>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    GeoLocationX = table.Column<decimal>(nullable: false),
                    GeoLocationY = table.Column<decimal>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    AllowPreOrder = table.Column<bool>(nullable: true),
                    PreOrderTimeInAdvance = table.Column<int>(nullable: true),
                    PreOrderTimeAsMax = table.Column<int>(nullable: true),
                    AllowPickup = table.Column<bool>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false),
                    SellerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Location_Seller_SellerId",
                        column: x => x.SellerId,
                        principalSchema: "Catalog",
                        principalTable: "Seller",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Catalog",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    BrandId = table.Column<int>(nullable: true),
                    SellerId = table.Column<int>(nullable: false),
                    HasVariations = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    ConditionType = table.Column<int>(nullable: false),
                    ProductType = table.Column<int>(nullable: false),
                    AllowStorePickup = table.Column<bool>(nullable: false),
                    AllowHomeDelivery = table.Column<bool>(nullable: false),
                    AllowSaveAndSubscription = table.Column<bool>(nullable: false),
                    AllowPurchaseWithoutStock = table.Column<bool>(nullable: false),
                    ApplyTaxes = table.Column<bool>(nullable: false),
                    AdditionalNoteRequired = table.Column<bool>(nullable: false),
                    CountryIsoCode = table.Column<string>(nullable: true),
                    CurrencyIsoCode = table.Column<string>(nullable: true),
                    MetaTitle = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    Keywords = table.Column<string>(nullable: true),
                    ProductStatus = table.Column<int>(nullable: false),
                    ExternalCode = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    TotalViews = table.Column<int>(nullable: false),
                    TotalLikes = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    TotalReviews = table.Column<int>(nullable: false),
                    CountReviews = table.Column<int>(nullable: false),
                    BasePrice = table.Column<decimal>(nullable: false),
                    SpecialPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "Catalog",
                        principalTable: "Brand",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Seller_SellerId",
                        column: x => x.SellerId,
                        principalSchema: "Catalog",
                        principalTable: "Seller",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellerSchedule",
                schema: "Catalog",
                columns: table => new
                {
                    SellerScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    OpenInMinute = table.Column<int>(nullable: false),
                    CloseInMinute = table.Column<int>(nullable: false),
                    Monday = table.Column<bool>(nullable: false),
                    Tuesday = table.Column<bool>(nullable: false),
                    Wednesday = table.Column<bool>(nullable: false),
                    Thursday = table.Column<bool>(nullable: false),
                    Friday = table.Column<bool>(nullable: false),
                    Saturday = table.Column<bool>(nullable: false),
                    Sunday = table.Column<bool>(nullable: false),
                    SellerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerSchedule", x => x.SellerScheduleId);
                    table.ForeignKey(
                        name: "FK_SellerSchedule_Seller_SellerId",
                        column: x => x.SellerId,
                        principalSchema: "Catalog",
                        principalTable: "Seller",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalServicePrice",
                schema: "Catalog",
                columns: table => new
                {
                    AdditionalServicePriceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BasePrice = table.Column<decimal>(nullable: false),
                    SpecialPrice = table.Column<decimal>(nullable: false),
                    AdditionalServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalServicePrice", x => x.AdditionalServicePriceId);
                    table.ForeignKey(
                        name: "FK_AdditionalServicePrice_AdditionalService_AdditionalServiceId",
                        column: x => x.AdditionalServiceId,
                        principalSchema: "Catalog",
                        principalTable: "AdditionalService",
                        principalColumn: "AdditionalServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Collection",
                schema: "Catalog",
                columns: table => new
                {
                    CollectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Banner = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    SellerId = table.Column<int>(nullable: true),
                    MetaTitle = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    CollectionGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.CollectionId);
                    table.ForeignKey(
                        name: "FK_Collection_CollectionGroup_CollectionGroupId",
                        column: x => x.CollectionGroupId,
                        principalSchema: "Catalog",
                        principalTable: "CollectionGroup",
                        principalColumn: "CollectionGroupId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Collection_Seller_SellerId",
                        column: x => x.SellerId,
                        principalSchema: "Catalog",
                        principalTable: "Seller",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PriceList",
                schema: "Catalog",
                columns: table => new
                {
                    PriceListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ReferenceId = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceList", x => x.PriceListId);
                    table.ForeignKey(
                        name: "FK_PriceList_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttribute",
                schema: "Catalog",
                columns: table => new
                {
                    ProductAttributeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttribute", x => x.ProductAttributeId);
                    table.ForeignKey(
                        name: "FK_ProductAttribute_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "Catalog",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Catalog",
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                schema: "Catalog",
                columns: table => new
                {
                    ProductImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UrlLinkOriginal = table.Column<string>(nullable: true),
                    UrlLinkThumb = table.Column<string>(nullable: true),
                    UrlLinkCatalog = table.Column<string>(nullable: true),
                    UrlLinkProduct = table.Column<string>(nullable: true),
                    UrlLinkZoom = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    IsPrimary = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.ProductImageId);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelatedProduct",
                schema: "Catalog",
                columns: table => new
                {
                    RelatedProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    ProductReferenceId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    OverridePrice = table.Column<decimal>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedProduct", x => x.RelatedProductId);
                    table.ForeignKey(
                        name: "FK_RelatedProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sku",
                schema: "Catalog",
                columns: table => new
                {
                    SkuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    ExternalSkuId = table.Column<string>(nullable: true),
                    ExternalSkuName = table.Column<string>(nullable: true),
                    SKU = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TrackingStock = table.Column<bool>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    MinStock = table.Column<int>(nullable: false),
                    BasePrice = table.Column<decimal>(nullable: false),
                    SpecialPrice = table.Column<decimal>(nullable: true),
                    ExclusivePrice = table.Column<decimal>(nullable: true),
                    Bullets = table.Column<string>(nullable: true),
                    SkuStatus = table.Column<int>(nullable: false),
                    ExternalCode = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Height = table.Column<decimal>(nullable: false),
                    Length = table.Column<decimal>(nullable: false),
                    Width = table.Column<decimal>(nullable: false),
                    Weight = table.Column<decimal>(nullable: false),
                    PackageHeight = table.Column<decimal>(nullable: false),
                    PackageLength = table.Column<decimal>(nullable: false),
                    PackageWeight = table.Column<decimal>(nullable: false),
                    PackageWidth = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sku", x => x.SkuId);
                    table.ForeignKey(
                        name: "FK_Sku_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCollection",
                schema: "Catalog",
                columns: table => new
                {
                    CollectionId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCollection", x => new { x.ProductId, x.CollectionId });
                    table.ForeignKey(
                        name: "FK_ProductCollection_Collection_CollectionId",
                        column: x => x.CollectionId,
                        principalSchema: "Catalog",
                        principalTable: "Collection",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCollection_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                schema: "Catalog",
                columns: table => new
                {
                    SkuId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => new { x.SkuId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_Inventory_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Catalog",
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Inventory_Sku_SkuId",
                        column: x => x.SkuId,
                        principalSchema: "Catalog",
                        principalTable: "Sku",
                        principalColumn: "SkuId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SkuAdditionalServicePrice",
                schema: "Catalog",
                columns: table => new
                {
                    AdditionalServicePriceId = table.Column<int>(nullable: false),
                    SkuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkuAdditionalServicePrice", x => new { x.SkuId, x.AdditionalServicePriceId });
                    table.ForeignKey(
                        name: "FK_SkuAdditionalServicePrice_AdditionalServicePrice_AdditionalServicePriceId",
                        column: x => x.AdditionalServicePriceId,
                        principalSchema: "Catalog",
                        principalTable: "AdditionalServicePrice",
                        principalColumn: "AdditionalServicePriceId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SkuAdditionalServicePrice_Sku_SkuId",
                        column: x => x.SkuId,
                        principalSchema: "Catalog",
                        principalTable: "Sku",
                        principalColumn: "SkuId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SkuAttribute",
                schema: "Catalog",
                columns: table => new
                {
                    SkuAttributeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    SkuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkuAttribute", x => x.SkuAttributeId);
                    table.ForeignKey(
                        name: "FK_SkuAttribute_Sku_SkuId",
                        column: x => x.SkuId,
                        principalSchema: "Catalog",
                        principalTable: "Sku",
                        principalColumn: "SkuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkuImage",
                schema: "Catalog",
                columns: table => new
                {
                    SkuImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    SkuId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UrlLinkOriginal = table.Column<string>(nullable: true),
                    UrlLinkThumb = table.Column<string>(nullable: true),
                    UrlLinkCatalog = table.Column<string>(nullable: true),
                    UrlLinkProduct = table.Column<string>(nullable: true),
                    UrlLinkZoom = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    IsPrimary = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkuImage", x => x.SkuImageId);
                    table.ForeignKey(
                        name: "FK_SkuImage_Sku_SkuId",
                        column: x => x.SkuId,
                        principalSchema: "Catalog",
                        principalTable: "Sku",
                        principalColumn: "SkuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "AppSetting",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedOn", "EntityStatus", "Group", "IsReadOnly", "Name", "UpdatedBy", "UpdatedOn", "Value" },
                values: new object[] { 1, null, new DateTime(2020, 5, 6, 21, 15, 41, 976, DateTimeKind.Utc).AddTicks(3340), null, 0, "Application", true, "Version", null, null, "v1" });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "AppSetting",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedOn", "EntityStatus", "Group", "IsReadOnly", "Name", "UpdatedBy", "UpdatedOn", "Value" },
                values: new object[] { 2, null, new DateTime(2020, 5, 6, 21, 15, 41, 976, DateTimeKind.Utc).AddTicks(6580), null, 0, "Application", true, "Owner", null, null, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalService_SellerId",
                schema: "Catalog",
                table: "AdditionalService",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalServicePrice_AdditionalServiceId",
                schema: "Catalog",
                table: "AdditionalServicePrice",
                column: "AdditionalServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Collection_CollectionGroupId",
                schema: "Catalog",
                table: "Collection",
                column: "CollectionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Collection_SellerId",
                schema: "Catalog",
                table: "Collection",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionGroup_SellerId",
                schema: "Catalog",
                table: "CollectionGroup",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_LocationId",
                schema: "Catalog",
                table: "Inventory",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_SellerId",
                schema: "Catalog",
                table: "Location",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceList_ProductId",
                schema: "Catalog",
                table: "PriceList",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                schema: "Catalog",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SellerId",
                schema: "Catalog",
                table: "Product",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttribute_ProductId",
                schema: "Catalog",
                table: "ProductAttribute",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                schema: "Catalog",
                table: "ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCollection_CollectionId",
                schema: "Catalog",
                table: "ProductCollection",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                schema: "Catalog",
                table: "ProductImage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedProduct_ProductId",
                schema: "Catalog",
                table: "RelatedProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerSchedule_SellerId",
                schema: "Catalog",
                table: "SellerSchedule",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sku_ProductId",
                schema: "Catalog",
                table: "Sku",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SkuAdditionalServicePrice_AdditionalServicePriceId",
                schema: "Catalog",
                table: "SkuAdditionalServicePrice",
                column: "AdditionalServicePriceId");

            migrationBuilder.CreateIndex(
                name: "IX_SkuAttribute_SkuId",
                schema: "Catalog",
                table: "SkuAttribute",
                column: "SkuId");

            migrationBuilder.CreateIndex(
                name: "IX_SkuImage_SkuId",
                schema: "Catalog",
                table: "SkuImage",
                column: "SkuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSetting",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Inventory",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "PriceList",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "ProductAttribute",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "ProductCollection",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "ProductImage",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "RelatedProduct",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "SellerSchedule",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "SkuAdditionalServicePrice",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "SkuAttribute",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "SkuImage",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Collection",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AdditionalServicePrice",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Sku",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "CollectionGroup",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AdditionalService",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Brand",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Seller",
                schema: "Catalog");
        }
    }
}
