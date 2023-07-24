using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Infrastructure.DataAccess.Entities;

namespace HotelManagementSystem.Infrastructure.DataAccess.Mappers
{
    public static class RoomMapper
    {
        public static Room ToDomain(this RoomEntity r)
        {
            return Room.Create(r.Id, r.RoomNr);
        }
    }
}
