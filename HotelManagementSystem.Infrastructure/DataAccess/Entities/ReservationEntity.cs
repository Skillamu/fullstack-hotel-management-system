namespace HotelManagementSystem.Infrastructure.DataAccess.Entities
{
    public class ReservationEntity
    {
        public Guid Id { get; set; }
        public Guid GuestId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}