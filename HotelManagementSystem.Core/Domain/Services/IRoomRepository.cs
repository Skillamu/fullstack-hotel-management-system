using HotelManagementSystem.Core.Domain.Model;

namespace HotelManagementSystem.Core.Domain.Services
{
    public interface IRoomRepository
    {
        public Room GetRoomByRoomNr(short roomNr);
    }
}