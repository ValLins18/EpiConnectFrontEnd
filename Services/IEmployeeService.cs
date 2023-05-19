using EpiConnectFrontEnd.Model;

namespace EpiConnectFrontEnd.Services {
    public interface IEmployeeService {
        Task<EmployeeModel[]> GetEmployeesAsync();
    }
}
