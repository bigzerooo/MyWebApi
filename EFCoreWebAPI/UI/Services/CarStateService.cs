using Blazored.LocalStorage;
using BusinessLogicLayer.DTO.Results;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UI.ViewModels;
using UI.Extensions;

namespace UI.Services
{
    public class CarStateService : BaseService
    {
        public CarStateService(HttpClient httpClient, ILocalStorageService localStorage) 
            : base(httpClient, localStorage) { }

        public async Task<IEnumerable<CarStateViewModel>> GetCarStatesAsync()
        {
            var result = await httpClient.GetJsonAsync<IEnumerable<CarStateViewModel>>($"api/carstate");
            
            return result;
        }
        public async Task<string> GetCarStateByIdAsync(int id)
        {
            var result = await httpClient.GetJsonAsync<string>($"api/carstate/{id}");
            
            return result;
        }
        public async Task<RequestResultDTO> AddCarStateAsync(CarStateViewModel carState)
        {
            string token = await localStorage.GetItemAsync<string>("authToken");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await httpClient.PostJsonAsync<RequestResultDTO>($"api/carstate", carState);
        }

        public async Task<RequestResultDTO> UpdateCarStateAsync(CarStateViewModel carState)
        {
            string token = await localStorage.GetItemAsync<string>("authToken");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await httpClient.PutJsonAsync<RequestResultDTO>($"api/carstate", carState);
        }

        public async Task<RequestResultDTO> DeleteCarStateAsync(string id)
        {
            string token = await localStorage.GetItemAsync<string>("authToken");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await httpClient.DeleteAsync<RequestResultDTO>($"api/carstate/{id}");
        }
    }
}
