using System;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.API.Models;
using Ecommerce.API.Proxy;
using Ecommerce.API.Proxy.Models;

namespace Ecommerce.API.Services
{
    public class PlaceOrderService : IPlaceOrderService
    {
        readonly ICheckOutProxyService _checkOutProxyService;
        readonly IOrderProxyService _orderProxyService;
        readonly IPaymentProxyService _paymentProxyService;
        readonly IShippingProxyService _shippingProxyService;

        public PlaceOrderService(ICheckOutProxyService checkOutProxyService,
            IOrderProxyService orderProxyService,
            IPaymentProxyService paymentProxyService,
            IShippingProxyService shippingProxyService)
        {
            this._checkOutProxyService = checkOutProxyService;
            this._orderProxyService = orderProxyService;
            this._paymentProxyService = paymentProxyService;
            this._shippingProxyService = shippingProxyService;
        }

        public async Task<OrderResultModel> DoPlace(PlaceOrderModel placeOrder)
        {
            var checkOut = await this._checkOutProxyService.GetCheckOutById(placeOrder.CheckOutId, placeOrder.SellerId);

            if (checkOut == null)
                throw new Exception();

            // Get Shipping Cost
            var shippingResult = await this._shippingProxyService.GetShippingCost(new ShippingRequestModel
            {

            });

            // Place Order
            var orderRequest = MapPlaceOrderToOrderRequest(checkOut, placeOrder, shippingResult.Cost);
            var orderResult = await this._orderProxyService.CreateOrder(orderRequest);

            if (!orderResult.Success)
                throw new Exception();

            if (placeOrder.Payment.PaymentMethodGroupName.Equals("creditcard", StringComparison.OrdinalIgnoreCase))
            {
                // Authorize Order
                var auhtorizeRequest = MapOrderToAuthorizeRequest(orderResult.Order, placeOrder);
                var autorizeResult = await this._paymentProxyService.Authorize(auhtorizeRequest);

                if (!autorizeResult.Success)
                    throw new Exception();
            }

            return new OrderResultModel
            {
                OrderId = orderResult.Order.SaleOrderId,
                OrderGroup = orderResult.Order.OrderGroup,
                OrderNumber = orderResult.Order.OrderNumber
            };
        }

        private OrderRequestModel MapPlaceOrderToOrderRequest(CheckOutModel checkOut, PlaceOrderModel placeOrder, decimal shippingCost)
        {
            var model = new OrderRequestModel
            {
                TransactionId = Guid.NewGuid().ToString(),
                CheckOutId = placeOrder.CheckOutId,
                OrderType = placeOrder.OrderType,
                CountryIsoCode = placeOrder.CountryIsoCode ?? checkOut.CountryIsoCode,
                CurrencyIsoCode = placeOrder.CurrencyIsoCode ?? checkOut.CurrencyIsoCode,
                CouponCode = checkOut.CouponCode,
                Source = placeOrder.Source,
                ShippingCost = shippingCost,
                Customer = new ClienRequestModel
                {
                    FirstName = placeOrder.Contact.FirstName,
                    LastName = placeOrder.Contact.LastName,
                    Email = placeOrder.Contact.Email,
                    IdentificationType = placeOrder.Contact.IdentificationType,
                    IdentificationNumber = placeOrder.Contact.IdentificationNumber,
                    Phone = placeOrder.Contact.Phone,
                    EntityIdentificationNumber = checkOut.CustomerEntityIdentificationNumber,
                    EntityName = checkOut.CustomerEntityName
                },
                ShippingAddress = new ShippingAddressRequestModel
                {
                    FirstName = placeOrder.Shipping.Receptor.FirstName,
                    LastName = placeOrder.Shipping.Receptor.LastName,
                    IdentificationNumber = placeOrder.Shipping.Receptor.IdentificationNumber,
                    IdentificationType = placeOrder.Shipping.Receptor.IdentificationType,
                    AddressLine = placeOrder.Shipping.AddressLine,
                    AddressNumber = placeOrder.Shipping.AddressNumber,
                    Latitude = placeOrder.Shipping.Latitude,
                    Longitude = placeOrder.Shipping.Longitude,
                    PostalCode = placeOrder.Shipping.PostalCode,
                    CellPhone = placeOrder.Shipping.Receptor.Phone,
                    Phone = placeOrder.Shipping.Receptor.Phone,
                    CountryIsoCode = checkOut.CountryIsoCode,
                    Department = placeOrder.Shipping.Department,
                    Province = placeOrder.Shipping.Province,
                    District = placeOrder.Shipping.District,
                    Reference = placeOrder.Shipping.Reference
                },
                Items = checkOut.Items.Select(x => new SaleOrderItemRequestModel
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    SkuId = x.SkuId,
                    SKU = x.SKU,
                    BasePrice = x.BasePrice,
                    SpecialPrice = x.SpecialPrice,
                    SellerId = x.SellerId,
                    SellerName = x.SellerName,
                    Discount = x.Discount,
                    AdditionalNote = x.AdditionalNote,
                    ProductImage = x.ProductImage,
                    Quantity = x.Quantity,
                    Tax = 0,
                    Weight = x.Weight
                }).ToList()
            };

            return model;
        }

        private AuthorizeRequestModel MapOrderToAuthorizeRequest(OrderResponseModel order, PlaceOrderModel placeOrder)
        {
            var model = new AuthorizeRequestModel
            {
                TransactionId = order.TransactionId,
                FirstName = order.Client.FirstName,
                LastName = order.Client.LastName,
                Email = order.Client.Email,
                IdentificationType = order.Client.IdentificationType,
                IdentificationNumber = order.Client.IdentificationNumber,
                PhoneNumber = order.Client.Phone,
                Amount = order.Total,
                CountryIsoCode = order.CountryIsoCode,
                CurrencyIsoCode = order.CurrencyIsoCode,
                OrderId = order.SaleOrderId,
                OrderGroup = order.OrderGroup,
                OrderNumber = order.SaleOrderId.ToString("D8"),
                SellerId = order.SellerId,
                SellerName = order.SellerName,
                Placeholder = placeOrder.Payment.Card.Placeholder,
                CardNumber = placeOrder.Payment.Card.CardNumber,
                Year = placeOrder.Payment.Card.Year,
                Month = placeOrder.Payment.Card.Month,
                Cvv = placeOrder.Payment.Card.Cvv,
                Installments = placeOrder.Payment.Card.Installments == 0 ? 1 : placeOrder.Payment.Card.Installments
            };

            
            return model;
        }
    }
}
