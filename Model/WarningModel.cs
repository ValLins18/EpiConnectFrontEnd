namespace EpiConnectFrontEnd.Model {
    public class WarningModel {
        public int WarningId { get; set; }
        public DateTime WarningDate { get; set; }
        public AlertModel Alert { get; set; }
        public EmployeeModel Employee { get; set; }
    }
}
