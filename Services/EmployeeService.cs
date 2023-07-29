using EpiConnectFrontEnd.Model;
using EpiConnectFrontEnd.Model.ViewModel;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
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
            try {
                var response = await _httpClient.GetFromJsonAsync<EmployeeMonitoringViewModel[]>($"{_configuration["Endpoints:baseUrl"]}/api/Employee/Monitoring");
                return response;
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return new EmployeeMonitoringViewModel[] { new EmployeeMonitoringViewModel() };
            }

            //var response = await _httpClient.GetAsync($"{_configuration["Endpoints:baseUrl"]}/api/Employee/Monitoring");
            //if(response.IsSuccessStatusCode) { 
            //    var stringResult = await response.Content.ReadAsStringAsync();
            //    var result = JsonSerializer.Deserialize<EmployeeMonitoringViewModel[]>(stringResult);
            //} else if( response.StatusCode == HttpStatusCode.Unauthorized){

            //}
        }
        public async Task<EmployeeModel> GetEmployeeByIdAsync(int personId) {
            var response = await _httpClient.GetFromJsonAsync<EmployeeModel>($"{_configuration["Endpoints:baseUrl"]}/api/Employee/{personId}");
            return response;
        }
    }
}
