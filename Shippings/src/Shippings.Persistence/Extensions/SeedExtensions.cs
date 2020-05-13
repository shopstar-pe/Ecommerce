using System;
using Microsoft.EntityFrameworkCore;
using Shippings.Domain.Entities;

namespace Shippings.Persistence.Extensions
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


            modelBuilder.Entity<ShippingMethod>().HasData(
                new ShippingMethod
                {
                    ShippingMethodId = 1,
                    Name = "Express",
                    Label = "Express",
                    Description = "Express",
                    CountryIsoCode = "PE"
                }, new ShippingMethod
                {
                    ShippingMethodId = 2,
                    Name = "Regular",
                    Label = "Regular",
                    Description = "Regular",
                    CountryIsoCode = "PE"
                }, new ShippingMethod
                {
                    ShippingMethodId = 3,
                    Name = "SameOrNextDay",
                    Label = "Same Or Next Day",
                    Description = "Mismo o al día siguiente",
                    CountryIsoCode = "PE"
                }
                , new ShippingMethod
                {
                    ShippingMethodId = 4,
                    Name = "Scheduled",
                    Label = "Programado",
                    Description = "Programado",
                    CountryIsoCode = "PE"
                }
            );


            modelBuilder.Entity<Provider>().HasData(
                new Provider
                {
                    ProviderId = 1,
                    Label = "Chazki",
                    Name = "Chazki",
                    Description = "Chazki",
                    Active = true,
                    Icon = "chazki",
                    Image = "chazki",
                    CountryIsoCode = "PE",
                    ProviderType = ProviderType.External,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "System",
                    EntityStatus = EntityStatus.Active
                },
                new Provider
                {
                    ProviderId = 2,
                    Label = "Urbaner",
                    Name = "Urbaner",
                    Description = "Urbaner",
                    Active = true,
                    Icon = "urbaner",
                    Image = "urbaner",
                    CountryIsoCode = "PE",
                    ProviderType = ProviderType.External,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "System",
                    EntityStatus = EntityStatus.Active
                },
                new Provider
                {
                    ProviderId = 3,
                    Label = "Urbano",
                    Name = "Urbano",
                    Description = "Urbano",
                    Active = true,
                    Icon = "urbano",
                    Image = "urbano",
                    CountryIsoCode = "PE",
                    ProviderType = ProviderType.External,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "System",
                    EntityStatus = EntityStatus.Active
                },
                new Provider
                {
                    ProviderId = 4,
                    Label = "Rappi",
                    Name = "Rappi",
                    Description = "Rappi",
                    Active = true,
                    Icon = "rappi",
                    Image = "rappi",
                    CountryIsoCode = "PE",
                    ProviderType = ProviderType.External,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "System",
                    EntityStatus = EntityStatus.Active,
                },
                new Provider
                {
                    ProviderId = 5,
                    Label = "Glovo",
                    Name = "Glovo",
                    Description = "Glovo",
                    Active = true,
                    Icon = "glovo",
                    Image = "glovo",
                    CountryIsoCode = "PE",
                    ProviderType = ProviderType.External,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "System",
                    EntityStatus = EntityStatus.Active,
                },
                new Provider
                {
                    ProviderId = 6,
                    Label = "Kurumi",
                    Name = "Kurumi",
                    Description = "Kurumi",
                    Active = true,
                    Icon = "kurumi",
                    Image = "kurumi",
                    CountryIsoCode = "PE",
                    ProviderType = ProviderType.Partner,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "System",
                    EntityStatus = EntityStatus.Active,
                }
            );

            modelBuilder.Entity<ProviderSetting>().HasData(
                new ProviderSetting { ProviderSettingId = 1, ProviderId = 6, Label = "Client Id", Key = "ClientId", Value = "DF7BD349-1CFA-4B72-B612-376B5A1E76C9", IsReadOnly = true },
                new ProviderSetting { ProviderSettingId = 2, ProviderId = 6, Label = "Client Secret", Key = "ClientSecret", Value = "s5E5s3hgBZL6Hqc", IsReadOnly = true }
            );
        }
    }
}
