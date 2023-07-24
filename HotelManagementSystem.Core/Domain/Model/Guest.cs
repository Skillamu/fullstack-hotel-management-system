namespace HotelManagementSystem.Core.Domain.Model
{
    public class Guest
    {
        public Guid Id { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNr { get; private set; }

        private Guest(Guid id, string firstName, string lastName, string phoneNr)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNr = phoneNr;
        }

        public static Guest Create(Guid id, string firstName, string lastName, string phoneNr)
        {
            if (id == Guid.Empty || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(phoneNr))
            {
                return null;
            }

            return new Guest(id, firstName, lastName, phoneNr);
        }
    }
}