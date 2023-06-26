namespace HotelManagementSystem.Core.DomainModel
{
    public class Room
    {
        public Guid Id { get; }
        public short RoomNr { get; private set; }
    }
}