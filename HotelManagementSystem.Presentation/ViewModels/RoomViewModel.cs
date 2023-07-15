namespace HotelManagementSystem.Presentation.ViewModels
{
    public class RoomViewModel
    {
        public short RoomNr { get; private set; }

        public RoomViewModel(short roomNr)
        {
            RoomNr = roomNr;
        }
    }
}
