namespace HotelManagementSystem.Core.Application.Dtos
{
    public class RoomDto
    {
        public bool HasCityView { get; private set; }

        public RoomDto(bool hasCityView)
        {
            HasCityView = hasCityView;
        }
    }
}