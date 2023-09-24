namespace HotelManagementSystem.Core.Application.Dtos
{
    public class LoginVerifyForGuestRequestDto
    {
        public string PhoneNr { get; private set; }
        public string VerificationCode { get; private set; }

        public LoginVerifyForGuestRequestDto(string phoneNr, string verificationCode)
        {
            PhoneNr = phoneNr;
            VerificationCode = verificationCode;
        }
    }
}
