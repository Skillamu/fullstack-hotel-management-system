namespace HotelManagementSystem.Core.Domain.Model
{
    public class Guest
    {
        private readonly Guid _id;
        public Guid Id => _id;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNr { get; private set; }

        private Guest()
        {
        }

        private Guest(string firstName, string lastName, string phoneNr)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNr = phoneNr;

            _id = Guid.NewGuid();
        }

        public static Guest? Create(string firstName, string lastName, string phoneNr)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(phoneNr))
            {
                return null;
            }

            return new Guest(firstName, lastName, phoneNr);
        }
    }
}