using System;
using System.Net.Http.Json;
using GlobalFinance.Client.Providers;
using GlobalFinance.Client.ServicesInterfaces;
using GlobalFinance.Shared.Models;
using static System.Net.WebRequestMethods;

namespace GlobalFinance.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorage;
        private readonly AuthenticationStateProvider authStateProvider;

        public AuthService(HttpClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
        {
            this.httpClient = httpClient;
            this.localStorage = localStorage;
            this.authStateProvider = authStateProvider;
        }

        public async Task<int> LoginUser(UserDto userDto)
        {

            var result = await httpClient.PostAsJsonAsync("auth/login", userDto);
            if (!result.IsSuccessStatusCode)
            {
                return 1;
            }
            else
            {
                var token = await result.Content.ReadAsStringAsync();
                await localStorage.SetItemAsync("token", token);
                await authStateProvider.GetAuthenticationStateAsync();
                return 0;
            }
        }

        public async Task<int> RegisterUser(UserDto userDto)
        {
            var result = await httpClient.PostAsJsonAsync("auth/register", userDto);
            if (!result.IsSuccessStatusCode)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public async Task LogOutUser()
        {
            await localStorage.RemoveItemAsync("token");
        }
    }
}

