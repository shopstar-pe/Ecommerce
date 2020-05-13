using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Catalog.Domain.Paging;

namespace Catalog.Domain.Repositories
{
    public interface IAdditionalServiceRepository : IRepository<AdditionalService>
    {
        PagedResult<AdditionalService> FindAdditionalServices(string tenantId, int? sellerId, string name, int page, int pageSize);
        Task<List<AdditionalService>> FindAdditionalServicesBySellerId(int sellerId);
        Task<AdditionalService> FindAdditionalServiceById(string tenantId, int id);
        Task<List<AdditionalServicePrice>> FindPricesByAdditionalServiceId(int id);
    }
}
