using HotelManagementSystem.Core.Domain.Model;

namespace HotelManagementSystem.Core.Domain.Services
{
    public interface IReservationRepository
    {
        void Create(Reservation reservation);
        void Update(Reservation reservation);
        void Delete(Reservation reservation);
        Reservation GetUnverifiedReservationByGuestPhoneNr(string phoneNr);
        Reservation GetById(Guid id);

        // int DeleteUnverifiedReservations(); Will add this later.
    }
}