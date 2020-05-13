using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;
using Sales.Domain.Paging;
using Sales.Domain.Repositories;
using Sales.Persistence.Contexts;
using Sales.Persistence.Extensions;

namespace Sales.Persistence.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        
        public ClientRepository(SalesDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

        public async Task<Client> FindClientByEmail(string tenantId, string email)
        {
            return await this.DbSet.Include(c=> c.ClientSellers).FirstOrDefaultAsync(c => c.TenantId.Equals(tenantId) && c.Email.Equals(email));
        }

        public async Task<Client> FindClientById(string tenantId, int id)
        {
            return await this.DbSet.Include(c=> c.SaleOrders)
                                    .ThenInclude(c=> c.SaleOrderItems)
                                .FirstOrDefaultAsync(c => c.TenantId.Equals(tenantId) && c.ClientId.Equals(id));
        }

        public PagedResult<Client> FindClients(string tenantId, string q, int? sellerId, int page, int pageSize)
        {
            var query = this.DbSet.Include(c => c.SaleOrders)
                                    .ThenInclude(c => c.SaleOrderItems)
                                .Where(c => c.TenantId.Equals(tenantId) && c.EntityStatus != EntityStatus.Deleted);

            if (sellerId.HasValue && sellerId.Value > 0)
                query = query.Where(c => c.ClientSellers.Any(x => x.SellerId.Equals(sellerId.Value)));

            if (!string.IsNullOrEmpty(q))
                query = query.Where(c => c.FirstName.StartsWith(q));

            return query.GetPaged(page, pageSize, c => c.CreatedOn, "desc");
        }
    }
}
