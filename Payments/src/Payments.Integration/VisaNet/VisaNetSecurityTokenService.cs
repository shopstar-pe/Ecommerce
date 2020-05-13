using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Integration.VisaNet
{
    public class VisaNetSecurityTokenService
    {
        public async Task<string> GetToken(string tokenUrl, string userName, string password)
        {
            using (var proxy = new HttpClient())
            {
                var token = Convert.ToBase64String(Encoding.Default.GetBytes($"{userName}:{password}"));

                var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{tokenUrl}/security");
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", token);

                var response = await proxy.SendAsync(httpRequest);

                return await response.Content.ReadAsStringAsync();
            }
               
        }
    }
}
