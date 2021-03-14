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
        public CarTypeService(HttpClient httpClient) : base(httpClient) { }

        public async Task<IEnumerable<CarTypeViewModel>> GetCarTypesAsync()
        {
            return await httpClient.GetJsonAsync<IEnumerable<CarTypeViewModel>>("api/cartype");
        }
        public async Task<string> GetCarTypeByIdAsync(int id)
        {
            return await httpClient.GetJsonAsync<string>($"api/cartype/{id}");
        }
        public async Task<RequestResultViewModel> AddCarTypeAsync(CarTypeViewModel carType)
        {
            return await httpClient.PostJsonAsync<RequestResultViewModel>("api/cartype", carType);
        }

        public async Task<RequestResultViewModel> UpdateCarTypeAsync(CarTypeViewModel carType)
        {
            return await httpClient.PutJsonAsync<RequestResultViewModel>("api/cartype", carType);
        }

        public async Task<RequestResultViewModel> DeleteCarTypeAsync(string id)
        {
            return await httpClient.DeleteAsync<RequestResultViewModel>($"api/cartype/{id}");
        }
    }
}
