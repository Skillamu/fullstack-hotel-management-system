namespace HotelManagementSystem.Core.DomainModel
{
    internal class Room
    {
        public Guid Id { get; }
        public short RoomNr { get; private set; }
    }
}