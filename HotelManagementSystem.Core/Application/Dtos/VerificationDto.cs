namespace HotelManagementSystem.Core.Application.Dtos
{
    public class VerificationDto
    {
        public string PhoneNr { get; private set; }
        public string VerificationCode { get; private set; }

        public VerificationDto(string phoneNr, string verificationCode)
        {
            PhoneNr = phoneNr;
            VerificationCode = verificationCode;
        }
    }
}
