namespace HotelManagementSystem.Models.Entities
{
    public class Guest
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string PhoneNr { get; }

        public Guest()
        {
        }

        public Guest(string firstName, string lastName, string phoneNr)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            PhoneNr = phoneNr;
        }
    }
}