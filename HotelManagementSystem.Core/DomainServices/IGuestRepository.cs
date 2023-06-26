using HotelManagementSystem.Core.DomainModel;

namespace HotelManagementSystem.Core.DomainServices
{
    internal interface IGuestRepository
    {
        Guest GetById(Guid id);
        void Create(Guest guest);
    }
}
