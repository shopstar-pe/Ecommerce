using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Persistence.Migrations
{
    public partial class AddProviderSettingTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProviderSettingTenant",
                schema: "Payments",
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
                    ProviderSettingId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderSettingTenant", x => x.ProviderSettingTenantId);
                    table.ForeignKey(
                        name: "FK_ProviderSettingTenant_ProviderSetting_ProviderSettingId",
                        column: x => x.ProviderSettingId,
                        principalSchema: "Payments",
                        principalTable: "ProviderSetting",
                        principalColumn: "ProviderSettingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 852, DateTimeKind.Utc).AddTicks(2200));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 852, DateTimeKind.Utc).AddTicks(5180));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 854, DateTimeKind.Utc).AddTicks(2390));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 854, DateTimeKind.Utc).AddTicks(4510));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 854, DateTimeKind.Utc).AddTicks(4570));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 854, DateTimeKind.Utc).AddTicks(4570));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 854, DateTimeKind.Utc).AddTicks(4570));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 854, DateTimeKind.Utc).AddTicks(4570));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 854, DateTimeKind.Utc).AddTicks(4570));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 854, DateTimeKind.Utc).AddTicks(4570));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 853, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 854, DateTimeKind.Utc).AddTicks(1020));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 854, DateTimeKind.Utc).AddTicks(1090));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 854, DateTimeKind.Utc).AddTicks(1090));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 854, DateTimeKind.Utc).AddTicks(1090));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 854, DateTimeKind.Utc).AddTicks(9330));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 854, DateTimeKind.Utc).AddTicks(9820));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 854, DateTimeKind.Utc).AddTicks(9840));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 854, DateTimeKind.Utc).AddTicks(9840));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 855, DateTimeKind.Utc).AddTicks(1200));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 855, DateTimeKind.Utc).AddTicks(3930));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 855, DateTimeKind.Utc).AddTicks(4000));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 855, DateTimeKind.Utc).AddTicks(4000));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 855, DateTimeKind.Utc).AddTicks(4000));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 855, DateTimeKind.Utc).AddTicks(4000));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 36, 59, 855, DateTimeKind.Utc).AddTicks(4000));

            migrationBuilder.CreateIndex(
                name: "IX_ProviderSettingTenant_ProviderSettingId",
                schema: "Payments",
                table: "ProviderSettingTenant",
                column: "ProviderSettingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProviderSettingTenant",
                schema: "Payments");

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 493, DateTimeKind.Utc).AddTicks(1980));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 493, DateTimeKind.Utc).AddTicks(5010));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 495, DateTimeKind.Utc).AddTicks(2480));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 495, DateTimeKind.Utc).AddTicks(4660));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 495, DateTimeKind.Utc).AddTicks(4710));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 495, DateTimeKind.Utc).AddTicks(4710));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 495, DateTimeKind.Utc).AddTicks(4710));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 495, DateTimeKind.Utc).AddTicks(4710));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 495, DateTimeKind.Utc).AddTicks(4720));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 495, DateTimeKind.Utc).AddTicks(4720));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 494, DateTimeKind.Utc).AddTicks(8180));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 495, DateTimeKind.Utc).AddTicks(1130));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 495, DateTimeKind.Utc).AddTicks(1200));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 495, DateTimeKind.Utc).AddTicks(1200));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 495, DateTimeKind.Utc).AddTicks(1200));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 495, DateTimeKind.Utc).AddTicks(9320));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 495, DateTimeKind.Utc).AddTicks(9790));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 495, DateTimeKind.Utc).AddTicks(9870));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 495, DateTimeKind.Utc).AddTicks(9870));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 496, DateTimeKind.Utc).AddTicks(1110));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 496, DateTimeKind.Utc).AddTicks(3490));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 496, DateTimeKind.Utc).AddTicks(3550));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 496, DateTimeKind.Utc).AddTicks(3550));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 496, DateTimeKind.Utc).AddTicks(3550));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 496, DateTimeKind.Utc).AddTicks(3550));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 33, 38, 496, DateTimeKind.Utc).AddTicks(3550));
        }
    }
}
