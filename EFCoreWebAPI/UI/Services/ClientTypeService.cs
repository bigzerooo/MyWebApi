using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UI.Extensions;
using UI.ViewModels;

namespace UI.Services
{
    public class ClientTypeService : BaseService
    {
        public ClientTypeService(HttpClient httpClient, ILocalStorageService localStorage)
            : base(httpClient, localStorage) { }

        public async Task<IEnumerable<ClientTypeViewModel>> GetClientTypesAsync()
        {
            var result = await httpClient.GetJsonAsync<IEnumerable<ClientTypeViewModel>>("api/clienttype");

            return result;
        }

        public async Task<string> GetClientTypeByIdAsync(int id)
        {
            var result = await httpClient.GetJsonAsync<string>($"api/clienttype/{id}");

            return result;
        }
        public async Task<RequestResultViewModel> AddClientTypeAsync(ClientTypeViewModel clientType)
        {
            string token = await localStorage.GetItemAsync<string>("authToken");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await httpClient.PostJsonAsync<RequestResultViewModel>("api/clienttype", clientType);
        }

        public async Task<RequestResultViewModel> UpdateClientTypeAsync(ClientTypeViewModel clientType)
        {
            string token = await localStorage.GetItemAsync<string>("authToken");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await httpClient.PutJsonAsync<RequestResultViewModel>("api/clienttype", clientType);
        }

        public async Task<RequestResultViewModel> DeleteClientTypeAsync(string id)
        {
            string token = await localStorage.GetItemAsync<string>("authToken");
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            return await httpClient.DeleteAsync<RequestResultViewModel>($"api/clienttype/{id}");
        }
    }
}
