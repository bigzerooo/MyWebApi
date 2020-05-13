using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using UI.ViewModels;

namespace UI.Services
{
    public class CarService
    {
        public HttpClient _httpClient;
        public CarService(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<List<CarViewModel>> GetCarsAsync()
        {
            var response = await _httpClient.GetAsync("api/car");
            if (!response.IsSuccessStatusCode)
                return null;

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<CarViewModel>>(responseContent);
        }
        public async Task<CarViewModel> GetCarsByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/car/{id}");
            if (!response.IsSuccessStatusCode)
                return null;            

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<CarViewModel>(responseContent);
        }
    }
}
