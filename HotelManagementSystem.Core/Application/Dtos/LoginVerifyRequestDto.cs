namespace HotelManagementSystem.Core.Application.Dtos
{
    public class LoginVerifyRequestDto
    {
        public string PhoneNr { get; private set; }
        public string VerificationCode { get; private set; }

        public LoginVerifyRequestDto(string phoneNr, string verificationCode)
        {
            PhoneNr = phoneNr;
            VerificationCode = verificationCode;
        }
    }
}
