namespace AuthService.Api.Models
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
