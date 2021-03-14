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
        public ClientTypeService(HttpClient httpClient) : base(httpClient) { }

        public async Task<IEnumerable<ClientTypeViewModel>> GetClientTypesAsync()
        {
            return await httpClient.GetJsonAsync<IEnumerable<ClientTypeViewModel>>("api/clienttype");
        }

        public async Task<string> GetClientTypeByIdAsync(int id)
        {
            return await httpClient.GetJsonAsync<string>($"api/clienttype/{id}");
        }
        public async Task<RequestResultViewModel> AddClientTypeAsync(ClientTypeViewModel clientType)
        {
            return await httpClient.PostJsonAsync<RequestResultViewModel>("api/clienttype", clientType);
        }

        public async Task<RequestResultViewModel> UpdateClientTypeAsync(ClientTypeViewModel clientType)
        {
            return await httpClient.PutJsonAsync<RequestResultViewModel>("api/clienttype", clientType);
        }

        public async Task<RequestResultViewModel> DeleteClientTypeAsync(string id)
        {
            return await httpClient.DeleteAsync<RequestResultViewModel>($"api/clienttype/{id}");
        }
    }
}
