using HotelManagementSystem.Core.Domain.Model;

namespace HotelManagementSystem.Core.Domain.Repositories
{
    public interface IReservationRepository
    {
        void Create(Reservation reservation);
        void Update(Reservation reservation);
        void Delete(Reservation reservation);
        Reservation GetUnverifiedReservationByGuestPhoneNr(string phoneNr);
        Reservation GetById(Guid id);
        IEnumerable<Reservation> GetAllByGuestId(Guid guestId);

        // int DeleteUnverifiedReservations(); Will add this later.
    }
}