using System;
using System.ComponentModel.DataAnnotations;

namespace Sales.Domain.Entities
{
    

    public enum SaleOrderShippingStatus
    {
        [Display(Name = "Pendiente")]
        Nothing,
        [Display(Name = "Entregado")]
        Shipped,
    }
}
