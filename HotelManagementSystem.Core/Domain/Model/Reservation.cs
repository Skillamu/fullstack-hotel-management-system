namespace HotelManagementSystem.Core.Domain.Model
{
    public class Reservation
    {
        public Guid Id { get; }
        public Guest Guest { get; private set; }
        public Room Room { get; private set; }

        private Reservation(Guid id, Guest guest, Room room)
        {
            Id = id;
            Guest = guest;
            Room = room;
        }

        public static Reservation Create(Guid id, Guest guest, Room room)
        {
            if (id == Guid.Empty || guest == null || room == null)
            {
                return null;
            }

            return new Reservation(id, guest, room);
        }
    }
}
