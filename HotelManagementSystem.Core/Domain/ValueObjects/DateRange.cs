namespace HotelManagementSystem.Core.Domain.ValueObjects
{
    public class DateRange
    {
        public DateTime CheckInDate { get; }
        public DateTime CheckOutDate { get; }

        private DateRange(DateTime checkInDate, DateTime checkOutDate)
        {
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }

        public static DateRange Create(DateTime checkInDate, DateTime checkOutDate)
        {
            if (checkInDate < DateTime.Now || checkOutDate < checkInDate)
            {
                return null;
            }

            return new DateRange(checkInDate, checkOutDate);
        }
    }
}
