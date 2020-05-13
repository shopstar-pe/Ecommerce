using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shippings.Persistence.Migrations
{
    public partial class AddShippingV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Shipping",
                table: "ShippingMethod",
                keyColumn: "ShippingMethodId",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "ProviderType",
                schema: "Shipping",
                table: "Provider",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "CreatedOn", "Description", "Icon", "Image", "Label", "Name" },
                values: new object[] { new DateTime(2020, 5, 12, 2, 7, 57, 992, DateTimeKind.Utc).AddTicks(8920), "Urbaner", "urbaner", "urbaner", "Urbaner", "Urbaner" });

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Description", "Icon", "Image", "Label", "Name" },
                values: new object[] { new DateTime(2020, 5, 12, 2, 7, 57, 992, DateTimeKind.Utc).AddTicks(9050), "Urbano", "urbano", "urbano", "Urbano", "Urbano" });

            migrationBuilder.InsertData(
                schema: "Shipping",
                table: "Provider",
                columns: new[] { "ProviderId", "Active", "CountryIsoCode", "CreatedBy", "CreatedOn", "DeletedOn", "Description", "EntityStatus", "Icon", "Image", "Label", "Name", "ProviderType", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 4, true, "PE", "System", new DateTime(2020, 5, 12, 2, 7, 57, 992, DateTimeKind.Utc).AddTicks(9050), null, "Rappi", 0, "rappi", "rappi", "Rappi", "Rappi", 0, null, null },
                    { 5, true, "PE", "System", new DateTime(2020, 5, 12, 2, 7, 57, 992, DateTimeKind.Utc).AddTicks(9050), null, "Glovo", 0, "glovo", "glovo", "Glovo", "Glovo", 0, null, null }
                });

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "ShippingMethod",
                keyColumn: "ShippingMethodId",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Description", "Label", "Name" },
                values: new object[] { new DateTime(2020, 5, 12, 2, 7, 57, 992, DateTimeKind.Utc).AddTicks(660), "El valor del envio siempre sera el mismo, sin importar el numero de articulos, peso o precio de la compra. Aparecera un valor fijo para ciudades principales y otro para el resto del país.", "Tarifa Plana", "Flat" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Shipping",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Shipping",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "ProviderType",
                schema: "Shipping",
                table: "Provider");

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 16, 18, 10, 620, DateTimeKind.Utc).AddTicks(8070));

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "AppSetting",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 16, 18, 10, 621, DateTimeKind.Utc).AddTicks(1240));

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 4, 28, 16, 18, 10, 623, DateTimeKind.Utc).AddTicks(3990));

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Description", "Icon", "Image", "Label", "Name" },
                values: new object[] { new DateTime(2020, 4, 28, 16, 18, 10, 623, DateTimeKind.Utc).AddTicks(4700), "Rappi", "rappi", "rappi", "Rappi", "Rappi" });

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "Provider",
                keyColumn: "ProviderId",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Description", "Icon", "Image", "Label", "Name" },
                values: new object[] { new DateTime(2020, 4, 28, 16, 18, 10, 623, DateTimeKind.Utc).AddTicks(4710), "Glovo", "glovo", "glovo", "Glovo", "Glovo" });

            migrationBuilder.UpdateData(
                schema: "Shipping",
                table: "ShippingMethod",
                keyColumn: "ShippingMethodId",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Description", "Label", "Name" },
                values: new object[] { new DateTime(2020, 4, 28, 16, 18, 10, 622, DateTimeKind.Utc).AddTicks(5620), "Envio de productos gratis a tus compradores. Miralo como una inversión, asumes el valor del envio y mejora tus ventas. Es muy recomendado que tengas envios gratis en tu tienda para fidelizar tus clientes y aumentar tus ventas.", "Envío Gratis", "Free" });

            migrationBuilder.InsertData(
                schema: "Shipping",
                table: "ShippingMethod",
                columns: new[] { "ShippingMethodId", "CountryIsoCode", "CreatedBy", "CreatedOn", "DeletedOn", "Description", "EntityStatus", "IsPublished", "Label", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[] { 2, "PE", null, new DateTime(2020, 4, 28, 16, 18, 10, 622, DateTimeKind.Utc).AddTicks(8240), null, "El valor del envio siempre sera el mismo, sin importar el numero de articulos, peso o precio de la compra. Aparecera un valor fijo para ciudades principales y otro para el resto del país.", 0, false, "Tarifa Plana", "Flat", null, null });
        }
    }
}
