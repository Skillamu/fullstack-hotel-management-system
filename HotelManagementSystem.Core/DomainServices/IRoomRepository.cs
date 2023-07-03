namespace HotelManagementSystem.Core.DomainServices
{
    public interface IRoomRepository
    {
        public Guid GetIdByRoomNr(short roomNr);
    }
}
