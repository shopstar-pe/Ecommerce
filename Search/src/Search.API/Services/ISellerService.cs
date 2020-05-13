using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Search.API.Models;

namespace Search.API.Services
{
    public interface ISellerService
    {
        Task<List<SellerModel>> GetSellers(string tenantId, string q, decimal? latitude, decimal? longitude);
        Task<List<FeaturedSellerModel>> GetFeaturedSellers(string tenantId, decimal? latitude, decimal? longitude);
        Task<SellerModel> GetSellerById(string tenantId, string slug);
    }
}
