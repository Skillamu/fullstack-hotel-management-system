namespace HotelManagementSystem.Core.Application.Dtos
{
    public class ReservationDto
    {
        public GuestDto Guest { get; set; }
        public RoomDto Room { get; set; }

        public ReservationDto(GuestDto guest, RoomDto room)
        {
            Guest = guest;
            Room = room;
        }
    }
}
