using HotelManagementSystem.Core.DomainModel;
using HotelManagementSystem.Infrastructure.DataAccess.Entities;

namespace HotelManagementSystem.Infrastructure.DataAccess.Mappers
{
    public static class RoomMapper
    {
        public static Room ToDomain(this RoomEntity r)
        {
            if (r == null)
            {
                return null;
            }

            var room = new Room(r.Id, r.RoomNr);
            return room;
        }
    }
}
