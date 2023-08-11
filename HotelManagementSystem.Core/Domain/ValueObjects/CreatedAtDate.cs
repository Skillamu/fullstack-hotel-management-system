namespace HotelManagementSystem.Core.Domain.ValueObjects
{
    public class CreatedAtDate
    {
        public DateTime Value { get; }

        private CreatedAtDate(DateTime date)
        {
            Value = date;
        }

        public static CreatedAtDate Create()
        {
            var date = DateTime.Now;

            return IsValidDate(date) ? new CreatedAtDate(date) : null;
        }

        public static CreatedAtDate Create(DateTime date)
        {
            return IsValidDate(date) ? new CreatedAtDate(date) : null;
        }

        private static bool IsValidDate(DateTime date)
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
    }
}
