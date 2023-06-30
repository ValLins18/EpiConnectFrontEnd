using EpiConnectFrontEnd.Model.ViewModel;
using System.Net.Http.Json;

namespace EpiConnectFrontEnd.Services {
    public class DepartmentService : IDepartmentService {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public DepartmentService(HttpClient httpClient, IConfiguration configuration) {
            _configuration = configuration;
            _httpClient = httpClient;
        }
        public async Task<List<DepartmentAlertsViewModel>> GetDepartmentAlertsAsync() {
            var response = await _httpClient.GetFromJsonAsync<List<DepartmentAlertsViewModel>>($"{_configuration["Endpoints:baseUrl"]}/api/Department/Alerts");
            return response;
        }
    }
}
