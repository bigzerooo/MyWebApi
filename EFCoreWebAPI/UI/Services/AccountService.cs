using Blazored.LocalStorage;
using BusinessLogicLayer.DTO.Identity.Results;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UI.JWT;
using UI.ViewModels;

namespace UI.Services
{
    public class AccountService : BaseService
    {
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public AccountService(
            HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider,
            ILocalStorageService localStorage):base (httpClient, localStorage)
        {
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<IdentityResultViewModel> CreateUserAsync(MyUserRegisterViewModel user)
        {
            var result = await httpClient.PostJsonAsync<IdentityResultViewModel>("api/account/register", user);

            return result;
        }

        public async Task<LoginResult> LoginAsync(MyUserLoginViewModel loginModel)
        {
            var result = await httpClient.PostJsonAsync<LoginResult>("api/account/login", loginModel);

            //пересмотреть
            if (result.Successful)
            {
                await localStorage.SetItemAsync("authToken", $"{result.Token}");
                ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsAuthenticated(result.Token);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
            }

            return result;
        }

        public async Task Logout()
        {
            //пересмотреть
            await localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsLoggedOut();
            httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<IdentityResultViewModel> ChangePasswordAsync(MyUserChangePasswordViewModel user)
        {
            //пересмотреть
            string token = await localStorage.GetItemAsync<string>("authToken");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await httpClient.PostJsonAsync<IdentityResultViewModel>("api/account/changepassword", user);
        }
    }
}
