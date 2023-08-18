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

            return new CreatedAtDate(date);
        }
    }
}
