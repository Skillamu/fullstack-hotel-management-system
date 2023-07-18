using HotelManagementSystem.Core.DomainModel;
using HotelManagementSystem.Infrastructure.DataAccess.Entities;

namespace HotelManagementSystem.Infrastructure.DataAccess.Mappers
{
    public static class ReservationMapper
    {
        public static ReservationEntity ToEntity(this Reservation r)
        {
            var reservationEntity = new ReservationEntity(r.Id, r.Guest.Id, r.Room.Id);
            return reservationEntity;
        }
    }
}
