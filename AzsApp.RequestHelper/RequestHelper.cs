using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace AzsApp.RequestHelper
{
    public static class RequestHelper<TModel> where TModel : class, new()
    {
        private static readonly HttpClientHandler clientHandler = new HttpClientHandler 
        { 
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator 
        };

        private static readonly HttpClient _client = new(clientHandler);

        public static async Task<TModel?> GetAsync(string url)
        {
            return await _client.GetFromJsonAsync<TModel>(url);
        }

        public static async Task<bool> PostAsync(TModel model ,string url)
        {
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
            })
            {
                var response = await _client.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
        }

        public static async Task<bool> PutAsync(TModel model, string url)
        {
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url)
            {
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
            })
            {
                var response = await _client.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
        }

        public static async Task<bool> DeleteAsync(string url, TModel model = null!)
        {
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url)
            {
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
            })
            {
                var response = await _client.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
        }
    }
}