using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UI.ViewModels;

namespace UI.Services
{
    public class NewsService : BaseService
    {
        public NewsService(HttpClient httpClient) : base(httpClient) { }

        public async Task<List<NewViewModel>> GetNewsAsync()
        {
            return await httpClient.GetJsonAsync<List<NewViewModel>>("api/news");
        }

        public async Task<HttpResponseMessage> AddNewsAsync(NewViewModel news)
        {
            return await httpClient.PostAsync($"api/news", GetStringContentFromObject(news));
        }
        private StringContent GetStringContentFromObject(object obj)
        {
            var serialized = JsonSerializer.Serialize(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");

            return stringContent;
        }
        public async Task<HttpResponseMessage> DeleteNewsAsync(string id)
        {
            return await httpClient.DeleteAsync($"api/news/{id}");
        }
    }
}
