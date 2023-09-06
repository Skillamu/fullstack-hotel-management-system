namespace HotelManagementSystem.Core.Application.Dtos
{
    public class RoomDto
    {
        public string Type { get; private set; }

        public RoomDto(string type)
        {
            Type = type;
        }
    }
}