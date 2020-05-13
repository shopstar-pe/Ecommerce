using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Catalog.Domain.Paging;

namespace Catalog.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        PagedResult<Product> FindProducts(string tenantId, ProductType? productType, int? sellerId, string name, int? brandId, int? categoryId, int page, int pageSize);
        Task<List<Product>> ExportProducts(string tenantId, int? sellerId, string name, int? brandId, int? categoryId);
        Task<Product> FindProductById(string tenantId, int productId);
        Task<Product> FindProductByName(string tenantId, int sellerId, string name);
        Task<List<Product>> FindProductBySlugs(string tenantId, int sellerId, List<string> slugs);
        Task<Product> FindProductBySlug(string tenantId, int sellerId, string slug);
        Task<List<Product>> FindProductByIds(string tenantId, List<int> productIds);
        Task<dynamic> GetStats(string tenantId, int? sellerId);
    }
}
