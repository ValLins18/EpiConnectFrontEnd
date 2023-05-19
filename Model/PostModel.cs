namespace EpiConnectFrontEnd.Model {
    public class PostModel {

        public int PostId { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DepartmentModel Department { get; set; }
    }
}
