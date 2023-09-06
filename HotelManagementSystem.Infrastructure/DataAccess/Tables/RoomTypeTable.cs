namespace HotelManagementSystem.Infrastructure.DataAccess.Entities
{
    public class RoomTypeTable
    {
        public Guid Id { get; }
        public string Type { get; }
        public bool HasCityView { get; }
        public bool HasBathtub { get; }
    }
}
