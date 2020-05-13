﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shippings.Persistence.Contexts;

namespace Shippings.Persistence.Migrations
{
    [DbContext(typeof(ShippingsDbContext))]
    [Migration("20200428161811_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Shipping")
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shippings.Domain.Entities.AppSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("AppSetting");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2020, 4, 28, 16, 18, 10, 620, DateTimeKind.Utc).AddTicks(8070),
                            EntityStatus = 0,
                            Group = "Application",
                            IsReadOnly = true,
                            Name = "Version",
                            Value = "v1"
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2020, 4, 28, 16, 18, 10, 621, DateTimeKind.Utc).AddTicks(1240),
                            EntityStatus = 0,
                            Group = "Application",
                            IsReadOnly = true,
                            Name = "Owner",
                            Value = "admin"
                        });
                });

            modelBuilder.Entity("Shippings.Domain.Entities.Provider", b =>
                {
                    b.Property<int>("ProviderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CountryIsoCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("ProviderId");

                    b.ToTable("Provider");

                    b.HasData(
                        new
                        {
                            ProviderId = 1,
                            Active = true,
                            CountryIsoCode = "PE",
                            CreatedBy = "System",
                            CreatedOn = new DateTime(2020, 4, 28, 16, 18, 10, 623, DateTimeKind.Utc).AddTicks(3990),
                            Description = "Chazki",
                            EntityStatus = 0,
                            Icon = "chazki",
                            Image = "chazki",
                            Label = "Chazki",
                            Name = "Chazki"
                        },
                        new
                        {
                            ProviderId = 2,
                            Active = true,
                            CountryIsoCode = "PE",
                            CreatedBy = "System",
                            CreatedOn = new DateTime(2020, 4, 28, 16, 18, 10, 623, DateTimeKind.Utc).AddTicks(4700),
                            Description = "Rappi",
                            EntityStatus = 0,
                            Icon = "rappi",
                            Image = "rappi",
                            Label = "Rappi",
                            Name = "Rappi"
                        },
                        new
                        {
                            ProviderId = 3,
                            Active = true,
                            CountryIsoCode = "PE",
                            CreatedBy = "System",
                            CreatedOn = new DateTime(2020, 4, 28, 16, 18, 10, 623, DateTimeKind.Utc).AddTicks(4710),
                            Description = "Glovo",
                            EntityStatus = 0,
                            Icon = "glovo",
                            Image = "glovo",
                            Label = "Glovo",
                            Name = "Glovo"
                        });
                });

            modelBuilder.Entity("Shippings.Domain.Entities.ProviderSetting", b =>
                {
                    b.Property<int>("ProviderSettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("bit");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProviderId")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProviderSettingId");

                    b.HasIndex("ProviderId");

                    b.ToTable("ProviderSetting");
                });

            modelBuilder.Entity("Shippings.Domain.Entities.ProviderSettingTenant", b =>
                {
                    b.Property<int>("ProviderSettingTenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int");

                    b.Property<int>("ProviderSettingId")
                        .HasColumnType("int");

                    b.Property<string>("TenantId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProviderSettingTenantId");

                    b.HasIndex("ProviderSettingId");

                    b.ToTable("ProviderSettingTenant");
                });

            modelBuilder.Entity("Shippings.Domain.Entities.ProviderTenant", b =>
                {
                    b.Property<int>("ProviderTenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int");

                    b.Property<int>("ProviderId")
                        .HasColumnType("int");

                    b.Property<string>("TenantId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("ProviderTenantId");

                    b.HasIndex("ProviderId");

                    b.ToTable("ProviderTenant");
                });

            modelBuilder.Entity("Shippings.Domain.Entities.Shipment", b =>
                {
                    b.Property<Guid>("ShipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryIsoCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrencyIsoCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProviderId")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.Property<string>("SellerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ShipmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShipmentExternalId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenantId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("ShipmentId");

                    b.HasIndex("ProviderId");

                    b.ToTable("Shipment");
                });

            modelBuilder.Entity("Shippings.Domain.Entities.ShippingMethod", b =>
                {
                    b.Property<int>("ShippingMethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryIsoCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("ShippingMethodId");

                    b.ToTable("ShippingMethod");

                    b.HasData(
                        new
                        {
                            ShippingMethodId = 1,
                            CountryIsoCode = "PE",
                            CreatedOn = new DateTime(2020, 4, 28, 16, 18, 10, 622, DateTimeKind.Utc).AddTicks(5620),
                            Description = "Envio de productos gratis a tus compradores. Miralo como una inversión, asumes el valor del envio y mejora tus ventas. Es muy recomendado que tengas envios gratis en tu tienda para fidelizar tus clientes y aumentar tus ventas.",
                            EntityStatus = 0,
                            IsPublished = false,
                            Label = "Envío Gratis",
                            Name = "Free"
                        },
                        new
                        {
                            ShippingMethodId = 2,
                            CountryIsoCode = "PE",
                            CreatedOn = new DateTime(2020, 4, 28, 16, 18, 10, 622, DateTimeKind.Utc).AddTicks(8240),
                            Description = "El valor del envio siempre sera el mismo, sin importar el numero de articulos, peso o precio de la compra. Aparecera un valor fijo para ciudades principales y otro para el resto del país.",
                            EntityStatus = 0,
                            IsPublished = false,
                            Label = "Tarifa Plana",
                            Name = "Flat"
                        });
                });

            modelBuilder.Entity("Shippings.Domain.Entities.ShippingMethodTenant", b =>
                {
                    b.Property<int>("ShippingMethodTenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("EntityStatus")
                        .HasColumnType("int");

                    b.Property<int>("ShippingMethodId")
                        .HasColumnType("int");

                    b.Property<string>("TenantId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("ShippingMethodTenantId");

                    b.HasIndex("ShippingMethodId");

                    b.ToTable("ShippingMethodTenant");
                });

            modelBuilder.Entity("Shippings.Domain.Entities.ProviderSetting", b =>
                {
                    b.HasOne("Shippings.Domain.Entities.Provider", "Provider")
                        .WithMany("ProviderSettings")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shippings.Domain.Entities.ProviderSettingTenant", b =>
                {
                    b.HasOne("Shippings.Domain.Entities.ProviderSetting", "ProviderSetting")
                        .WithMany("ProviderSettingTenants")
                        .HasForeignKey("ProviderSettingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shippings.Domain.Entities.ProviderTenant", b =>
                {
                    b.HasOne("Shippings.Domain.Entities.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shippings.Domain.Entities.Shipment", b =>
                {
                    b.HasOne("Shippings.Domain.Entities.Provider", "Provider")
                        .WithMany("Shipments")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shippings.Domain.Entities.ShippingMethodTenant", b =>
                {
                    b.HasOne("Shippings.Domain.Entities.ShippingMethod", "ShippingMethod")
                        .WithMany()
                        .HasForeignKey("ShippingMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
