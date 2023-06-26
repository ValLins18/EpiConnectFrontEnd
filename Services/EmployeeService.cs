using EpiConnectFrontEnd.Model;
using EpiConnectFrontEnd.Model.ViewModel;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace EpiConnectFrontEnd.Services {
    public class EmployeeService : IEmployeeService {
        const string BaseUrl = "https://epiconnectapi.azurewebsites.net/api/Employee";
        private readonly HttpClient _httpClient;
        public EmployeeService(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<EmployeeMonitoringViewModel[]> GetEmployeesForMonitoringAsync() {
            var response = await _httpClient.GetFromJsonAsync<EmployeeMonitoringViewModel[]>($"{BaseUrl}/Monitoring");
            return response;
        }
        public async Task<EmployeeModel> GetEmployeeByIdAsync(int personId) {
            var response = await _httpClient.GetFromJsonAsync<EmployeeModel>($"{BaseUrl}/{personId}");
            return response;
        }
    }
}
