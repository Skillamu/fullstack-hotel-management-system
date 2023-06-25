namespace HotelManagementSystem.Core.DomainModel
{
    internal class Guest
    {
        public Guid Id { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNr { get; private set; }
    }
}