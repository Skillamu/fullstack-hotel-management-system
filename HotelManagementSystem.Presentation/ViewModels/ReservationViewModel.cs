namespace HotelManagementSystem.Presentation.ViewModels
{
    public class ReservationViewModel
    {
        public GuestViewModel Guest { get; private set; }
        public RoomViewModel Room { get; private set; }

        public ReservationViewModel(GuestViewModel guest, RoomViewModel room)
        {
            Guest = guest;
            Room = room;
        }
    }
}
