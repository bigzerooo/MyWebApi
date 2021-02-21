using Blazored.LocalStorage;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UI.ViewModels;

namespace UI.Services
{
    public class CarTypeService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        public CarTypeService(HttpClient client, ILocalStorageService localStorage)
        {
            _httpClient = client;
            _localStorage = localStorage;
        }
        public async Task<List<CarTypeViewModel>> GetCarTypesAsync()
        {
            var response = await _httpClient.GetAsync($"api/cartype");
            if (!response.IsSuccessStatusCode)
                return null;

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<CarTypeViewModel>>(responseContent);
        }
        public async Task<string> GetCarTypeByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/cartype/{id}");
            if (!response.IsSuccessStatusCode)
                return null;

            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }
        public async Task<HttpResponseMessage> AddCarTypeAsync(CarTypeViewModel carType)
        {
            string token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.PostAsync($"api/cartype", GetStringContentFromObject(carType));
        }

        public async Task<HttpResponseMessage> UpdateCarTypeAsync(CarTypeViewModel carType)
        {
            string token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.PutAsync($"api/cartype", GetStringContentFromObject(carType));
        }

        public async Task<HttpResponseMessage> DeleteCarTypeAsync(string id)
        {
            string token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.DeleteAsync($"api/cartype/{id}");
        }

        private StringContent GetStringContentFromObject(object obj)
        {
            var serialized = JsonSerializer.Serialize(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            return stringContent;
        }
    }
}
