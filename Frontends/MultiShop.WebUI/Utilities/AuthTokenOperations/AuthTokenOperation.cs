using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using MultiShop.WebUI.Utilities.FileOperations;

namespace MultiShop.WebUI.Utilities.AuthTokenOperations
{
    public class AuthTokenOperation
    {
        public async Task GetAuthTokenForAPI(IHttpClientFactory _httpClientFactory, HttpClient client)
        {
            string token = "";
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://localhost:5001/connect/token"),
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        {"client_id","MultiShopVisitorId"},
                        {"client_secret","multishopsecret" },
                        {"grant_type","client_credentials" }
                    })
                };

                using (var response = await httpClient.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var tokenResponse = JObject.Parse(content);
                        token = tokenResponse["access_token"].ToString();
                    }
                }
            }

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);            
        }
    }
}
