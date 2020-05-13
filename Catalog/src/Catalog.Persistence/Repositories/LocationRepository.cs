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
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(CatalogDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

        public async Task<Location> FindLocationById(string tenantId, int id)
        {
            return await this.DbSet.Include(c => c.Seller).FirstOrDefaultAsync(c => c.TenantId.Equals(tenantId) && c.LocationId.Equals(id));
        }

        public PagedResult<Location> FindLocations(string tenantId, int? sellerId, string name, int page, int pageSize)
        {
            var query = this.DbSet.Include(c=> c.Seller).Where(c => c.TenantId.Equals(tenantId) && c.EntityStatus != EntityStatus.Deleted);

            if (sellerId.HasValue && sellerId.Value > 0)
                query = query.Where(c => c.SellerId.Equals(sellerId.Value));

            if (!string.IsNullOrEmpty(name))
                query = query.Where(c => c.Name.StartsWith(name));

            return query.GetPaged(page, pageSize, c => c.CreatedOn, "desc");
        }

    }
}
