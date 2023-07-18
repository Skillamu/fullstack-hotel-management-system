namespace HotelManagementSystem.Infrastructure.DataAccess.Entities
{
    public class GuestEntity
    {
        public Guid Id { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNr { get; private set; }

        public GuestEntity(Guid id, string firstname, string lastName, string phoneNr)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastName;
            PhoneNr = phoneNr;
        }
    }
}
