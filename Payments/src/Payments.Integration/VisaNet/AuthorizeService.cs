using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Payments.Application.Abstractions;
using Payments.Application.Abstractions.Models;
using Payments.Integration.VisaNet.Models;

namespace Payments.Integration.VisaNet
{
    public class AuthorizeService : IAuthorizeService
    {
        readonly VisaNetSecurityTokenService _visaNetSecurityTokenService;
        public AuthorizeService(VisaNetSecurityTokenService visaNetSecurityTokenService)
        {
            this._visaNetSecurityTokenService = visaNetSecurityTokenService;
        }

        public async Task<AuthorizeResponseModel> Authorize(AuthorizeRequestModel request)
        {
            var securityUrl = request.Settings.GetValueOrDefault("SecurityUrl");
            var userName = request.Settings.GetValueOrDefault("UserName");
            var password = request.Settings.GetValueOrDefault("Password");
            var authorizeUrl = request.Settings.GetValueOrDefault("AuthorizeUrl");
            var merchantId = request.Settings.GetValueOrDefault("MerchantId");
            var channel = request.Settings.GetValueOrDefault("Channel");
            var captureType = request.Settings.GetValueOrDefault("CaptureType");
            var countable = Convert.ToBoolean(request.Settings.GetValueOrDefault("Countable"));

            var token = await this._visaNetSecurityTokenService.GetToken(securityUrl, userName, password);

            var identificationType = "";

            if (request.IdentificationType.Equals("dni", StringComparison.OrdinalIgnoreCase))
            {
                identificationType = "0";
            }
            else if (request.IdentificationType.Equals("pasaporte", StringComparison.OrdinalIgnoreCase))
            {
                identificationType = "2";
            }
            else
            {
                identificationType = "1";
            }

            var requestMessage = new
            {
                channel = channel,
                captureType = captureType,
                countable = countable,
                order = new
                {
                    purchaseNumber = request.OrderNumber,
                    amount = request.Amount,
                    installment = request.Installments,
                    currency = request.CurrencyIsoCode,
                    externalTransactionId = request.TransactionId
                },
                card = new
                {
                    cardNumber = request.CardNumber,
                    expirationMonth = request.Month,
                    expirationYear = $"20{request.Year}",
                    cvv2 = request.Cvv
                },
                cardHolder = new
                {
                    firstName = request.PlaceHolder.Split(' ')[0],
                    lastName = request.PlaceHolder.Split(' ')[1],
                    email = request.Email,
                    phoneNumber = request.PhoneNumber,
                    documentType = identificationType,
                    documentNumber = request.IdentificationNumber
                }

            };

            var headers = new Dictionary<string, string>();
            headers.Add("authorization", token);

            using (var proxy = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{authorizeUrl}/authorization/ecommerce/{merchantId}");

                foreach (var h in headers)
                {
                    httpRequest.Headers.TryAddWithoutValidation(h.Key, h.Value);
                }

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestMessage);

                httpRequest.Content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await proxy.SendAsync(httpRequest);

                if (response.IsSuccessStatusCode)
                {
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<AuthorizeResultModel>(await response.Content.ReadAsStringAsync());

                    var result = new AuthorizeResponseModel
                    {
                        Success = false
                    };

                    if (data.DataMap.ECI.Equals("07") || data.DataMap.ECI.Equals("05"))
                    {
                        var transactionDate = DateTime.ParseExact(data.DataMap.TRANSACTION_DATE.ToString(), "yyMMddHHmmss", CultureInfo.InvariantCulture);

                        result.Success = true;
                        result.TransactionId = data.Order.TransactionId;
                        result.TransationDate = transactionDate;
                        result.AuthCode = data.Order.AuthorizationCode;
                        result.Amount = data.Order.Amount;
                        result.AuthorizedAmount = data.Order.AuthorizedAmount;
                        result.OrderNumber = data.Order.PurchaseNumber;

                        result.PlaceHolder = $"{requestMessage.cardHolder.firstName} {requestMessage.cardHolder.lastName}";
                        result.CardNumber = data.DataMap.CARD;
                        result.Month = requestMessage.card.expirationMonth;
                        result.Year = requestMessage.card.expirationYear;
                        result.CardType = data.DataMap.BRAND;
                    }
                    else
                    {
                        result.Errors = new List<TransactionErrorResponseModel> {
                        new TransactionErrorResponseModel{ Code = data.DataMap.ECI, Message = data.DataMap.ECI_DESCRIPTION }
                    };
                    }

                    return result;

                }

                if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
                {
                    return new AuthorizeResponseModel
                    {
                        Success = false,
                        Errors = new List<TransactionErrorResponseModel> {
                    new TransactionErrorResponseModel { Code = "-1", Message = "BadGateway" }
                }
                    };
                }

                var jsonError = await response.Content.ReadAsStringAsync();

                var errorData = Newtonsoft.Json.JsonConvert.DeserializeObject<AuthorizeFailedResultModel>(jsonError);

                return new AuthorizeResponseModel
                {
                    Success = false,
                    Errors = new List<TransactionErrorResponseModel> {
                    new TransactionErrorResponseModel{ Code = errorData.ErrorCode, Message = $"Code: ({errorData.Data.ACTION_CODE}) {errorData.Data.ACTION_DESCRIPTION}. {errorData.ErrorMessage}" }
                }
                };
            }
        }
    }
}
