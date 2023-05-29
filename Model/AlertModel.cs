namespace EpiConnectFrontEnd.Model {
    public class AlertModel {
        public int AlertId { get; set; }
        public int? DangerousLevel { get; set; }
        public DateTime AlertDate { get; set; }
        public bool IsOpen { get; set; } = false;
        public TimeSpan? UnprotectedTime { get; set; }
        public MetricsModel Metrics { get; set; }
        public EpiModel Epi { get; set; }
    }
}
