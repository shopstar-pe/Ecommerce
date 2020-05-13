using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Payments.Application.Abstractions;
using Payments.Application.Abstractions.Models;
using Payments.Integration.VisaNet.Models;

namespace Payments.Integration.VisaNet
{
    public class CaptureService : ICaptureService
    {
        private readonly VisaNetSecurityTokenService _visaNetSecurityTokenService;

        public CaptureService(VisaNetSecurityTokenService visaNetSecurityTokenService)
        {
            this._visaNetSecurityTokenService = visaNetSecurityTokenService;
        }

        public async Task<CaptureResponseModel> Capture(CaptureRequestModel request)
        {
            var securityUrl = request.Settings["SecurityUrl"];
            var userName = request.Settings["UserName"];
            var password = request.Settings["Password"];
            var confirmationUrl = request.Settings["ConfirmationUrl"];
            var merchantId = request.Settings["MerchantId"];

            var token = await this._visaNetSecurityTokenService.GetToken(securityUrl, userName, password);

            var requestMessage = new
            {
                channel = "web",
                captureType = "manual",
                order = new
                {
                    purchaseNumber = request.OrderNumber,
                    amount = request.Amount,
                    authorizedAmount = request.AuthorizedAmount,
                    currency = request.CurrencyIsoCode,
                    transactionId = request.TransactionId
                }
            };

            var headers = new Dictionary<string, string>();
            headers.Add("authorization", token);

            using (var proxy = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{confirmationUrl}/confirmation/ecommerce/{merchantId}");

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

                    var result = new CaptureResponseModel
                    {
                        Success = true
                    };

                    return result;
                }

                var errorData = Newtonsoft.Json.JsonConvert.DeserializeObject<CaptureFailedResultModel>(await response.Content.ReadAsStringAsync());

                return new CaptureResponseModel
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
