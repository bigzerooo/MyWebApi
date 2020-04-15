using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace UI.Services
{
    public class CarService
    {
        public HttpClient _httpClient;
        public CarService(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<List<CarDTO>> GetCarsAsync()
        {
            var response = await _httpClient.GetAsync("api/car");
            response.EnsureSuccessStatusCode();

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<CarDTO>>(responseContent);
        }
        public async Task<CarDTO> GetCarsByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/car/{id}");
            response.EnsureSuccessStatusCode();

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<CarDTO>(responseContent);
        }
    }
}
