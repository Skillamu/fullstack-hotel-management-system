namespace HotelManagementSystem.Infrastructure.DataAccess
{
    internal class ReservationDto
    {
        public Guid Id { get; set; }
        public Guid GuestId { get; set; }
        public Guid RoomId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNr { get; set; }
        public short RoomNr { get; set; }
    }
}