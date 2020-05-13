using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Entities
{
    public enum ProductStatus
    {
        Active = 1,
        Inactive = 0
    }

    public enum SkuStatus
    {
        Active = 1,
        Inactive = 0
    }

    public enum ProductSyncStatus {
        Enqueued,
        Publishing,
        Published,
        Failed
    }
}
