namespace EpiConnectFrontEnd.Model {
    public class PersonModel {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string? ImgPath { get; set; }
        public PhoneModel Phone { get; set; }
        public AddressModel Address { get; set; }
    }
}
