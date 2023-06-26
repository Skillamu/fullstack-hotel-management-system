namespace HotelManagementSystem.Core.DomainModel
{
    public class Reservation
    {
        public Guid Id { get; }
        public Guest Guest { get; private set; }
        public Room Room { get; private set; }
    }
}
