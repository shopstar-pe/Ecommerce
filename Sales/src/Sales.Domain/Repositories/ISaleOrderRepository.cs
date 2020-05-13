using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sales.Domain.Entities;
using Sales.Domain.Paging;

namespace Sales.Domain.Repositories
{
    public interface ISaleOrderRepository : IRepository<SaleOrder>
    {
        Task<SaleOrder> FindOrderById(string tenantId, int id);
        Task<List<SaleOrderTracking>> FindTrackingsById(string tenantId, int id);
        Task<SaleOrder> FindOrderByOrderNumber(string tenantId, string orderNumber);
        PagedResult<SaleOrder> FindOrders(string tenantId, int? sellerId, string orderNumber, List<SaleOrderStatus> salesOrderStatus, DateTime? saleOrderDateStart, DateTime? saleOrderDateEnd, int page, int pageSize);
        Task<List<SaleOrder>> ExportOrders(string tenantId, int? sellerId, string orderNumber, DateTime? saleOrderDateStart, DateTime? saleOrderDateEnd);
        Task<List<SaleOrder>> FindOrdersByGroup(string tenantId, string orderGroup);
        Task<dynamic> GetStats(string tenantId, int? sellerId, DateTime? transactionDateStart, DateTime? transactionDateEnd);
    }
}
