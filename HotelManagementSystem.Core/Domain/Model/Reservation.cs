using HotelManagementSystem.Core.Domain.ValueObjects;

namespace HotelManagementSystem.Core.Domain.Model
{
    public class Reservation
    {
        private readonly Guid _id;
        public Guid Id => _id;
        public Guest Guest { get; private set; }
        public Room Room { get; private set; }
        public DateRange DateRange { get; private set; }
        public CreatedAtDate CreatedAtDate { get; private set; }
        public bool IsVerified { get; private set; }

        private Reservation()
        {
        }

        private Reservation(Guest guest, Room room, DateRange dateRange)
        {
            Guest = guest;
            Room = room;
            DateRange = dateRange;

            _id = Guid.NewGuid();
            CreatedAtDate = CreatedAtDate.Create();
            IsVerified = false;
        }

        public static Reservation? Create(Guest guest, Room room, DateRange dateRange)
        {
            if (guest == null || room == null || dateRange == null)
            {
                return null;
            }

            return new Reservation(guest, room, dateRange);
        }

        public void SetToVerified()
        {
            if (IsVerified || TimeToVerifyHasExpired())
            {
                return;
            }

            IsVerified = true;
        }

        public bool TimeToVerifyHasExpired()
        {
            if (DateTime.Now >= CreatedAtDate.Value.AddMinutes(5))
            {
                return true;
            }

            return false;   
        }
    }
}
