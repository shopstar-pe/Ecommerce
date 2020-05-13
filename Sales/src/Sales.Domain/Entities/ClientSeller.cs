using System;
namespace Sales.Domain.Entities
{
    public class ClientSeller
    {
        public int SellerId { get; set; }

        public int ClientId { get; set; }
        public virtual Client Cliente { get; set; }
    }
}
