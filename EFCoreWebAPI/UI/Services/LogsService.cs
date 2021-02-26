using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using UI.ViewModels;

namespace UI.Services
{
    public class LogsService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        public LogsService(HttpClient client, ILocalStorageService localStorage)
        {
            _httpClient = client;
            _localStorage = localStorage;
        }
        public async Task<List<LogViewModel>> GetLogsAsync()
        {
            string token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"api/logs");
            if (!response.IsSuccessStatusCode)
                return null;

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<LogViewModel>>(responseContent);
        }
    }
}
