namespace HotelManagementSystem.Core.Application.Dtos
{
    public class RoomTypeResponseDto
    {
        public string Type { get; private set; }
        public bool HasCityView { get; private set; }
        public bool HasBathtub { get; private set; }

        public RoomTypeResponseDto(string type, bool hasCityView, bool hasBathtub)
        {
            Type = type;
            HasCityView = hasCityView;
            HasBathtub = hasBathtub;
        }
    }
}
