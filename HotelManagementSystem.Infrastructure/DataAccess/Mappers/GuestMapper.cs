using HotelManagementSystem.Core.DomainModel;
using HotelManagementSystem.Infrastructure.DataAccess.Entities;

namespace HotelManagementSystem.Infrastructure.DataAccess.Mappers
{
    public static class GuestMapper
    {
        public static GuestEntity ToEntity(this Guest g)
        {
            var guestEntity = new GuestEntity(g.Id, g.FirstName, g.LastName, g.PhoneNr);
            return guestEntity;
        }
    }
}
