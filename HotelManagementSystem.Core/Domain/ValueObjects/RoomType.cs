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

        public static RoomType? OfType(string type)
        {
            var roomTypes = new RoomType[]
            {
                Standard,
                Superior,
                Deluxe
            };

            var roomType = roomTypes.SingleOrDefault(x => x.Type == type);

            return roomType;
        }

        private static RoomType Standard => new RoomType("Standard", false, false);
        private static RoomType Superior => new RoomType("Superior", true, false);
        private static RoomType Deluxe => new RoomType("Deluxe", true, true);
    }
}
