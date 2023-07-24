namespace HotelManagementSystem.Core.Application.Dtos
{
    public class RoomDto
    {
        public short RoomNr { get; private set; }

        public RoomDto(short roomNr)
        {
            RoomNr = roomNr;
        }
    }
}
