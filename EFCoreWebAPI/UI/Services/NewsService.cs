using Blazored.LocalStorage;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UI.ViewModels;

namespace UI.Services
{
    public class NewsService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        public NewsService(HttpClient client, ILocalStorageService localStorage)
        {
            _httpClient = client;
            _localStorage = localStorage;
        }
        public async Task<List<NewViewModel>> GetNewsAsync()
        {
            var response = await _httpClient.GetAsync($"api/news");
            if (!response.IsSuccessStatusCode)
                return null;

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<NewViewModel>>(responseContent);
        }
        public async Task<HttpResponseMessage> AddNewsAsync(NewViewModel news)
        {
            string token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.PostAsync($"api/news", GetStringContentFromObject(news));
        }
        private StringContent GetStringContentFromObject(object obj)
        {
            var serialized = JsonSerializer.Serialize(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            return stringContent;
        }
        public async Task<HttpResponseMessage> DeleteNewsAsync(string id)
        {
            string token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.DeleteAsync($"api/news/{id}");
        }
    }
}
