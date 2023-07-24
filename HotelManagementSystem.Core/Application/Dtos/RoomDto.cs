namespace HotelManagementSystem.Core.Application.Dtos
{
    public class RoomDto
    {
        public short RoomNr { get; set; }

        public RoomDto(short roomNr)
        {
            RoomNr = roomNr;
        }
    }
}
