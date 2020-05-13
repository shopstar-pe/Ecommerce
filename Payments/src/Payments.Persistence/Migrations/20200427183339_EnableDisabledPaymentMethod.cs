using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payments.Persistence.Migrations
{
    public partial class EnableDisabledPaymentMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentMethodDisabled",
                schema: "Payments",
                columns: table => new
                {
                    PaymentMethodDisabledId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    EntityStatus = table.Column<int>(nullable: false),
                    TenantId = table.Column<string>(nullable: true),
                    PaymentMethodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethodDisabled", x => x.PaymentMethodDisabledId);
                    table.ForeignKey(
                        name: "FK_PaymentMethodDisabled_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalSchema: "Payments",
                        principalTable: "PaymentMethod",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethodDisabled_PaymentMethodId",
                schema: "Payments",
                table: "PaymentMethodDisabled",
                column: "PaymentMethodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentMethodDisabled",
                schema: "Payments");

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 297, DateTimeKind.Utc).AddTicks(7880));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 298, DateTimeKind.Utc).AddTicks(1070));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 299, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 300, DateTimeKind.Utc).AddTicks(180));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 300, DateTimeKind.Utc).AddTicks(230));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 300, DateTimeKind.Utc).AddTicks(230));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 300, DateTimeKind.Utc).AddTicks(230));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 300, DateTimeKind.Utc).AddTicks(230));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 300, DateTimeKind.Utc).AddTicks(240));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethod",
                keyColumn: "PaymentMethodId",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 300, DateTimeKind.Utc).AddTicks(240));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 299, DateTimeKind.Utc).AddTicks(3840));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 299, DateTimeKind.Utc).AddTicks(6790));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 299, DateTimeKind.Utc).AddTicks(6860));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 299, DateTimeKind.Utc).AddTicks(6860));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "PaymentMethodGroup",
                keyColumn: "PaymentMethodGroupId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 299, DateTimeKind.Utc).AddTicks(6860));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 300, DateTimeKind.Utc).AddTicks(4620));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 300, DateTimeKind.Utc).AddTicks(5480));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 300, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 300, DateTimeKind.Utc).AddTicks(5490));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 300, DateTimeKind.Utc).AddTicks(6830));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 300, DateTimeKind.Utc).AddTicks(9690));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 300, DateTimeKind.Utc).AddTicks(9760));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 300, DateTimeKind.Utc).AddTicks(9760));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 300, DateTimeKind.Utc).AddTicks(9760));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 300, DateTimeKind.Utc).AddTicks(9760));

            migrationBuilder.UpdateData(
                schema: "Payments",
                table: "ProviderSetting",
                keyColumn: "ProviderSettingId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 27, 18, 31, 13, 300, DateTimeKind.Utc).AddTicks(9760));
        }
    }
}
