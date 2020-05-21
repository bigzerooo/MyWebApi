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
    public class CarHiresService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        public CarHiresService(HttpClient client, ILocalStorageService localStorage)
        {
            _httpClient = client;
            _localStorage = localStorage;
        }
        public async Task<List<CarHireViewModel>> GetCarHiresAsync()
        {
            string token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"api/carhire");
            if (!response.IsSuccessStatusCode)
                return null;

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<CarHireViewModel>>(responseContent);
        }
        public async Task<List<CarHireViewModel>> GetCarHiresByClientIdAsync(string clientId)
        {
            string token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"api/carhire/client/{clientId}");
            if (!response.IsSuccessStatusCode)
                return null;

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<CarHireViewModel>>(responseContent);
        }
        public async Task<List<CarHireViewModel>> GetUnreturnedCarHiresByClientIdAsync(string clientId)
        {
            string token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"api/carhire/unreturned/{clientId}");
            if (!response.IsSuccessStatusCode)
                return null;

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<CarHireViewModel>>(responseContent);
        }
        //public async Task<string> GetCarTypeByIdAsync(int id)
        //{
        //    var response = await _httpClient.GetAsync($"api/cartype/{id}");
        //    if (!response.IsSuccessStatusCode)
        //        return null;

        //    var responseContent = await response.Content.ReadAsStringAsync();
        //    return responseContent;
        //}
        public async Task<HttpResponseMessage> ReturnCarAsync(string id,string carStateId)
        {
            string token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);            
            return await _httpClient.PostAsync($"api/carhire/return", GetStringContentFromObject(new CarHireViewModel(){ id = Int32.Parse(id), carStateId = Int32.Parse(carStateId) })); ;
        }
        public async Task<HttpResponseMessage> HireTheCarAsync(string carId, string clientId, DateTime expectedEndDate)
        {
            string token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.PostAsync($"api/carhire/hire", GetStringContentFromObject(new CarHireViewModel { carId=Int32.Parse(carId), clientId=Int32.Parse(clientId), expectedEndDate= expectedEndDate}));
        }

        //public async Task<HttpResponseMessage> UpdateCarTypeAsync(CarTypeViewModel carType)
        //{
        //    string token = await _localStorage.GetItemAsync<string>("authToken");
        //    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        //    return await _httpClient.PutAsync($"api/cartype", GetStringContentFromObject(carType));
        //}

        //public async Task<HttpResponseMessage> DeleteCarTypeAsync(string id)
        //{
        //    string token = await _localStorage.GetItemAsync<string>("authToken");
        //    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        //    return await _httpClient.DeleteAsync($"api/cartype/{id}");
        //}

        private StringContent GetStringContentFromObject(object obj)
        {
            var serialized = JsonSerializer.Serialize(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            return stringContent;
        }
    }
}
