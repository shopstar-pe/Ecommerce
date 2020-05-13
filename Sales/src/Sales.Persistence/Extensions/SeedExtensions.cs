using System;
using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;

namespace Sales.Persistence.Extensions
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
        }
    }
}
