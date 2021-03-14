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
    public class CarHiresService : BaseService
    {
        public CarHiresService(HttpClient client) : base(client) { }

        public async Task<List<CarHireViewModel>> GetCarHiresAsync()
        {
            return await httpClient.GetJsonAsync<List<CarHireViewModel>>("api/carhire");
        }

        public async Task<List<CarHireViewModel>> GetCarHiresByClientIdAsync(string clientId)
        {
            return await httpClient.GetJsonAsync<List<CarHireViewModel>>($"api/carhire/client/{clientId}");
        }

        public async Task<List<CarHireViewModel>> GetUnreturnedCarHiresByClientIdAsync(string clientId)
        {
            return await httpClient.GetJsonAsync<List<CarHireViewModel>>($"api/carhire/unreturned/{clientId}");
        }

        public async Task<HttpResponseMessage> ReturnCarAsync(string id, string carStateId)
        {
            return await httpClient.PostAsync($"api/carhire/return", GetStringContentFromObject(new CarHireViewModel() { Id = Int32.Parse(id), CarStateId = Int32.Parse(carStateId) })); ;
        }
        public async Task<HttpResponseMessage> HireTheCarAsync(string carId, string clientId, DateTime expectedEndDate)
        {
            return await httpClient.PostAsync($"api/carhire/hire", GetStringContentFromObject(new CarHireViewModel { CarId = Int32.Parse(carId), ClientId = Int32.Parse(clientId), ExpectedEndDate = expectedEndDate }));
        }

        private StringContent GetStringContentFromObject(object obj)
        {
            var serialized = JsonSerializer.Serialize(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            return stringContent;
        }
    }
}
