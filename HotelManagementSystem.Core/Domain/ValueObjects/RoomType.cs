namespace HotelManagementSystem.Core.Domain.ValueObjects
{
    public class RoomType
    {
        public string Type { get; }
        public bool HasCityView { get; }
        public bool HasBathtub { get; }

        private RoomType(string type, bool hasCityView, bool hasBathtub)
        {
            Type = type;
            HasCityView = hasCityView;
            HasBathtub = hasBathtub;
        }

        public static RoomType Standard => new RoomType("Standard", false, false);
        public static RoomType Superior => new RoomType("Superior", true, false);
        public static RoomType Deluxe => new RoomType("Deluxe", true, true);
    }
}
