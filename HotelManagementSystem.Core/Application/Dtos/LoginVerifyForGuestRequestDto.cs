namespace HotelManagementSystem.Core.Application.Dtos
{
    public class LoginVerifyForGuestRequestDto
    {
        public string VerificationCode { get; private set; }

        public LoginVerifyForGuestRequestDto(string verificationCode)
        {
            VerificationCode = verificationCode;
        }
    }
}
