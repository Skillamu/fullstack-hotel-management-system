using HotelManagementSystem.Core.DomainModel;

namespace HotelManagementSystem.Core.DomainServices
{
    public interface IReservationRepository
    {
        void Create(Reservation reservation);
    }
}
