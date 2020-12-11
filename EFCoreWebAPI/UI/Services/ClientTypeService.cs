using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UI.ViewModels;

namespace UI.Services
{
    public class ClientTypeService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        public ClientTypeService(HttpClient client, ILocalStorageService localStorage)
        {
            _httpClient = client;
            _localStorage = localStorage;
        }
        public async Task<List<ClientTypeViewModel>> GetClientTypesAsync()
        {
            var response = await _httpClient.GetAsync($"api/clienttype");
            if (!response.IsSuccessStatusCode)
                return null;

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<ClientTypeViewModel>>(responseContent);
        }
        public async Task<string> GetClientTypeByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/clienttype/{id}");
            if (!response.IsSuccessStatusCode)
                return null;

            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }
        public async Task<HttpResponseMessage> AddClientTypeAsync(ClientTypeViewModel clientType)
        {
            string token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.PostAsync($"api/clienttype", GetStringContentFromObject(clientType));
        }

        public async Task<HttpResponseMessage> UpdateClientTypeAsync(ClientTypeViewModel clientType)
        {
            string token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.PutAsync($"api/clienttype", GetStringContentFromObject(clientType));
        }

        public async Task<HttpResponseMessage> DeleteClientTypeAsync(string id)
        {
            string token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.DeleteAsync($"api/clienttype/{id}");
        }

        private StringContent GetStringContentFromObject(object obj)
        {
            var serialized = JsonSerializer.Serialize(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            return stringContent;
        }
    }
}
