namespace HotelManagementSystem.Core.DomainModel
{
    public class Room
    {
        public Guid Id { get; }
        public short RoomNr { get; private set; }

        private Room(Guid id, short roomNr)
        {
            Id = id;
            RoomNr = roomNr;
        }

        public static Room Create(Guid id, short roomNr)
        {
            if (id == Guid.Empty)
            {
                return null;
            }

            return new Room(id, roomNr);
        }
    }
}