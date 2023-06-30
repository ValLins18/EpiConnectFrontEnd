using EpiConnectFrontEnd.Model.ViewModel;

namespace EpiConnectFrontEnd.Services {
    public interface IDepartmentService {
        Task<List<DepartmentAlertsViewModel>> GetDepartmentAlertsAsync();
    }
}
