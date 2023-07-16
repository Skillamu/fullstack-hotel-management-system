namespace HotelManagementSystem.Core.DomainModel
{
    public class Room
    {
        public Guid Id { get; }
        public short RoomNr { get; private set; }

        public Room(Guid id, short roomNr) : this(roomNr)
        {
            Id = id;
        }

        public Room(short roomNr)
        {
            RoomNr = roomNr;
        }
    }
}