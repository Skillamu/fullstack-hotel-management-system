namespace HotelManagementSystem.Core.Application.Dtos
{
    public class RoomRequestDto
    {
        public string Type { get; private set; }

        public RoomRequestDto(string type)
        {
            Type = type;
        }
    }
}