using EpiConnectFrontEnd.Model.ViewModel;
using System.Net.Http.Json;

namespace EpiConnectFrontEnd.Services {
    public class ReportService : IReportService {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ReportService(HttpClient httpClient, IConfiguration configuration) {
            _configuration = configuration;
            _httpClient = httpClient;
        }
        public async Task<List<AlertsEpiViewModel>> GetAlertsEpis() {
            var response = await _httpClient.GetFromJsonAsync<List<AlertsEpiViewModel>>($"{_configuration["Endpoints:baseUrl"]}/api/Epi/Alerts");
            return response;
        }

        public async Task<List<WorkshiftAlertsViewModel>> GetWorkshiftAlerts() {
            var response = await _httpClient.GetFromJsonAsync<List<WorkshiftAlertsViewModel>>($"{_configuration["Endpoints:baseUrl"]}/workshiftalerts");
            return response;
        }
    }
}
