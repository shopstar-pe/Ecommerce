using System;
using System.Collections.Generic;
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
    public class SaleOrderRepository : Repository<SaleOrder>, ISaleOrderRepository
    {
        public SaleOrderRepository(SalesDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

        public async Task<SaleOrder> FindOrderById(string tenantId, int id)
        {
            return await this.DbSet
                            .Include(c => c.Client)
                            .Include(c=> c.SaleOrderItems)
                            .Include(c => c.Trackings).FirstOrDefaultAsync(c => c.TenantId.Equals(tenantId) && c.SaleOrderId.Equals(id) && c.EntityStatus != EntityStatus.Deleted);
        }

        public async Task<SaleOrder> FindOrderByOrderNumber(string tenantId, string orderNumber)
        {
            return await this.DbSet
                            .Include(c => c.Client)
                            .Include(c => c.SaleOrderItems)
                            .Include(c => c.Trackings).FirstOrDefaultAsync(c => c.OrderNumber.Equals(orderNumber) && c.EntityStatus != EntityStatus.Deleted);
        }

        public PagedResult<SaleOrder> FindOrders(string tenantId, int? sellerId, string orderNumber, List<SaleOrderStatus> salesOrderStatus, DateTime? saleOrderDateStart, DateTime? saleOrderDateEnd, int page, int pageSize)
        {
            var query = this.DbSet
                            .Include(c => c.Client)
                            .Where(c => c.TenantId.Equals(tenantId) && c.EntityStatus != EntityStatus.Deleted);

            if (sellerId.HasValue && sellerId.Value > 0)
                query = query.Where(c => c.SellerId.Equals(sellerId));

            if (!string.IsNullOrEmpty(orderNumber))
                query = query.Where(c => c.OrderNumber.StartsWith(orderNumber));

            if (saleOrderDateStart.HasValue)
                query = query.Where(c => c.OrderDate >= saleOrderDateStart.Value);

            if (saleOrderDateEnd.HasValue)
                query = query.Where(c => c.OrderDate <= saleOrderDateEnd.Value);

            if (salesOrderStatus !=null && salesOrderStatus.Count > 0)
            {
                query = query.Where(c => salesOrderStatus.Contains(c.SaleOrderStatus));
            }

            return query.GetPaged(page, pageSize, c => c.CreatedOn, "desc");
        }

        public async Task<List<SaleOrder>> FindOrdersByGroup(string tenantId, string orderGroup)
        {
            return await this.DbSet
                            .Include(c => c.Client)
                            .Include(c=> c.SaleOrderItems)
                            .Where(c => c.TenantId.Equals(tenantId) && c.OrderGroup.Equals(orderGroup, StringComparison.OrdinalIgnoreCase) && c.EntityStatus != EntityStatus.Deleted).ToListAsync();
        }

        public async Task<List<SaleOrderTracking>> FindTrackingsById(string tenantId, int id)
        {
            var order = await this.DbSet
                             .Include(c => c.Trackings)
                             .FirstOrDefaultAsync(c => c.TenantId.Equals(tenantId) && c.SaleOrderId.Equals(id) && c.EntityStatus != EntityStatus.Deleted);

            return order.Trackings.ToList();
        }

        public async Task<List<SaleOrder>> ExportOrders(string tenantId, int? sellerId, string orderNumber, DateTime? saleOrderDateStart, DateTime? saleOrderDateEnd)
        {
            var query = this.DbSet
                              .Include(c => c.Client)
                              .Include(c=> c.SaleOrderItems)
                              .Where(c => c.TenantId.Equals(tenantId) && c.EntityStatus != EntityStatus.Deleted);

            if (sellerId.HasValue && sellerId.Value > 0)
                query = query.Where(c => c.SellerId.Equals(sellerId));

            if (!string.IsNullOrEmpty(orderNumber))
                query = query.Where(c => c.OrderNumber.Equals(orderNumber));

            if (saleOrderDateStart.HasValue)
                query = query.Where(c => c.OrderDate >= saleOrderDateStart.Value);

            if (saleOrderDateEnd.HasValue)
                query = query.Where(c => c.OrderDate <= saleOrderDateEnd.Value);

            return await query.ToListAsync();
        }

        public async Task<dynamic> GetStats(string tenantId, int? sellerId, DateTime? transactionDateStart, DateTime? transactionDateEnd)
        {
            var query = this.DbSet
                            .Include(c=> c.Client)
                            .Include(c=> c.SaleOrderItems)
                            .Where(c => c.TenantId.Equals(tenantId) && c.EntityStatus != EntityStatus.Deleted);

            if (transactionDateStart.HasValue)
            {
                query = query.Where(c => c.OrderDate >= transactionDateStart.Value);
            }

            if (transactionDateEnd.HasValue)
            {
                query = query.Where(c => c.OrderDate <= transactionDateEnd.Value);
            }

            if (sellerId.HasValue && sellerId.Value > 0)
            {
                query = query.Where(c => c.SellerId.Equals(sellerId.Value));
            }

            var orderByStatus = await query.GroupBy(c => c.SaleOrderStatus)
               .Select(c => new {
                   SaleOrderStatus = c.Key,
                   SaleOrderStatusName = c.Key.ToString(),
                   Total = c.Sum(x => x.Total),
                   Count = c.Count()
               })
               .ToListAsync();

            var countOrders = await query.CountAsync();
            var totalOrders = await query.SumAsync(c => c.Total);
            var avgOrders = await query.AverageAsync(c => c.Total);

            var lastOrders = await query.Take(10).Select(c => new {
                TransactionId = c.TransactionId,
                SaleOrderDate = c.OrderDate,

                SaleOrderId = c.SaleOrderId,
                OrderNumber = c.OrderNumber,

                SaleOrderStatus = c.SaleOrderStatus,
                Client = $"{c.Client.FirstName} {c.Client.LastName}",

                Shipping = c.Shipping,
                Total = c.Total,
                UpdatedOn = c.UpdatedOn
            }).OrderByDescending(c => c.UpdatedOn).ToListAsync();

            var ordersByDates = await query.GroupBy(c => c.OrderDate.Date)
               .Select(c => new {
                   SaleOrderDate = c.Key,
                   Total = c.Sum(x => x.Total),
                   Count = c.Count()
               })
               .ToListAsync();

            var productOrders = await query.SelectMany(x=> x.SaleOrderItems).GroupBy(c => c.ProductId)
               .Select(c => new {
                   ProductId = c.Key,
                   Name = c.FirstOrDefault().ProductName,
                   Qty = c.Sum(x => x.Quantity),
                   Total = c.Sum(x => x.Total),
                   Count = c.Count()
               }).OrderByDescending(c=> c.Total)
               .ToListAsync();

            return new
            {
                countOrders = countOrders,
                totalOrders = totalOrders,
                productOrders = productOrders,
                avgOrders = avgOrders,
                ordersByDates = ordersByDates,
                transactionByStatus = orderByStatus,
                lastTransactions = lastOrders
            };
        }
    }
}
