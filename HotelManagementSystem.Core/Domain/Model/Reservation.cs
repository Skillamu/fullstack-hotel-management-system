using HotelManagementSystem.Core.Domain.ValueObjects;

namespace HotelManagementSystem.Core.Domain.Model
{
    public class Reservation
    {
        public Guid Id { get; }
        public Guest Guest { get; private set; }
        public Room Room { get; private set; }
        public DateRange DateRange { get; private set; }
        public CreatedAtDate CreatedAtDate { get; private set; }
        public bool IsVerified { get; private set; }

        private Reservation(Guid id, Guest guest, Room room, DateRange dateRange, CreatedAtDate createdAtDate, bool isVerified)
        {
            Id = id;
            Guest = guest;
            Room = room;
            DateRange = dateRange;
            CreatedAtDate = createdAtDate;
            IsVerified = isVerified;
        }

        public static Reservation? Create(Guest guest, Room room, DateRange dateRange)
        {
            var id = Guid.NewGuid();
            var createdAtDate = CreatedAtDate.Create(DateTime.Now);
            var isVerified = false;

            if (!IsReservationDataValid(id, guest, room, dateRange, createdAtDate))
            {
                return null;
            }

            return new Reservation(id, guest, room, dateRange, createdAtDate, isVerified);
        }

        public static Reservation? Create(Guid id, Guest guest, Room room, DateRange dateRange, CreatedAtDate createdAtDate, bool isVerified)
        {
            if (!IsReservationDataValid(id, guest, room, dateRange, createdAtDate))
            {
                return null;
            }

            return new Reservation(id, guest, room, dateRange, createdAtDate, isVerified);
        }

        private static bool IsReservationDataValid(Guid id, Guest guest, Room room, DateRange dateRange, CreatedAtDate createdAtDate)
        {
            if (id == Guid.Empty || guest == null || room == null || dateRange == null || createdAtDate == null || createdAtDate.Value > dateRange.CheckInDate)
            {
                return false;
            }

            return true;
        }

        public void SetToVerified()
        {
            IsVerified = true;
        }

        public bool TimeToVerifyHasExpired()
        {
            // Add additional date validation in this method later.
            if (CreatedAtDate.Value.Minute + 1 < DateTime.Now.Minute)
            {
                return true;
            }

            return false;
        }
    }
}
