using Blazored.LocalStorage;
using BusinessLogicLayer.DTO.Identity.Results;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Threading.Tasks;
using UI.JWT;
using UI.ViewModels;

namespace UI.Services
{
    public class AccountService : BaseService
    {
        private readonly AuthenticationStateProvider authenticationStateProvider;
        private readonly ILocalStorageService localStorage;

        public AccountService(
            HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider,
            ILocalStorageService localStorage) : base(httpClient)
        {
            this.authenticationStateProvider = authenticationStateProvider;
            this.localStorage = localStorage;
        }

        public async Task<IdentityResultViewModel> CreateUserAsync(MyUserRegisterViewModel user)
        {
            return await httpClient.PostJsonAsync<IdentityResultViewModel>("api/account/register", user);
        }

        public async Task<LoginResult> LoginAsync(MyUserLoginViewModel loginModel)
        {
            var result = await httpClient.PostJsonAsync<LoginResult>("api/account/login", loginModel);

            if (result.Successful)
            {
                await localStorage.SetItemAsync("authToken", result.Token);
                ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsAuthenticated(result.Token);
            }

            return result;
        }

        public async Task Logout()
        {
            await localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsLoggedOut();
        }

        public async Task<IdentityResultViewModel> ChangePasswordAsync(MyUserChangePasswordViewModel user)
        {
            return await httpClient.PostJsonAsync<IdentityResultViewModel>("api/account/changepassword", user);
        }
    }
}
