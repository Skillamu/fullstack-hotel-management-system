namespace HotelManagementSystem.Infrastructure.DataAccess.Entities
{
    public class RoomTable
    {
        public Guid Id { get; }
        public Guid RoomTypeId { get; }
        public short RoomNr { get; }
    }
}
