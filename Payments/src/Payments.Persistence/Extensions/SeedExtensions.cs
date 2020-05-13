using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Payments.Domain.Entities;

namespace Payments.Persistence.Extensions
{
    public static class SeedExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppSetting>().HasData(
                new AppSetting
                {
                    Id = 1,
                    Group = "Application",
                    Name = "Version",
                    Value = "v1",
                    IsReadOnly = true
                },
                new AppSetting
                {
                    Id = 2,
                    Group = "Application",
                    Name = "Owner",
                    Value = "admin",
                    IsReadOnly = true
                }
            );

            modelBuilder.Entity<PaymentMethodGroup>().HasData(
                new PaymentMethodGroup
                {
                    PaymentMethodGroupId = 1,
                    Name = "CreditCard",
                    Label = "Tarjeta de Credito",
                    Description = "Tarjeta de Credito",
                    CountryIsoCode = "PE",
                    Active = true,
                    Order = 0
                },
                new PaymentMethodGroup
                {
                    PaymentMethodGroupId = 2,
                    Name = "CashOnBank",
                    Label = "Pago en banco",
                    Description = "Pago en banco",
                    CountryIsoCode = "PE",
                    Active = true,
                    Order = 1
                },
                new PaymentMethodGroup
                {
                    PaymentMethodGroupId = 3,
                    Name = "CashOnDelivery",
                    Label = "Pago contra entrega",
                    Description = "Pago contra entrega",
                    CountryIsoCode = "PE",
                    Active = true,
                    Order = 2
                },
                new PaymentMethodGroup
                {
                    PaymentMethodGroupId = 4,
                    Name = "BankDeposit",
                    Label = "Deposito en Banco",
                    Description = "Deposito en Banco",
                    CountryIsoCode = "PE",
                    Active = true,
                    Order = 3
                },
                new PaymentMethodGroup
                {
                    PaymentMethodGroupId = 5,
                    Name = "Manual",
                    Label = "Confirmación Manual",
                    Description = "Confirmación Manual",
                    CountryIsoCode = "PE",
                    Active = true,
                    Order = 4
                }
            );

            modelBuilder.Entity<PaymentMethod>().HasData(
                new PaymentMethod
                {
                    PaymentMethodId = 1,
                    PaymentMethodGroupId = 1,
                    Name = "Visa",
                    Description = "Visa",
                    CountryIsoCode = "PE"
                },
                new PaymentMethod
                {
                    PaymentMethodId = 2,
                    PaymentMethodGroupId = 1,
                    Name = "Master Card",
                    Description = "Master Card",
                    CountryIsoCode = "PE"
                },
                new PaymentMethod
                {
                    PaymentMethodId = 3,
                    PaymentMethodGroupId = 1,
                    Name = "American Express",
                    Description = "American Express",
                    CountryIsoCode = "PE"
                },
                new PaymentMethod
                {
                    PaymentMethodId = 4,
                    PaymentMethodGroupId = 2,
                    Name = "Pago Efectivo",
                    Description = "Pago Efectivo",
                    CountryIsoCode = "PE"
                },
                new PaymentMethod
                {
                    PaymentMethodId = 5,
                    PaymentMethodGroupId = 3,
                    Name = "Pago con Tarjeta Credito",
                    Description = "Pago con Tarjeta Credito",
                    CountryIsoCode = "PE"
                },
                new PaymentMethod
                {
                    PaymentMethodId = 6,
                    PaymentMethodGroupId = 3,
                    Name = "Pago Efectivo",
                    Description = "Pago Efectivo",
                    CountryIsoCode = "PE"
                },
                new PaymentMethod
                {
                    PaymentMethodId = 7,
                    PaymentMethodGroupId = 4,
                    Name = "Deposito en cuenta bancaria",
                    Description = "Deposito en cuenta bancaria",
                    CountryIsoCode = "PE"
                },
                new PaymentMethod
                {
                    PaymentMethodId = 8,
                    PaymentMethodGroupId = 5,
                    Name = "Confirmación Manual",
                    Description = "Confirmación Manual",
                    CountryIsoCode = "PE"
                }
            );

            modelBuilder.Entity<Provider>().HasData(
                new Provider
                {
                    ProviderId = 1,
                    Label = "VisaNet",
                    Name = "VisaNet",
                    Description = "VisaNet",
                    Active = true,
                    Icon = "visanet",
                    Image = "visanet",
                    PaymentCreditCard = true,
                    CountryIsoCode = "PE",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "System",
                    EntityStatus = EntityStatus.Active
                },
                new Provider
                {
                    ProviderId = 2,
                    Label = "PayU",
                    Name = "PayU",
                    Description = "PayU",
                    Active = true,
                    Icon = "payu",
                    Image = "payu",
                    PaymentCreditCard = true,
                    CountryIsoCode = "PE",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "System",
                    EntityStatus = EntityStatus.Active,
                },
                new Provider
                {
                    ProviderId = 3,
                    Label = "Culqi",
                    Name = "Culqi",
                    Description = "Culqi",
                    Active = true,
                    PaymentCreditCard = true,
                    Icon = "culqi",
                    Image = "culqi",
                    CountryIsoCode = "PE",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "System",
                    EntityStatus = EntityStatus.Active,
                },
                new Provider
                {
                    ProviderId = 4,
                    Label = "Mercado Pagos",
                    Name = "MercadoPago",
                    Description = "Mercado Pagos",
                    Active = true,
                    PaymentCreditCard = true,
                    Icon = "mercadopago",
                    Image = "mercadopago",
                    CountryIsoCode = "PE",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "System",
                    EntityStatus = EntityStatus.Active,
                },
                new Provider
                {
                    ProviderId = 5,
                    Label = "Pago Efectivo",
                    Name = "PagoEfectivo",
                    Description = "Pago Efectivo",
                    Active = true,
                    PaymentCreditCard = false,
                    Icon = "pagoefectivo",
                    Image = "pagoefectivo",
                    CountryIsoCode = "PE",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "System",
                    EntityStatus = EntityStatus.Active,
                }
            );

            modelBuilder.Entity<ProviderSetting>().HasData(
                new ProviderSetting { ProviderSettingId = 1, ProviderId = 1, Label = "Nombre Usuario", Key = "UserName", Value = "", IsReadOnly = false },
                new ProviderSetting { ProviderSettingId = 2, ProviderId = 1, Label = "Password", Key = "Password", Value = "", IsReadOnly = false },
                new ProviderSetting { ProviderSettingId = 3, ProviderId = 1, Label = "Merchant Id", Key = "MerchantId", Value = "", IsReadOnly = false },
                new ProviderSetting { ProviderSettingId = 4, ProviderId = 1, Label = "Authorize Url", Key = "AuthorizeUrl", Value = "https://apitestenv.vnforapps.com/api.authorization/v3", IsReadOnly = true },
                new ProviderSetting { ProviderSettingId = 5, ProviderId = 1, Label = "Confirmation Url", Key = "ConfirmationUrl", Value = "https://apitestenv.vnforapps.com/api.confirmation/v1", IsReadOnly = true },
                new ProviderSetting { ProviderSettingId = 6, ProviderId = 1, Label = "Void Url", Key = "VoidUrl", Value = "https://apitestenv.vnforapps.com/api.authorization/v3", IsReadOnly = true },
                new ProviderSetting { ProviderSettingId = 7, ProviderId = 1, Label = "Security Url", Key = "SecurityUrl", Value = "https://apitestenv.vnforapps.com/api.security/v1", IsReadOnly = true },
                new ProviderSetting { ProviderSettingId = 8, ProviderId = 1, Label = "Channel", Key = "Channel", Value = "web", IsReadOnly = true },
                new ProviderSetting { ProviderSettingId = 9, ProviderId = 1, Label = "Capture Type", Key = "CaptureType", Value = "manual", IsReadOnly = true },
                new ProviderSetting { ProviderSettingId = 10, ProviderId = 1, Label = "Countable", Key = "Countable", Value = "False", IsReadOnly = true }
            );
        }
    }
}
