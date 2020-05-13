using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sales.Application.Abstractions;
using Sales.Application.Commands.SaleOrderCommand.Models;
using Sales.Domain.Entities;
using Sales.Domain.Exceptions;
using Sales.Domain.Repositories;

namespace Sales.Application.Commands.SaleOrderCommand
{
    public class CreateSaleOrderCommand : IRequest<CommandResult>
    {
        [Required]
        public string OrderType { get; set; }
        public string Source { get; set; }
        public string CheckOutId { get; set; }
        public string TransactionId { get; set; }
        public string CouponCode { get; set; }
        public decimal Shipping { get; set; }
        public decimal Discount { get; set; }
        [Required]
        public string CountryIsoCode { get; set; }
        [Required]
        public string CurrencyIsoCode { get; set; }
        [Required]
        public ClientModel Customer { get; set; }
        public ShippingAddressModel ShippingAddress { get; set; }
        [Required]
        public List<SaleOrderItemModel> Items { get; set; }

        public class Handler : IRequestHandler<CreateSaleOrderCommand, CommandResult>
        {
            readonly IClientRepository _repository;
            readonly IUserIdentityService _userIdentityService;

            public Handler(IClientRepository repository, IUserIdentityService userIdentityService)
            {
                this._repository = repository;
                this._userIdentityService = userIdentityService;
            }

            public async Task<CommandResult> Handle(CreateSaleOrderCommand request, CancellationToken cancellationToken)
            {
                var userId = this._userIdentityService.GetUserId();
                var tenantId = this._userIdentityService.GetTenantId();

                var isNewClient = false;

                var client = await this._repository.FindClientByEmail(tenantId, request.Customer.Email);

                if (client == null)
                {
                    client = Client.Factory.Create(tenantId, request.Customer.Email, request.Customer.FirstName, request.Customer.LastName, request.Customer.Phone, request.Customer.IdentificationNumber, request.Customer.IdentificationType, request.Customer.EntityName, userId);
                    isNewClient = true;
                }

                var orderGroup = DateTime.UtcNow.Ticks.ToString();

                var cont = 0;
                foreach (var item in request.Items.GroupBy(x => x.SellerId))
                {
                    cont++;
                    var orderItems = item.Where(c => c.SellerId.Equals(item.Key));
                    var sellerId = orderItems.ElementAt(0).SellerId;
                    var sellerName = orderItems.ElementAt(0).SellerName;

                    client.AssociateToSeller(sellerId);

                    var orderType = 1;
                    if (request.OrderType.Equals("boleta"))
                        orderType = 1;
                    else if (request.OrderType.Equals("factura"))
                        orderType = 2;

                    var order = client.CreateOrder(tenantId, orderType, sellerId, sellerName, request.Source, orderGroup, request.CountryIsoCode, request.CurrencyIsoCode, request.CouponCode);

                    if (orderType == 2)
                    {
                        order.EntityName = request.Customer.EntityName;
                        order.EntityIdentificationNumber = request.Customer.EntityIdentificationNumber;
                    }

                    order.CheckOutId = request.CheckOutId;
                    order.TransactionId = request.TransactionId;

                    order.ShippingFirstName = request.ShippingAddress.FirstName;
                    order.ShippingLastName = request.ShippingAddress.LastName;
                    order.ShippingAddressLine = request.ShippingAddress.AddressLine;
                    order.ShippingAddressNumber = request.ShippingAddress.AddressNumber;
                    order.ShippingDepartment = request.ShippingAddress.Department;
                    order.ShippingProvince = request.ShippingAddress.Province;
                    order.ShippingDistrict = request.ShippingAddress.District;
                    order.ShippingPhone = request.ShippingAddress.Phone;
                    order.ShippingReference = request.ShippingAddress.Reference;
                    order.ShippingCountryIsoCode = request.ShippingAddress.CountryIsoCode;
                    order.ShippingPostalCode = request.ShippingAddress.PostalCode;

                    foreach (var orderItem in orderItems)
                    {
                        var finalPrice = orderItem.SpecialPrice < orderItem.BasePrice ? orderItem.SpecialPrice : orderItem.BasePrice;
                        var total = orderItem.Quantity * finalPrice;
                        var services = new List<SaleOrderItemService>();

                        if (orderItem.Services != null)
                        {
                            services = orderItem.Services.Select(c => new SaleOrderItemService
                            {
                                ServiceId = c.Id,
                                Name = c.Name,
                                BasePrice = c.BasePrice,
                                SpecialPrice = c.SpecialPrice,
                                FinalPrice  = c.SpecialPrice < c.BasePrice ? c.SpecialPrice : c.BasePrice
                            }).ToList();
                        }

                        order.AddItems(orderItem.ProductId,
                            orderItem.SkuId,
                            orderItem.ProductName,
                            orderItem.SKU,
                            orderItem.ProductImage,
                            orderItem.Weight,
                            orderItem.BasePrice,
                            orderItem.SpecialPrice,
                            finalPrice,
                            orderItem.Quantity,
                            orderItem.Discount,
                            total,
                            services);
                    }

                    decimal subTotal = order.SaleOrderItems.Sum(c => c.Total);
                    decimal orderItemServiceTotals = order.SaleOrderItems.Sum(c => c.Services.Sum(x => x.FinalPrice));
                    decimal shippingTotal = request.Shipping;
                    decimal discountTotal = request.Discount;

                    order.SubTotal = subTotal + orderItemServiceTotals;
                    order.Shipping = shippingTotal;
                    order.Tax = 0;
                    order.Discount = discountTotal;
                    order.Total = order.SubTotal + order.Discount + order.Shipping + order.ServiceFee + order.Tips;

                    order.AddTracking(SaleOrderTrackingType.Note, "Pedido creado con éxito.", userId);
                }

                if (isNewClient)
                    this._repository.Add(client);
                else
                    this._repository.Update(client);

                await this._repository.SaveChanges();

                return new CommandResult { Id = client.SaleOrders.FirstOrDefault(c=> c.OrderGroup.Equals(orderGroup)).SaleOrderId.ToString() };
            }
        }
    }
}
