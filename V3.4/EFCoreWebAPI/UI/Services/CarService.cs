using BusinessLogicLayer.DTO;
using DataAccessLayer.Parameters;
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
    public class CarService
    {
        public HttpClient _httpClient;
        public CarService(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<List<CarViewModel>> GetCarsAsync(CarParameters parameters)
        {
            var response = await _httpClient.GetAsync($"api/car?PageSize={parameters.PageSize}&PageNumber={parameters.PageNumber}&MinPrice={parameters.MinPrice}&Brand={parameters.Brand}&MaxPrice={parameters.MaxPrice}&OrderBy={parameters.OrderBy}");            
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
        public async Task<HttpResponseMessage> InsertCarAsync(CarViewModel car)
        {
            return await _httpClient.PostAsync("api/car", GetStringContentFromObject(car));
        }
        public async Task<int> GetCarCountAsync(CarParameters parameters)
        {
            var respone = await _httpClient.GetAsync($"api/car/count?minprice={parameters.MinPrice}&Brand={parameters.Brand}&MaxPrice={parameters.MaxPrice}");
            if (!respone.IsSuccessStatusCode)
                return 0;
            else
                return Int32.Parse(await respone.Content.ReadAsStringAsync()); 
        }
        private StringContent GetStringContentFromObject(object obj)
        {
            var serialized = JsonSerializer.Serialize(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }
    }
}
