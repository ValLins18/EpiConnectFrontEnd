using EpiConnectFrontEnd.Model;
using EpiConnectFrontEnd.Model.ViewModel;

namespace EpiConnectFrontEnd.Services {
    public interface IEmployeeService {
        Task<EmployeeMonitoringViewModel[]> GetEmployeesForMonitoringAsync();
    }
}
