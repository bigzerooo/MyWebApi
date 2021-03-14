using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UI.Extensions;
using UI.ViewModels;

namespace UI.Services
{
    public class CarStateService : BaseService
    {
        public CarStateService(HttpClient httpClient, ILocalStorageService localStorage)
            : base(httpClient, localStorage) { }

        public async Task<IEnumerable<CarStateViewModel>> GetCarStatesAsync()
        {
            var result = await httpClient.GetJsonAsync<IEnumerable<CarStateViewModel>>("api/carstate");

            return result;
        }
        public async Task<string> GetCarStateByIdAsync(int id)
        {
            var result = await httpClient.GetJsonAsync<string>($"api/carstate/{id}");

            return result;
        }
        public async Task<RequestResultViewModel> AddCarStateAsync(CarStateViewModel carState)
        {
            string token = await localStorage.GetItemAsync<string>("authToken");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await httpClient.PostJsonAsync<RequestResultViewModel>("api/carstate", carState);
        }

        public async Task<RequestResultViewModel> UpdateCarStateAsync(CarStateViewModel carState)
        {
            string token = await localStorage.GetItemAsync<string>("authToken");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await httpClient.PutJsonAsync<RequestResultViewModel>("api/carstate", carState);
        }

        public async Task<RequestResultViewModel> DeleteCarStateAsync(string id)
        {
            string token = await localStorage.GetItemAsync<string>("authToken");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await httpClient.DeleteAsync<RequestResultViewModel>($"api/carstate/{id}");
        }
    }
}
