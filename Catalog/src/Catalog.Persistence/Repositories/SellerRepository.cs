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
    public class SellerRepository : Repository<Seller>, ISellerRepository
    {
        public SellerRepository(CatalogDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

        public async Task<Seller> FindSellerById(string tenantId, int id)
        {
            return await this.DbSet.Include(c => c.Locations)
                .FirstOrDefaultAsync(c => c.TenantId.Equals(tenantId) && c.SellerId.Equals(id));
        }

        public PagedResult<Seller> FindSellers(string tenantId, string name, int page, int pageSize)
        {
            var query = this.DbSet.Where(c => c.TenantId.Equals(tenantId) && c.EntityStatus != EntityStatus.Deleted);

            if (!string.IsNullOrEmpty(name))
                query = query.Where(c => c.Name.StartsWith(name));

            return query.GetPaged(page, pageSize, c => c.CreatedOn, "desc");
        }
    }
}
