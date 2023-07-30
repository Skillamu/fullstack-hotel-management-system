namespace HotelManagementSystem.Core.Application.Dtos
{
    public class DateRangeDto
    {
        public string CheckInDate { get; private set; }
        public string CheckOutDate { get; private set;}

        public DateRangeDto(string checkInDate, string checkOutDate)
        {
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }
    }
}
