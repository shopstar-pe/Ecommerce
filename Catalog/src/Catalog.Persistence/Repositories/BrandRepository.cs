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
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(CatalogDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

        public PagedResult<Brand> FindBrands(string tenantId, string name, BrandStatus? status, int page, int pageSize)
        {
            var query = this.DbSet.Where(c => c.TenantId.Equals(tenantId) && c.EntityStatus != EntityStatus.Deleted);

            if (status.HasValue)
            {
                query = query.Where(c => c.BrandStatus.Equals(status.Value));
            }

            if (!string.IsNullOrEmpty(name))
                query = query.Where(c => c.Name.StartsWith(name));

            return query.GetPaged(page, pageSize, c => c.CreatedOn, "desc");
        }
    }
}
