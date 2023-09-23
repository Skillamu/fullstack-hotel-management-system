namespace HotelManagementSystem.Core.Application.Dtos
{
    public class LoginForGuestRequestDto
    {
        public string PhoneNr { get; private set; }

        public LoginForGuestRequestDto(string phoneNr)
        {
            PhoneNr = phoneNr;
        }
    }
}
