using HotelManagementSystem.Core.DomainModel;

namespace HotelManagementSystem.Core.DomainServices
{
    public interface IGuestRepository
    {
        void Create(Guest guest);
    }
}
