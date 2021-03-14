using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UI.Extensions;
using UI.ViewModels;

namespace UI.Services
{
    public class CarTypeService : BaseService
    {
        public CarTypeService(HttpClient httpClient, ILocalStorageService localStorage)
            : base(httpClient, localStorage) { }

        public async Task<IEnumerable<CarTypeViewModel>> GetCarTypesAsync()
        {
            var result = await httpClient.GetJsonAsync<IEnumerable<CarTypeViewModel>>("api/cartype");

            return result;
        }
        public async Task<string> GetCarTypeByIdAsync(int id)
        {
            var result = await httpClient.GetJsonAsync<string>($"api/cartype/{id}");

            return result;
        }
        public async Task<RequestResultViewModel> AddCarTypeAsync(CarTypeViewModel carType)
        {
            string token = await localStorage.GetItemAsync<string>("authToken");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await httpClient.PostJsonAsync<RequestResultViewModel>("api/cartype", carType);
        }

        public async Task<RequestResultViewModel> UpdateCarTypeAsync(CarTypeViewModel carType)
        {
            string token = await localStorage.GetItemAsync<string>("authToken");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await httpClient.PutJsonAsync<RequestResultViewModel>("api/cartype", carType);
        }

        public async Task<RequestResultViewModel> DeleteCarTypeAsync(string id)
        {
            string token = await localStorage.GetItemAsync<string>("authToken");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await httpClient.DeleteAsync<RequestResultViewModel>($"api/cartype/{id}");
        }
    }
}
