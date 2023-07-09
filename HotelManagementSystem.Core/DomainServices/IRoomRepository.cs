using HotelManagementSystem.Core.DomainModel;

namespace HotelManagementSystem.Core.DomainServices
{
    public interface IRoomRepository
    {
        public Room GetRoomByRoomNr(short roomNr);
    }
}