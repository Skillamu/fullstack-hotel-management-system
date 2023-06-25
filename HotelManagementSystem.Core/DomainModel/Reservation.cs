namespace HotelManagementSystem.Core.DomainModel
{
    internal class Reservation
    {
        public Guid Id { get; }
        public Guest Guest { get; private set; }
        public Room Room { get; private set; }
    }
}
