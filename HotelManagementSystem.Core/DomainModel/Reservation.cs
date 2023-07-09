namespace HotelManagementSystem.Core.DomainModel
{
    public class Reservation
    {
        public Guid Id { get; }
        public Guest Guest { get; private set; }
        public Room Room { get; private set; }

        public void AddRoom(Room room)
        {
            Room = room;
        }
    }
}
