using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UI.ViewModels;

namespace UI.Services
{
    public class LogsService : BaseService
    {
        public LogsService(HttpClient httpClient) : base(httpClient) { }

        public async Task<List<LogViewModel>> GetLogsAsync()
        {
            return await httpClient.GetJsonAsync<List<LogViewModel>>("api/logs");
        }
    }
}
