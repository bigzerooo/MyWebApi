using Blazored.LocalStorage;
using System.Net.Http;

namespace UI.Services
{
    public abstract class BaseService
    {
        protected readonly HttpClient httpClient;
        protected readonly ILocalStorageService localStorage;

        protected BaseService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
        }
    }
}
