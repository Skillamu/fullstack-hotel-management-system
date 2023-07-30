namespace HotelManagementSystem.Core.Application.Dtos
{
    public class ReservationDto
    {
        public GuestDto Guest { get; private set; }
        public RoomDto Room { get; private set; }
        public DateRangeDto DateRange { get; private set; }

        public ReservationDto(GuestDto guest, RoomDto room, DateRangeDto dateRange)
        {
            Guest = guest;
            Room = room;
            DateRange = dateRange;
        }
    }
}
