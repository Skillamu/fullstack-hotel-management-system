namespace HotelManagementSystem.Core.Application.Dtos
{
    public class ReservationDto
    {
        public GuestDto Guest { get; private set; }
        public RoomDto Room { get; private set; }
        public string CheckInDate { get; private set; }
        public string CheckOutDate { get; private set; }

        public ReservationDto(GuestDto guest, RoomDto room, string checkInDate, string checkOutDate)
        {
            Guest = guest;
            Room = room;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }
    }
}
