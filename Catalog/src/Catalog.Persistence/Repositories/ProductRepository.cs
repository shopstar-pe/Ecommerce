using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Catalog.Domain.Paging;
using Catalog.Domain.Repositories;
using Catalog.Persistence.Contexts;
using Catalog.Persistence.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CatalogDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

        public async Task<List<Product>> ExportProducts(string tenantId, int? sellerId, string name, int? brandId, int? categoryId)
        {
            var query = this.DbSet.Include(c => c.Seller)
                 .Include(x => x.Images)
                                     .Include(c => c.Skus)
                                         .ThenInclude(x => x.Images)
                                     .Include(c => c.Brand)
                                     .Include(c => c.ProductCategories)
                                         .ThenInclude(x => x.Category)
                                     .Where(c => c.TenantId.Equals(tenantId) && c.EntityStatus != EntityStatus.Deleted);

            if (sellerId.HasValue && sellerId.Value > 0)
                query = query.Where(c => c.SellerId.Equals(sellerId.Value));

            if (brandId.HasValue)
                query = query.Where(c => c.BrandId.Equals(brandId.Value));

            if (categoryId.HasValue)
                query = query.Where(c => c.ProductCategories.Any(x => x.CategoryId.Equals(categoryId.Value)));

            if (!string.IsNullOrEmpty(name))
                query = query.Where(c => c.Name.StartsWith(name));

            return await query.ToListAsync();
        }

        public async Task<Product> FindProductById(string tenantId, int productId)
        {
            return await this.DbSet.Include(c => c.Seller)
                                    .Include(c => c.Images)
                                    .Include(c => c.Attributes)
                                    .Include(c => c.Skus)
                                        .ThenInclude(x => x.Attributes)
                                    .Include(c => c.Skus)
                                        .ThenInclude(x => x.Images)
                                    .Include(c => c.Skus)
                                        .ThenInclude(x => x.Inventories)
                                            .ThenInclude(z => z.Location)
                                    .Include(c => c.Skus)
                                        .ThenInclude(x => x.SkuAdditionalServicePrices)
                                            .ThenInclude(z => z.AdditionalServicePrice)
                                                .ThenInclude(w => w.AdditionalService)
                                    .Include(c => c.Brand)
                                    .Include(c => c.ProductCategories)
                                        .ThenInclude(x => x.Category)
                                    .FirstOrDefaultAsync(c => c.TenantId.Equals(tenantId) && c.ProductId.Equals(productId) && c.EntityStatus != EntityStatus.Deleted);
        }

        public async Task<List<Product>> FindProductByIds(string tenantId, List<int> productIds)
        {
            return await this.DbSet.Include(c => c.Seller)
                                     .Include(c => c.Skus)
                                     .Where(c => c.TenantId.Equals(tenantId) && c.Skus.Any(x => productIds.Contains(x.ProductId)) && c.EntityStatus != EntityStatus.Deleted)
                                     .ToListAsync();
        }

        public async Task<Product> FindProductByName(string tenantId, int sellerId, string name)
        {
            return await this.DbSet.Include(c => c.Seller)
                                   .Include(c => c.Images)
                                   .Include(c => c.Skus)
                                       .ThenInclude(x => x.Images)
                                   .Include(c => c.Brand)
                                   .Include(c => c.ProductCategories)
                                   .FirstOrDefaultAsync(c => c.TenantId.Equals(tenantId) && c.SellerId.Equals(sellerId) && c.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && c.EntityStatus != EntityStatus.Deleted);
        }

        public async Task<Product> FindProductBySlug(string tenantId, int sellerId, string slug)
        {
            return await this.DbSet.Include(c => c.Seller)
                                   .Include(c => c.Images)
                                   .Include(c => c.Attributes)
                                   .Include(c => c.Skus)
                                       .ThenInclude(x => x.Attributes)
                                   .Include(c => c.Skus)
                                       .ThenInclude(x => x.Images)
                                   .Include(c => c.Skus)
                                       .ThenInclude(x => x.Inventories)
                                           .ThenInclude(z => z.Location)
                                   .Include(c => c.Skus)
                                       .ThenInclude(x => x.SkuAdditionalServicePrices)
                                           .ThenInclude(z => z.AdditionalServicePrice)
                                               .ThenInclude(w => w.AdditionalService)
                                   .Include(c => c.Brand)
                                   .Include(c => c.ProductCategories)
                                       .ThenInclude(x => x.Category)
                                   .FirstOrDefaultAsync(c => c.TenantId.Equals(tenantId) && c.SellerId.Equals(sellerId) && c.Slug.Equals(slug) && c.EntityStatus != EntityStatus.Deleted);
        }

        public async Task<List<Product>> FindProductBySlugs(string tenantId, int sellerId, List<string> slugs)
        {
            return await this.DbSet.Include(c => c.Seller)
                                     .Include(c => c.Images)
                                   .Include(c => c.Skus)
                                       .ThenInclude(x => x.Images)
                                   .Include(c => c.Brand)
                                   .Include(c => c.ProductCategories)
                                   .Where(c => c.TenantId.Equals(tenantId) && c.SellerId.Equals(sellerId) && slugs.Contains(c.Slug) && c.EntityStatus != EntityStatus.Deleted).ToListAsync();
        }

        public PagedResult<Product> FindProducts(string tenantId, ProductType? productType, int? sellerId, string name, int? brandId, int? categoryId, int page, int pageSize)
        {
            var query = this.DbSet.Include(c => c.Seller)
                                    .Include(c => c.Attributes)
                                     .Include(c => c.Images)
                                    .Include(c => c.Skus).ThenInclude(x => x.Images)
                                    .Include(c => c.Skus).ThenInclude(x => x.SkuAdditionalServicePrices)
                                   .Include(c => c.Brand)
                                   .Include(c => c.ProductCategories)
                                    .ThenInclude(x => x.Category)
                                   .Where(c => c.TenantId.Equals(tenantId) && c.EntityStatus != EntityStatus.Deleted);

            if (sellerId.HasValue && sellerId.Value > 0)
                query = query.Where(c => c.SellerId.Equals(sellerId.Value));

            if (productType.HasValue)
                query = query.Where(c => c.ProductType == productType);

            if (brandId.HasValue)
                query = query.Where(c => c.BrandId.Equals(brandId.Value));

            if (categoryId.HasValue)
                query = query.Where(c => c.ProductCategories.Any(x => x.CategoryId.Equals(categoryId.Value)));

            if (!string.IsNullOrEmpty(name))
                query = query.Where(c => c.Name.StartsWith(name));

            return query.GetPaged(page, pageSize, c => c.CreatedOn, "desc");
        }

        public async Task<dynamic> GetStats(string tenantId, int? sellerId)
        {
            var query = this.DbSet.Where(c => c.TenantId.Equals(tenantId) && c.EntityStatus != EntityStatus.Deleted);

            if (sellerId.HasValue && sellerId.Value > 0)
            {
                query = query.Where(c => c.SellerId.Equals(sellerId.Value));
            }

            var lastProducts = await query.Take(10).Select(c => new
            {
                ProductId = c.ProductId,
                Name = c.Name,
                BasePrice = c.BasePrice,
                UpdatedOn = c.UpdatedOn
            }).OrderByDescending(c => c.UpdatedOn).ToListAsync();

            return new
            {
                lastProducts = lastProducts
            };
        }
    }
}
