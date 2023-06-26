using HotelManagementSystem.Core.DomainModel;

namespace HotelManagementSystem.Core.DomainServices
{
    internal interface IReservationRepository
    {
        Reservation GetById(Guid id);
        void Create(Reservation reservation);

    }
}
