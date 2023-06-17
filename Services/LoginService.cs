using Blazored.LocalStorage;
using EpiConnectFrontEnd.Authentication;
using EpiConnectFrontEnd.Extensions;
using EpiConnectFrontEnd.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace EpiConnectFrontEnd.Services {
    public class LoginService {
        private readonly HttpClient _httpClient;
        private readonly CustomAuthenticationStateProvider _authencationStateProvider;
        private readonly ILocalStorageService _localStorageService;
        const string BasePath = "https://localhost:5001/api/login/token";
        public LoginService(CustomAuthenticationStateProvider authencationStateProvider, HttpClient httpClient, NavigationManager navigationManager, ILocalStorageService localStorageService) {
            _authencationStateProvider = authencationStateProvider;
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }
        public async Task<LoginSession> LoginAsync(LoginModel loginModel) {
            var response = await _httpClient.PostAsync(BasePath, new StringContent(JsonSerializer.Serialize(loginModel), Encoding.UTF8, "application/json"));
            var loginSession = JsonSerializer.Deserialize<LoginSession>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if(!response.IsSuccessStatusCode) {
                return loginSession;
            }
            await _localStorageService.SaveItemEncryptedAsync<LoginSession>("loginSession", loginSession);
            _authencationStateProvider.MarkUserAsAuthenticated(loginModel.Email!);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginSession.Token);

            return loginSession;
        }

        public async Task LogOut() {
            await _localStorageService.RemoveItemAsync("loginSession");
            _authencationStateProvider.MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
