namespace HotelManagementSystem.Core.DomainModel
{
    public class Guest
    {
        public Guid Id { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNr { get; private set; }

        public Guest(string firstName, string lastName, string phoneNr)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            PhoneNr = phoneNr;
        }
    }
}