using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UI.ViewModels;

namespace UI.Services
{
    public class ClientService : BaseService
    {
        public ClientService(HttpClient httpClient) : base(httpClient) { }

        public async Task<ClientViewModel> GetClientsByIdAsync(int id)
        {
            return await httpClient.GetJsonAsync<ClientViewModel>($"api/client/{id}");
        }

        public async Task<HttpResponseMessage> UpdateClientAsync(ClientViewModel client)
        {
            return await httpClient.PutAsync($"api/client", GetStringContentFromObject(client));
        }
        private StringContent GetStringContentFromObject(object obj)
        {
            var serialized = JsonSerializer.Serialize(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }
    }
}
