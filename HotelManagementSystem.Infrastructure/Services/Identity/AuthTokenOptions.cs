namespace HotelManagementSystem.Infrastructure.Services.Identity
{
    public class AuthTokenOptions
    {
        public const string Jwt = "jwt";

        public string SecretKey { get; set; } = "";
        public string Issuer { get; set; } = "";
        public string Audience { get; set; } = "";
    }
}