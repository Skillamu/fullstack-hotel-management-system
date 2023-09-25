namespace HotelManagementSystem.Core.Application.Dtos
{
    public class ReservationVerifyRequestDto
    {
        public string VerificationCode { get; private set; }

        public ReservationVerifyRequestDto(string verificationCode)
        {
            VerificationCode = verificationCode;
        }
    }
}