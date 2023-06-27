using Blazored.LocalStorage;
using Blazored.SessionStorage;
using EpiConnectFrontEnd.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace EpiConnectFrontEnd.Authentication {
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider {

        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;


        private readonly ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService, HttpClient httpClient,
            NavigationManager navigationManager) {
            _localStorageService = localStorageService;
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
            try {
                var loginSession = await _localStorageService.ReadItemEncryptedAsync<LoginSession>("loginSession");
                if (loginSession == null) {
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                }
               return CreateAuthenticationState(loginSession.Token);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }

        private AuthenticationState CreateAuthenticationState(string token) {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            _navigationManager.NavigateTo("/monitoring");
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt"));
            return new AuthenticationState(claimsPrincipal);
        }

        public Task MarkUserAsAuthenticated(string token) {
            var authState = CreateAuthenticationState(token);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
            return Task.CompletedTask;
        }
        public void MarkUserAsLoggedOut() {
            var authState = Task.FromResult(new AuthenticationState(_anonymous));
            NotifyAuthenticationStateChanged(authState);
        }

        public IEnumerable<Claim> ParseClaimsFromJwt(string? token) {
            var claims = new List<Claim>();
            var payLoad = token.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payLoad);
            var keyValue = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValue!.TryGetValue(ClaimTypes.Role, out object roles);

            if(roles != null) {
                if (roles.ToString()!.Trim().StartsWith("[")) {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString()!);

                    foreach(var parsedRole in parsedRoles!) {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                } else {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()!));
                }
                keyValue.Remove(ClaimTypes.Role);
            }
            claims.AddRange(keyValue.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!)));

            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64) {
            switch (base64.Length % 4) {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
