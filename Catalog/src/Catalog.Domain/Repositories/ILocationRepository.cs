using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Catalog.Domain.Paging;

namespace Catalog.Domain.Repositories
{
    public interface ILocationRepository : IRepository<Location>
    {
        PagedResult<Location> FindLocations(string tenantId, int? sellerId, string name, int page, int pageSize);
        Task<Location> FindLocationById(string tenantId, int id);
    }
}
