using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vouchers.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Vouchers");

            migrationBuilder.CreateTable(
                name: "AppSetting",
                schema: "Vouchers",
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
                name: "Campaign",
                schema: "Vouchers",
                columns: table => new
                {
                    CampaignId = table.Column<int>(nullable: false)
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
                    SellerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.CampaignId);
                });

            migrationBuilder.CreateTable(
                name: "Coupon",
                schema: "Vouchers",
                columns: table => new
                {
                    CouponId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UtmSource = table.Column<string>(nullable: true),
                    UtmCampaign = table.Column<string>(nullable: true),
                    ConditionType = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    IsUnlimited = table.Column<bool>(nullable: false),
                    UsageLimit = table.Column<int>(nullable: false),
                    LimitByCustomer = table.Column<bool>(nullable: false),
                    Used = table.Column<int>(nullable: false),
                    MinOrderAmount = table.Column<decimal>(nullable: true),
                    MaxOrderAmount = table.Column<decimal>(nullable: true),
                    SellerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.CouponId);
                });

            migrationBuilder.InsertData(
                schema: "Vouchers",
                table: "AppSetting",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedOn", "EntityStatus", "Group", "IsReadOnly", "Name", "UpdatedBy", "UpdatedOn", "Value" },
                values: new object[] { 1, null, new DateTime(2020, 4, 28, 22, 57, 15, 77, DateTimeKind.Utc).AddTicks(1350), null, 0, "Application", true, "Version", null, null, "v1" });

            migrationBuilder.InsertData(
                schema: "Vouchers",
                table: "AppSetting",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedOn", "EntityStatus", "Group", "IsReadOnly", "Name", "UpdatedBy", "UpdatedOn", "Value" },
                values: new object[] { 2, null, new DateTime(2020, 4, 28, 22, 57, 15, 77, DateTimeKind.Utc).AddTicks(4630), null, 0, "Application", true, "Owner", null, null, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSetting",
                schema: "Vouchers");

            migrationBuilder.DropTable(
                name: "Campaign",
                schema: "Vouchers");

            migrationBuilder.DropTable(
                name: "Coupon",
                schema: "Vouchers");
        }
    }
}
