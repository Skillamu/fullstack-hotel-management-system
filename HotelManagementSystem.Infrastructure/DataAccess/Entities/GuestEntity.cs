namespace HotelManagementSystem.Infrastructure.DataAccess.Entities
{
    public class GuestEntity
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string PhoneNr { get; }

        public GuestEntity(Guid id, string firstName, string lastName, string phoneNr)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNr = phoneNr;
        }
    }
}
