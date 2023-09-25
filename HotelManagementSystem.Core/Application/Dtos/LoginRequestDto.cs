namespace HotelManagementSystem.Core.Application.Dtos
{
    public class LoginRequestDto
    {
        public string PhoneNr { get; private set; }

        public LoginRequestDto(string phoneNr)
        {
            PhoneNr = phoneNr;
        }
    }
}
