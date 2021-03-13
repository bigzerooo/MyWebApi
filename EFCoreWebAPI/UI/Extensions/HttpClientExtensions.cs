using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace UI.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> DeleteAsync<T>(this HttpClient httpClient, string? requestUri)
        {
            var response = await httpClient.DeleteAsync(requestUri);

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(responseContent);
        }
    }
}
