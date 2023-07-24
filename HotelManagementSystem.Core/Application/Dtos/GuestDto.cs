namespace HotelManagementSystem.Core.Application.Dtos
{
    public class GuestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNr { get; set; }

        public GuestDto(string firstName, string lastName, string phoneNr)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNr = phoneNr;
        }
    }
}
