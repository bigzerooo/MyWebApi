using Blazored.LocalStorage;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UI.ViewModels;

namespace UI.Services
{
    public class CarStateService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        public CarStateService(HttpClient client, ILocalStorageService localStorage)
        {
            _httpClient = client;
            _localStorage = localStorage;
        }
        public async Task<List<CarStateViewModel>> GetCarStatesAsync()
        {
            var response = await _httpClient.GetAsync($"api/carstate");
            if (!response.IsSuccessStatusCode)
                return null;

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<CarStateViewModel>>(responseContent);
        }
        public async Task<string> GetCarStateByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/carstate/{id}");
            if (!response.IsSuccessStatusCode)
                return null;

            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }
        public async Task<HttpResponseMessage> AddCarStateAsync(CarStateViewModel carState)
        {
            string token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.PostAsync($"api/carstate", GetStringContentFromObject(carState));
        }

        public async Task<HttpResponseMessage> UpdateCarStateAsync(CarStateViewModel carState)
        {
            string token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.PutAsync($"api/carstate", GetStringContentFromObject(carState));
        }

        public async Task<HttpResponseMessage> DeleteCarStateAsync(string id)
        {
            string token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.DeleteAsync($"api/carstate/{id}");
        }

        private StringContent GetStringContentFromObject(object obj)
        {
            var serialized = JsonSerializer.Serialize(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            return stringContent;
        }
    }
}
