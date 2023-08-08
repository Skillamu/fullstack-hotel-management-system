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

        public static Guest? Create(string firstName, string lastName, string phoneNr)
        {
            var id = Guid.NewGuid();

            if (!IsGuestDataValid(id, firstName, lastName, phoneNr))
            {
                return null;
            }

            return new Guest(id, firstName, lastName, phoneNr);
        }

        public static Guest? Create(Guid id, string firstName, string lastName, string phoneNr)
        {
            if (!IsGuestDataValid(id, firstName, lastName, phoneNr))
            {
                return null;
            }

            return new Guest(id, firstName, lastName, phoneNr);
        }

        private static bool IsGuestDataValid(Guid id, string firstName, string lastName, string phoneNr)
        {
            if (id == Guid.Empty)
            {
                return false;
            }

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(phoneNr))
            {
                return false;
            }

            return true;
        }
    }
}