namespace HotelManagementSystem.Core.Application.Dtos
{
    public class ReservationRequestDto
    {
        public GuestRequestDto Guest { get; private set; }
        public RoomRequestDto Room { get; private set; }
        public string CheckInDate { get; private set; }
        public string CheckOutDate { get; private set; }

        public ReservationRequestDto(GuestRequestDto guest, RoomRequestDto room, string checkInDate, string checkOutDate)
        {
            Guest = guest;
            Room = room;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }
    }
}
