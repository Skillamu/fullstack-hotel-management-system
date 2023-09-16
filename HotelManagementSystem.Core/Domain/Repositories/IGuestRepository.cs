using HotelManagementSystem.Core.Domain.Model;

namespace HotelManagementSystem.Core.Domain.Repositories
{
    public interface IGuestRepository
    {
        void Create(Guest guest);
        void Delete(Guest guest);
        Guest GetGuestByPhoneNr(string phoneNr);
    }
}
