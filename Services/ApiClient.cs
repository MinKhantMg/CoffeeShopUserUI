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
                Console.WriteLine($"[ERROR] POST {path} failed with status {response.StatusCode}");
                return default!;
            }

            return await response.Content.ReadFromJsonAsync<T1>() ?? default!;
        }

        public async Task<T?> GetFromJsonAsync<T>(string path)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<T>(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] GET {path} failed: {ex.Message}");
                return default;
            }
        }

        public async Task<T?> GetByIdAsync<T>(string path, string id)
        {
            return await GetFromJsonAsync<T>($"{path}/{id}");
        }

        public async Task<T1> PutAsync<T1, T2>(string path, T2 putModel)
        {
            var response = await _httpClient.PutAsJsonAsync(path, putModel);

            if (response == null)
            {
                Console.WriteLine("[ERROR] PUT response is null.");
                return default!;
            }

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"[ERROR] PUT {path} failed with status {response.StatusCode}");
                return default!;
            }

            return await response.Content.ReadFromJsonAsync<T1>() ?? default!;
        }

        public async Task DeleteAsync(string path)
        {
            var response = await _httpClient.DeleteAsync(path);
            response.EnsureSuccessStatusCode();
        }

    }

    public class ApiResponse
    {
        public bool Result { get; set; }
    }
}
