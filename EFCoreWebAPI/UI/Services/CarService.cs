using Blazored.LocalStorage;
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
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        public CarService(HttpClient client, ILocalStorageService localStorage)
        {
            _httpClient = client;
            _localStorage = localStorage;
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
            //добавление токена в запрос
            string token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            //

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
        public async Task<decimal> CalculatePrice(string id, DateTime expectedEndDate)
        {
            var response = await _httpClient.GetAsync($"api/car/{id}");
            if (!response.IsSuccessStatusCode)
                return 0;

            using var responseContent = await response.Content.ReadAsStreamAsync();
            var x =  await JsonSerializer.DeserializeAsync<CarViewModel>(responseContent);

            var timeGap = (expectedEndDate - DateTime.Now).TotalSeconds;
            var ExpectedPrice = x.pricePerHour / 3600 * (decimal)timeGap;
            return ExpectedPrice;
        }
        private StringContent GetStringContentFromObject(object obj)
        {
            var serialized = JsonSerializer.Serialize(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            return stringContent;
        }
    }
}
