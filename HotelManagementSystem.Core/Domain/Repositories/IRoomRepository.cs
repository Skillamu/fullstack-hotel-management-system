using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Core.Domain.ValueObjects;

namespace HotelManagementSystem.Core.Domain.Repositories
{
    public interface IRoomRepository
    {
        Room GetRoomWithinDateRange(RoomType roomType, DateRange dateRange);
        IEnumerable<RoomType> GetRoomTypes();
    }
}