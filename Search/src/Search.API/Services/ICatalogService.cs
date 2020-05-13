using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Search.API.Models;

namespace Search.API.Services
{
    public interface ICatalogService
    {
        Task<CatalogResultModel> GetCatalog(string tenantId, int sellerId);
        Task<ProductResultModel> GetProducts(string tenantId, int sellerId);
        Task<MealResultModel> GetMeals(string tenantId, int sellerId);
        Task<ProductModel> GetProductById(string tenantId, string slugId);
        Task<List<CategoryModel>> GetCategories(string tenantId);
    }
}
