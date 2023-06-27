using EpiConnectFrontEnd.Model;
using EpiConnectFrontEnd.Model.ViewModel;
using System.Net;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace EpiConnectFrontEnd.Services {
    public class EmployeeService : IEmployeeService {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public EmployeeService(HttpClient httpClient, IConfiguration configuration) {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<EmployeeMonitoringViewModel[]> GetEmployeesForMonitoringAsync() {
            var response = await _httpClient.GetFromJsonAsync<EmployeeMonitoringViewModel[]>($"{_configuration["Endpoints:baseUrl"]}/api/Employee/Monitoring");
            return response;
        }
        public async Task<EmployeeModel> GetEmployeeByIdAsync(int personId) {
            var response = await _httpClient.GetFromJsonAsync<EmployeeModel>($"{_configuration["Endpoints:baseUrl"]}/api/Employee/{personId}");
            return response;
        }
    }
}
