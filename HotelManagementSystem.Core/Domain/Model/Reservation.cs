using HotelManagementSystem.Core.Domain.ValueObjects;

namespace HotelManagementSystem.Core.Domain.Model
{
    public class Reservation
    {
        public Guid Id { get; }
        public Guest Guest { get; private set; }
        public Room Room { get; private set; }
        public DateRange DateRange { get; private set; }

        private Reservation(Guid id, Guest guest, Room room, DateRange dateRange)
        {
            Id = id;
            Guest = guest;
            Room = room;
            DateRange = dateRange;
        }

        public static Reservation Create(Guid id, Guest guest, Room room, DateRange dateRange)
        {
            if (id == Guid.Empty || guest == null || room == null || dateRange == null)
            {
                return null;
            }

            return new Reservation(id, guest, room, dateRange);
        }
    }
}
