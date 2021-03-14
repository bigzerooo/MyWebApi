using System.Net.Http;

namespace UI.Services
{
    public abstract class BaseService
    {
        protected readonly HttpClient httpClient;

        protected BaseService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
    }
}
