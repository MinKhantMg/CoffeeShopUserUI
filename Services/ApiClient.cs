using System.Net.Http.Json;
using Microsoft.Extensions.Logging;

namespace CoffeeShopUser.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T1> PostAsync<T1, T2>(string path, T2 postModel)
        {
            var response = await _httpClient.PostAsJsonAsync(path, postModel);
            if (!response.IsSuccessStatusCode)
            {
                return default; // Return default if request fails
            }

            return await response.Content.ReadFromJsonAsync<T1>();
        }

        public async Task<T?> GetFromJsonAsync<T>(string path)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<T>(path);
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public async Task<T?> GetByIdAsync<T>(string path, string id)
        {
            return await GetFromJsonAsync<T>($"{path}/{id}");
        }
    }
}
