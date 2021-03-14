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
        public CarStateService(HttpClient httpClient) : base(httpClient) { }

        public async Task<IEnumerable<CarStateViewModel>> GetCarStatesAsync()
        {
            return await httpClient.GetJsonAsync<IEnumerable<CarStateViewModel>>("api/carstate");
        }

        public async Task<string> GetCarStateByIdAsync(int id)
        {
            return await httpClient.GetJsonAsync<string>($"api/carstate/{id}");
        }

        public async Task<RequestResultViewModel> AddCarStateAsync(CarStateViewModel carState)
        {
            return await httpClient.PostJsonAsync<RequestResultViewModel>("api/carstate", carState);
        }

        public async Task<RequestResultViewModel> UpdateCarStateAsync(CarStateViewModel carState)
        {
            return await httpClient.PutJsonAsync<RequestResultViewModel>("api/carstate", carState);
        }

        public async Task<RequestResultViewModel> DeleteCarStateAsync(string id)
        {
            return await httpClient.DeleteAsync<RequestResultViewModel>($"api/carstate/{id}");
        }
    }
}
