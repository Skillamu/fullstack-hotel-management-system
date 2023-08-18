namespace HotelManagementSystem.Core.Domain.ValueObjects
{
    public class CreatedAtDate
    {
        public DateTime Value { get; }

        private CreatedAtDate(DateTime date)
        {
            Value = date;
        }

        public static CreatedAtDate Create(DateTime date)
        {
            if (date > DateTime.Now)
            {
                return null;
            }

            return new CreatedAtDate(date);
        }
    }
}
