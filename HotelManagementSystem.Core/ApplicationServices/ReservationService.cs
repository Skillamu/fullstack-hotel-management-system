using HotelManagementSystem.Core.DomainModel;
using HotelManagementSystem.Core.DomainServices;

namespace HotelManagementSystem.Core.ApplicationServices
{
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IGuestRepository _guestRepository;

        public ReservationService(IReservationRepository reservationRepository, IGuestRepository guestRepository)
        {
            _reservationRepository = reservationRepository;
            _guestRepository = guestRepository;
        }

        public Reservation GetReservationById(Guid id)
        {
            return _reservationRepository.GetById(id);
        }

        public void Create(Reservation reservation)
        {
            _reservationRepository.Create(reservation);
            _guestRepository.Create(reservation.Guest);
        }
    }
}
