namespace EpiConnectFrontEnd.Authentication {
    public class LoginSession {
        public bool Successful { get; set; }
        public string? Error { get; set; }
        public string? Token { get; set; }
    }
}
