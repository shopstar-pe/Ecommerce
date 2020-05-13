
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Search.API.Models;
using Search.API.Repositories;

namespace Search.API.Services {

    public class DatabaseSellerService : ISellerService
    {
        private readonly SearchDbContext _dbContext;
        public DatabaseSellerService(SearchDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<SellerModel> GetSellerById(string tenantId, string slug)
        {
            var result = new SellerModel { };

            slug = slug.ToLower();

            result = await this._dbContext.Sellers.Select(c => new SellerModel
            {
                Slug = c.Slug,
                SellerId = c.SellerId,
                TenantId = c.TenantId,
                Name = c.Name,
                CompanyName = c.CompanyName,
                AllowPickup = c.AllowPickup,
                AllowPreOrder = c.AllowPreOrder,
                AddressLine = "",
                BaseDeliveryTimeInMinutes = c.BaseDeliveryTimeInMinutes,
                BaseLeadTimeInMinutes = c.BaseLeadTimeInMinutes,
                BaseMinimumOrderValue = c.BaseMinimumOrderValue,
                BaseShippingCost = c.BaseShippingCost,
                ContactEmail = c.ContactEmail,
                ContactName = c.ContactName,
                Description = c.Description,
                CountryIsoCode = c.CountryIsoCode,
                CurrencyIsoCode = c.CurrencyIsoCode,
                CurrencySymbol = c.CurrencyIsoCode.Equals("PEN") ? "S/" : "",
                MetaTitle = c.MetaTitle,
                MetaDescription = c.MetaDescription,
                Rating = c.Rating,
                CompanyTaxId = c.CompanyTaxId,
                Logo = c.Logo,
                Banner = c.Banner,
                Phone = c.Phone,
                SellerStatus = c.SellerStatus,
                SellerType = c.SellerType
            }).FirstOrDefaultAsync(x => x.SellerStatus == SellerStatus.Active && x.TenantId.Equals(tenantId) && x.Slug.Equals(slug));

            return result;
        }


        public async Task<List<FeaturedSellerModel>> GetFeaturedSellers(string tenantId, decimal? latitude, decimal? longitude)
        {
            var result = await this._dbContext.Sellers.Select(c => new FeaturedSellerModel
            {
                Slug = c.Slug,
                SellerId = c.SellerId,
                TenantId = c.TenantId,
                Name = c.Name,
                AllowPickup = c.AllowPickup,
                AllowPreOrder = c.AllowPreOrder,
                BaseDeliveryTimeInMinutes = c.BaseDeliveryTimeInMinutes,
                CurrencySymbol = c.CurrencyIsoCode.Equals("PEN") ? "S/" : "",
                BaseShippingCost = c.BaseShippingCost,
                Description = c.Description,
                Rating = c.Rating,
                Logo = c.Logo,
                Banner = c.Banner,
                SellerStatus = c.SellerStatus,
            }).Take(20).Where(c => c.SellerStatus == SellerStatus.Active && c.TenantId.Equals(tenantId)).ToListAsync();

            var products = await this._dbContext.Products
                .Select(c=> new {
                    SellerId = c.SellerId,
                    Name = c.Name,
                    ProductStatus = c.ProductStatus,
                    Files = c.Images.Select(c => new { c.IsPrimary, c.UrlLinkCatalog }).Where(x=> x.IsPrimary)
                })
                .Where(c => result.Select(c => c.SellerId).Contains(c.SellerId) && c.ProductStatus == ProductStatus.Active)
                .ToListAsync();

            foreach (var item in result)
            {
                var productItems = products.Where(c => c.SellerId.Equals(item.SellerId) && c.Files.Count() > 0).ToList();

                if (productItems.Any())
                {
                    item.ViewMode = ViewMode.Products;
                    item.Images = productItems.SelectMany(x => x.Files).Select(p => p.UrlLinkCatalog).Take(2).ToList();
                } else if (!string.IsNullOrEmpty(item.Banner))
                {
                    item.ViewMode = ViewMode.Banner;
                } else
                {
                    item.ViewMode = ViewMode.Basic;
                }
            }

            return result;

        }

        public async Task<List<SellerModel>> GetSellers(string tenantId, string q, decimal? latitude, decimal? longitude)
        {
            var result = await this._dbContext.Sellers.Select(c => new SellerModel
            {
                Slug = c.Slug,
                SellerId = c.SellerId,
                TenantId = c.TenantId,
                Name = c.Name,
                CompanyName = c.CompanyName,
                AllowPickup = c.AllowPickup,
                AllowPreOrder = c.AllowPreOrder,
                AddressLine = "",
                BaseDeliveryTimeInMinutes = c.BaseDeliveryTimeInMinutes,
                BaseLeadTimeInMinutes = c.BaseLeadTimeInMinutes,
                BaseMinimumOrderValue = c.BaseMinimumOrderValue,
                BaseShippingCost = c.BaseShippingCost,
                ContactEmail = c.ContactEmail,
                ContactName = c.ContactName,
                Description = c.Description,
                CountryIsoCode = c.CountryIsoCode,
                CurrencyIsoCode = c.CurrencyIsoCode,
                CurrencySymbol = c.CurrencyIsoCode.Equals("PEN") ? "S/" : "",
                MetaTitle = c.MetaTitle,
                MetaDescription = c.MetaDescription,
                Rating = c.Rating,
                CompanyTaxId = c.CompanyTaxId,
                Logo = c.Logo,
                Phone = c.Phone,
                Banner =  c.Banner,
                SellerStatus = c.SellerStatus
            }).Where(c=> c.SellerStatus == SellerStatus.Active && c.TenantId.Equals(tenantId)).ToListAsync();

            return result;
        }

    }
}
