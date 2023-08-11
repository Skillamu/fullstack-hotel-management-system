namespace HotelManagementSystem.Infrastructure.DataAccess.Entities
{
    public class ReservationEntity
    {
        public Guid Id { get; }
        public Guid GuestId { get; }
        public Guid RoomId { get; }
        public DateTime CheckInDate { get; }
        public DateTime CheckOutDate { get; }
        public DateTime CreateDate { get; }
        public bool IsVerified { get; }

        public ReservationEntity(Guid id, Guid guestId, Guid roomId, DateTime checkInDate, DateTime checkOutDate, DateTime createDate, bool isVerified)
        {
            Id = id;
            GuestId = guestId;
            RoomId = roomId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            CreateDate = createDate;
            IsVerified = isVerified;
        }
    }
}