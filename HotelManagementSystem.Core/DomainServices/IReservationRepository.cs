using HotelManagementSystem.Core.DomainModel;

namespace HotelManagementSystem.Core.DomainServices
{
    public interface IReservationRepository
    {
        Reservation GetById(Guid id);
        void Create(Reservation reservation);
    }
}
