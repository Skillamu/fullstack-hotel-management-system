namespace HotelManagementSystem.Core.DomainModel
{
    public class Reservation
    {
        public Guid Id { get; }
        public Guest Guest { get; private set; }
        public Room Room { get; private set; }

        public Reservation(Guest guest, Room room)
        {
            Id = Guid.NewGuid();
            Guest = guest;
            Room = room;
        }

        public void AddRoom(Room room)
        {
            Room = room;
        }
    }
}
