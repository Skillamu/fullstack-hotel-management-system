namespace HotelManagementSystem.Core.DomainModel
{
    public class Reservation
    {
        public Guid Id { get; }
        public Guest Guest { get; private set; }
        public Room Room { get; private set; }

        private Reservation(Guest guest, Room room)
        {
            Id = Guid.NewGuid();
            Guest = guest;
            Room = room;
        }

        public static Reservation Create(Guest guest, Room room)
        {
            if (guest == null || room == null)
            {
                return null;
            }

            return new Reservation(guest, room);
        }
    }
}
