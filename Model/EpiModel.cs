namespace EpiConnectFrontEnd.Model {
    public class EpiModel {
        public int EpiId { get; set; }
        public string Name { get; set; }
        public int ProtectionType { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public IEnumerable<AlertModel>? Alerts { get; set; }
        public  MetricsModel Metrics { get; set; }
        public  EmployeeModel Employee { get; set; }
    }
}
