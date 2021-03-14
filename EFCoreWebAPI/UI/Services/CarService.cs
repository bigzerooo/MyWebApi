using DataAccessLayer.Parameters;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UI.ViewModels;

namespace UI.Services
{
    public class CarService : BaseService
    {
        public CarService(HttpClient httpClient) : base(httpClient) { }

        public async Task<List<CarViewModel>> GetCarsAsync(CarParameters parameters)
        {
            return await httpClient.GetJsonAsync<List<CarViewModel>>("api/car?" +
                $"PageSize={parameters.PageSize}&" +
                $"PageNumber={parameters.PageNumber}&" +
                $"MinPrice={parameters.MinPrice}&" +
                $"Brand={parameters.Brand}&" +
                $"MaxPrice={parameters.MaxPrice}&" +
                $"OrderBy={parameters.OrderBy}");
        }

        public async Task<CarViewModel> GetCarsByIdAsync(int id)
        {
            return await httpClient.GetJsonAsync<CarViewModel>($"api/car/{id}");
        }

        public async Task<HttpResponseMessage> InsertCarAsync(CarViewModel car)
        {
            return await httpClient.PostAsync("api/car", GetStringContentFromObject(car));
        }
        public async Task<int> GetCarCountAsync(CarParameters parameters)
        {
            var respone = await httpClient.GetAsync($"api/car/count?minprice={parameters.MinPrice}&Brand={parameters.Brand}&MaxPrice={parameters.MaxPrice}");
            if (!respone.IsSuccessStatusCode)
                return 0;
            else
                return Int32.Parse(await respone.Content.ReadAsStringAsync());
        }
        public async Task<decimal> CalculatePrice(string id, DateTime expectedEndDate)
        {
            var response = await httpClient.GetAsync($"api/car/{id}");
            if (!response.IsSuccessStatusCode)
                return 0;

            using var responseContent = await response.Content.ReadAsStreamAsync();
            var x = await JsonSerializer.DeserializeAsync<CarViewModel>(responseContent);

            var timeGap = (expectedEndDate - DateTime.Now).TotalSeconds;
            var ExpectedPrice = x.PricePerHour / 3600 * (decimal)timeGap;
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
