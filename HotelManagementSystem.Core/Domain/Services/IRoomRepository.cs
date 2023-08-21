using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Core.Domain.ValueObjects;

namespace HotelManagementSystem.Core.Domain.Services
{
    public interface IRoomRepository
    {
        Room GetAvailableRoomWithinDateRange(short roomNr, DateRange dateRange);
    }
}