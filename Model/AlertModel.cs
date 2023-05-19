namespace EpiConnectFrontEnd.Model {
    public class AlertModel {
        public int AlertId { get; set; }
        public string DangerousLevel { get; set; }
        public DateTime AlertDate { get; set; }
        public MetricsModel Metrics { get; set; }
        public EpiModel Epi { get; set; }
    }
}
