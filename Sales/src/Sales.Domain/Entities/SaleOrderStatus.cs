using System;
using System.ComponentModel.DataAnnotations;

namespace Sales.Domain.Entities
{
    public enum SaleOrderStatus
    {
        [Display(Name = "Nuevo")]
        New,
        [Display(Name = "Confirmado")]
        Confirmed,
        [Display(Name = "Preparando")]
        InProgress,
        [Display(Name = "Listo para Recojer")]
        ReadyToPickUp,
        [Display(Name = "En transito")]
        InTransit,
        [Display(Name = "Entregado")]
        Delivered,
        [Display(Name = "Entregado (parcial)")]
        PartialDelivered,
        [Display(Name = "Cerrado")]
        Closed,
        [Display(Name = "Cancelado")]
        Cancelled,
        [Display(Name = "Invalido")]
        Invalid
    }


    public enum SaleOrderItemStatus
    {
        [Display(Name = "Nuevo")]
        New,
        [Display(Name = "Confirmado")]
        Confirmed,
        [Display(Name = "Listo para Enviar")]
        ReadyToShip,
        [Display(Name = "Entregado")]
        Delivered,
        [Display(Name = "Cancelado")]
        Cancel
    }
}
