using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Infrastructure.DataAccess.Entities;

namespace HotelManagementSystem.Infrastructure.DataAccess.Mappers
{
    public static class GuestMapper
    {
        public static GuestEntity ToEntity(this Guest g)
        {
            return new GuestEntity(g.Id, g.FirstName, g.LastName, g.PhoneNr);
        }
    }
}
