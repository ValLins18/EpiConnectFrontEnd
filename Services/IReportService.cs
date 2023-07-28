using EpiConnectFrontEnd.Model.ViewModel;

namespace EpiConnectFrontEnd.Services {
    public interface IReportService {
        Task<List<AlertsEpiViewModel>> GetAlertsEpis();
        Task<List<WorkshiftAlertsViewModel>> GetWorkshiftAlerts();

    }
}
