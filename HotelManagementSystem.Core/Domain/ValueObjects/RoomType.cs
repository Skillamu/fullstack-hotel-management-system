namespace HotelManagementSystem.Core.Domain.ValueObjects
{
    public class RoomType
    {
        public string Type { get; }
        public bool HasCityView => Type == "Superior" || Type == "Deluxe";
        public bool HasBathtub => Type == "Deluxe";

        private RoomType(string type)
        {
            Type = type;
        }

        public static RoomType Standard => new RoomType("Standard");
        public static RoomType Superior => new RoomType("Superior");
        public static RoomType Deluxe => new RoomType("Deluxe");
    }
}
