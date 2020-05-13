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
    public class CancelService : ICancelService
    {
        private readonly VisaNetSecurityTokenService _visaNetSecurityTokenService;

        public CancelService(VisaNetSecurityTokenService visaNetSecurityTokenService)
        {
            this._visaNetSecurityTokenService = visaNetSecurityTokenService;
        }

        public async Task<CancelResponseModel> Cancel(CancelRequestModel request)
        {
            var securityUrl = request.Settings["SecurityUrl"];
            var userName = request.Settings["UserName"];
            var password = request.Settings["Password"];
            var voidUrl = request.Settings["VoidUrl"];
            var merchantId = request.Settings["MerchantId"];

            var token = await this._visaNetSecurityTokenService.GetToken(securityUrl, userName, password);

            var requestMessage = new
            {
                order = new
                {
                    purchaseNumber = request.OrderNumber,
                    transactionDate = request.TransactionDate.ToString("yyyyMMdd")
                }
            };

            var headers = new Dictionary<string, string>();
            headers.Add("authorization", token);

            using (var proxy = new HttpClient())
            {
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{voidUrl}/reverse/ecommerce/{merchantId}");

                foreach (var h in headers)
                {
                    httpRequest.Headers.TryAddWithoutValidation(h.Key, h.Value);
                }

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(requestMessage);

                httpRequest.Content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await proxy.SendAsync(httpRequest);

                if (response.IsSuccessStatusCode)
                {
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<CancelResultModel>(await response.Content.ReadAsStringAsync());

                    var result = new CancelResponseModel
                    {
                        Success = true
                    };

                    return result;
                }

                var errorData = Newtonsoft.Json.JsonConvert.DeserializeObject<CancelFailedResultModel>(await response.Content.ReadAsStringAsync());

                return new CancelResponseModel
                {
                    Success = false,
                    Errors = new List<TransactionErrorResponseModel> {
                        new TransactionErrorResponseModel{ Code = errorData.ErrorCode, Message = errorData.ErrorMessage }
                    }
                };

            }
        }
    }
}
