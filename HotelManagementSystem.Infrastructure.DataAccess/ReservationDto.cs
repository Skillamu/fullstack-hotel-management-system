namespace HotelManagementSystem.Infrastructure.DataAccess
{
    internal class ReservationDto
    {
        public Guid Id { get; set; }
        public Guid GuestId { get; set; }
        public Guid RoomId { get; set; }
    }
}