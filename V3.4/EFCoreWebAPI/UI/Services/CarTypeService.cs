using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using UI.ViewModels;

namespace UI.Services
{
    public class CarTypeService
    {
        public HttpClient _httpClient;
        public CarTypeService(HttpClient client)
        {
            _httpClient = client;
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
    }
}
