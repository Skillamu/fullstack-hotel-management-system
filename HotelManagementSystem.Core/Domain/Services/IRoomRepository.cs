using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Core.Domain.ValueObjects;

namespace HotelManagementSystem.Core.Domain.Services
{
    public interface IRoomRepository
    {
        Room GetRoomByRoomNr(short roomNr);
        bool IsRoomAvailableWithinDateRange(string roomNr, DateRange dateRange);
    }
}