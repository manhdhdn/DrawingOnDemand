using DrawingOnDemandAPI.GHN.Models;
using System.Text;

namespace DrawingOnDemandAPI.GHN
{
    public class Order
    {
        public static async Task<GHNRequest> Send(GHNRequest request)
        {
            try
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();

                using HttpClient httpClient = new();

                // Full path url
                request.Endpoint = configuration["GHN_Url"] + request.Endpoint;

                // Add shopId and token to header
                var shopId = configuration["GHN_ShopId"];
                var token = configuration["GHN_Token"];

                httpClient.DefaultRequestHeaders.Add("ShopId", shopId);
                httpClient.DefaultRequestHeaders.Add("Token", token);

                StringContent? postData = null;

                if (request.PostJsonString != null)
                {
                    postData = new StringContent(request.PostJsonString, Encoding.UTF8, "application/json");
                }

                HttpResponseMessage response = await httpClient.PostAsync(request.Endpoint, postData);

                //response.EnsureSuccessStatusCode();

                request.PostJsonString = await response.Content.ReadAsStringAsync();
                request.PostJsonString = request.PostJsonString.Remove(request.PostJsonString.Length - 1);

                // Todo parse it
                return request;
            }
            catch (HttpRequestException e)
            {
                request.PostJsonString = e.Message;

                return request;
            }
        }
    }
}
