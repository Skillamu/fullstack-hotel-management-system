using HotelManagementSystem.Core.Domain.Model;

namespace HotelManagementSystem.Core.Domain.Services
{
    public interface IReservationRepository
    {
        void Create(Reservation reservation);
    }
}
