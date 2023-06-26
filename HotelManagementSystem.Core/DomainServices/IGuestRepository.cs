using HotelManagementSystem.Core.DomainModel;

namespace HotelManagementSystem.Core.DomainServices
{
    public interface IGuestRepository
    {
        Guest GetById(Guid id);
        void Create(Guest guest);
    }
}
