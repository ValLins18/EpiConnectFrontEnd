using EpiConnectFrontEnd.Model;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace EpiConnectFrontEnd.Services {
    public class EmployeeService : IEmployeeService {
        const string BaseUrl = "https://localhost:7157/api/Employee";
        private readonly HttpClient _httpClient;
        public EmployeeService(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<EmployeeModel[]> GetEmployeesAsync() {
            var response = await _httpClient.GetFromJsonAsync<EmployeeModel[]>(BaseUrl);
            return response;
        }
        public async Task<EmployeeModel> GetEmployeeByIdAsync(int personId) {
            var response = await _httpClient.GetFromJsonAsync<EmployeeModel>($"{BaseUrl}/{personId}");
            return response;
        }
    }
}
