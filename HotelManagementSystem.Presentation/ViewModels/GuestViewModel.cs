namespace HotelManagementSystem.Presentation.ViewModels
{
    public class GuestViewModel
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNr { get; private set; }

        public GuestViewModel(string firstName, string lastName, string phoneNr)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNr = phoneNr;
        }
    }
}
