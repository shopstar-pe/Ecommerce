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
    public class AdditionalServiceRepository : Repository<AdditionalService>, IAdditionalServiceRepository
    {
        public AdditionalServiceRepository(CatalogDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

        public async Task<AdditionalService> FindAdditionalServiceById(string tenantId, int id)
        {
            return await this.DbSet.Include(c => c.Seller)
                                .Include(c => c.AdditionalServicePrices)
                                .FirstOrDefaultAsync(c => c.TenantId.Equals(tenantId) && c.AdditionalServiceId.Equals(id));
        }

        public PagedResult<AdditionalService> FindAdditionalServices(string tenantId, int? sellerId, string name, int page, int pageSize)
        {
            var query = this.DbSet.Include(c => c.Seller).Where(c => c.TenantId.Equals(tenantId) && c.EntityStatus != EntityStatus.Deleted);

            if (sellerId.HasValue && sellerId.Value > 0)
                query = query.Where(c => c.SellerId.Equals(sellerId.Value));

            if (!string.IsNullOrEmpty(name))
                query = query.Where(c => c.Name.StartsWith(name));

            return query.GetPaged(page, pageSize, c => c.CreatedOn, "desc");
        }

        public async Task<List<AdditionalService>> FindAdditionalServicesBySellerId(int sellerId)
        {
            return await this.DbSet.Include(c=> c.Seller)
                    .Include(c => c.AdditionalServicePrices).Where(c => c.SellerId.Equals(sellerId)).ToListAsync();
        }

        public async Task<List<AdditionalServicePrice>> FindPricesByAdditionalServiceId(int id)
        {
            var query = await this.DbSet
                            .Include(c => c.Seller)
                            .Include(c => c.AdditionalServicePrices)
                            .FirstOrDefaultAsync(c => c.AdditionalServiceId.Equals(id));

            return query.AdditionalServicePrices.ToList();
        }

    }

}
