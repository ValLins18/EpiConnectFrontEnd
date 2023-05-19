using EpiConnectFrontEnd.Model;
using Microsoft.AspNetCore.Components;
using System.Text;
using System.Text.Json;

namespace EpiConnectFrontEnd.Services {
    public class LoginService {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        const string BasePath = "https://localhost:7157/api/login";
        public LoginService(HttpClient httpClient, NavigationManager navigationManager) {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }
        public async Task LoginAsync(LoginModel loginModel) {
            var response = await _httpClient.PostAsync(BasePath, new StringContent(JsonSerializer.Serialize(loginModel), Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode) {
                _navigationManager.NavigateTo("/monitoring");
            }
            else {
                _navigationManager.NavigateTo("/");
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
