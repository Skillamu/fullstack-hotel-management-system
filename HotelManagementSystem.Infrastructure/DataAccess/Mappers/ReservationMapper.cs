using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Infrastructure.DataAccess.Entities;

namespace HotelManagementSystem.Infrastructure.DataAccess.Mappers
{
    public static class ReservationMapper
    {
        public static ReservationEntity ToEntity(this Reservation r)
        {
            return new ReservationEntity
            {
                Id = r.Id,
                GuestId = r.Guest.Id,
                RoomId = r.Room.Id,
                CheckInDate = r.DateRange.CheckInDate,
                CheckOutDate = r.DateRange.CheckOutDate
            };
        }
    }
}
