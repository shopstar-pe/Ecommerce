using System;
using System.ComponentModel.DataAnnotations;

namespace Sales.Domain.Entities
{
    public enum SaleOrderTrackingType
    {
        [Display(Name = "Note")]
        Note,
        [Display(Name = "Confirmed")]
        Confirmed,
        [Display(Name = "InTransit")]
        InTransit,
        [Display(Name = "ReadyToPickUp")]
        ReadyToPickUp,
        [Display(Name = "Cancelled")]
        Cancelled,
        [Display(Name = "Delivered")]
        Delivered,
        [Display(Name = "Closed")]
        Closed,
        [Display(Name = "Email")]
        Email,
        [Display(Name = "SMS")]
        SMS
    }

}
