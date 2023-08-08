using HotelManagementSystem.Core.Domain.Model;

namespace HotelManagementSystem.Core.Domain.Services
{
    public interface IReservationRepository
    {
        void Create(Reservation reservation);
        void Update(Reservation reservation);
        void Delete(Reservation reservation);
        Reservation GetUnverifiedReservationByGuestPhoneNr(string phoneNr);
        IEnumerable<Reservation> GetUnverifiedReservations();
    }
}
