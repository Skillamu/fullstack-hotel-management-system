namespace HotelManagementSystem.Infrastructure.DataAccess.Entities
{
    public class ReservationEntity
    {
        public Guid Id { get; }
        public Guid GuestId { get; }
        public Guid RoomId { get; }
        public DateTime CheckInDate { get; }
        public DateTime CheckOutDate { get; }
        public DateTime CreatedAtDate { get; }
        public bool IsVerified { get; }
    }
}