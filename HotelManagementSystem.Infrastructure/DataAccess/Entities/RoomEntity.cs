namespace HotelManagementSystem.Infrastructure.DataAccess.Entities
{
    public class RoomEntity
    {
        public Guid Id { get; }
        public short RoomNr { get; }
        public bool HasCityView { get; }
    }
}
