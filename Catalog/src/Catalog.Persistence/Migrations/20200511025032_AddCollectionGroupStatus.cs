using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Migrations
{
    public partial class AddCollectionGroupStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CollectionGroupStatus",
                schema: "Catalog",
                table: "CollectionGroup",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "Catalog",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 11, 2, 50, 31, 536, DateTimeKind.Utc).AddTicks(2510));

            migrationBuilder.UpdateData(
                schema: "Catalog",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 11, 2, 50, 31, 536, DateTimeKind.Utc).AddTicks(5540));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CollectionGroupStatus",
                schema: "Catalog",
                table: "CollectionGroup");

            migrationBuilder.UpdateData(
                schema: "Catalog",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 11, 1, 33, 47, 22, DateTimeKind.Utc).AddTicks(1960));

            migrationBuilder.UpdateData(
                schema: "Catalog",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 5, 11, 1, 33, 47, 22, DateTimeKind.Utc).AddTicks(5360));
        }
    }
}
