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
   
    public class CollectionRepository : Repository<Collection>, ICollectionRepository
    {
        public CollectionRepository(CatalogDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

        public async Task<Collection> FindCollectionById(string tenantId, int id)
        {
            return await this.DbSet
                            .Include(c => c.Seller)
                            .Include(c => c.ProductCollections)
                            .FirstOrDefaultAsync(c => c.TenantId.Equals(tenantId) && c.CollectionId.Equals(id));
        }

        public PagedResult<Collection> FindCollections(string tenantId, int? sellerId, string name, int page, int pageSize)
        {
            var query = this.DbSet.Include(c => c.Seller).Where(c => c.TenantId.Equals(tenantId) && c.EntityStatus != EntityStatus.Deleted);

            if (sellerId.HasValue && sellerId.Value > 0)
                query = query.Where(c => c.SellerId.Equals(sellerId.Value));

            if (!string.IsNullOrEmpty(name))
                query = query.Where(c => c.Name.StartsWith(name));

            return query.GetPaged(page, pageSize, c => c.CreatedOn, "desc");
        }

        public async Task<List<Product>> FindProductsByCollectionId(string tenantId, int id)
        {
            var query = await this.DbSet
                            .Include(c => c.Seller)
                            .Include(c => c.ProductCollections)
                                .ThenInclude(x => x.Product)
                                    .ThenInclude(z => z.Images)
                            .FirstOrDefaultAsync(c => c.TenantId.Equals(tenantId) && c.CollectionId.Equals(id));

            return query.ProductCollections.Select(c => c.Product).ToList();
        }
    }
}
