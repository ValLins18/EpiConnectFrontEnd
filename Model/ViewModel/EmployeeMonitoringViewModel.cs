namespace EpiConnectFrontEnd.Model.ViewModel {
    public class EmployeeMonitoringViewModel {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public PhoneModel Phone { get; set; }
        public PostModel Post { get; set; }
        public EmployeeLeaderViewModel EmployeeLeader { get; set; }
        public bool IsOpenAlert { get; set; } = false;
    }
}
