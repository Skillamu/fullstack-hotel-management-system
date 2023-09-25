namespace HotelManagementSystem.Core.Application.Dtos
{
    public class ReservationResponseDto
    {
        public short RoomNr { get; set; }
        public string Type { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
    }
}