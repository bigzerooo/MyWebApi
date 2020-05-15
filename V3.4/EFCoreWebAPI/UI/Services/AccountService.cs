using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UI.ViewModels;

namespace UI.Services
{
    public class AccountService
    {
        public HttpClient _httpClient;
        public AccountService(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<HttpResponseMessage> CreateUserAsync(MyUserRegisterViewModel user)
        {
            return await _httpClient.PostAsync("api/account/register", GetStringContentFromObject(user));
        }
        private StringContent GetStringContentFromObject(object obj)
        {
            var serialized = JsonSerializer.Serialize(obj);
            var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            return stringContent;
        }
    }
}
