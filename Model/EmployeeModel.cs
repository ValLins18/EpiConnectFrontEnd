namespace EpiConnectFrontEnd.Model {
    public class EmployeeModel : PersonModel{
        public DateTime EntryDate { get; set; }
        public List<EpiModel>? Epis { get; set; }
        public List<WarningModel>? Warnings { get; set; }
        public PostModel Post { get; set; }
    }
}
