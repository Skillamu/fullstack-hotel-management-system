namespace HotelManagementSystem.Infrastructure.DataAccess.Entities
{
    public class ReservationEntity
    {
        public Guid Id { get; }
        public Guid GuestId { get; }
        public Guid RoomId { get; }

        public ReservationEntity(Guid id, Guid guestId, Guid roomId)
        {
            Id = id;
            GuestId = guestId;
            RoomId = roomId;
        }
    }
}