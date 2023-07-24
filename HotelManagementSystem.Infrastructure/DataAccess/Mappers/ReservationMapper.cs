using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Infrastructure.DataAccess.Entities;

namespace HotelManagementSystem.Infrastructure.DataAccess.Mappers
{
    public static class ReservationMapper
    {
        public static ReservationEntity ToEntity(this Reservation r)
        {
            return new ReservationEntity(r.Id, r.Guest.Id, r.Room.Id);
        }
    }
}
