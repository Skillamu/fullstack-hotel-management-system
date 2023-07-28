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
            if (!IsValidDate(checkInDate) || !IsValidDate(checkOutDate))
            {
                return null;
            }

            if (!IsValidDateRange(checkInDate, checkOutDate))
            {
                return null;
            }

            return new DateRange(checkInDate, checkOutDate);
        }

        public static bool IsValidDate(DateTime date)
        {
            if (!DateTime.IsLeapYear(date.Year) && date.Month == 2 && date.Day == 29)
            {
                return false;
            }

            if (date.Year < DateTime.Now.Year)
            {
                return false;
            }

            if (date.Year == DateTime.Now.Year && date.Month < DateTime.Now.Month)
            {
                return false;
            }

            if (date.Year == DateTime.Now.Year && date.Month == DateTime.Now.Month && date.Day < DateTime.Now.Day)
            {
                return false;
            }

            return true;
        }

        public static bool IsValidDateRange(DateTime checkInDate, DateTime checkOutDate)
        {
            if (checkOutDate < checkInDate)
            {
                return false;
            }

            return true;
        }
    }
}
