namespace HotelManagementSystem.Models.Entities
{
    public class Reservation
    {
        public Guid Id { get; }
        public Guid GuestId { get; }
        public Guid RoomId { get; }
    }
}
