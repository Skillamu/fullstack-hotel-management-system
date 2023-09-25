namespace HotelManagementSystem.Core.Application.Dtos
{
    public class GuestRequestDto
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNr { get; private set; }

        public GuestRequestDto(string firstName, string lastName, string phoneNr)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNr = phoneNr;
        }
    }
}
