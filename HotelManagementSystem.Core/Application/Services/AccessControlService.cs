using HotelManagementSystem.Core.Domain.Repositories;

namespace HotelManagementSystem.Core.Application.Services
{
    public class AccessControlService
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IReservationRepository _reservationRepository;

        public AccessControlService(IGuestRepository guestRepository, IReservationRepository reservationRepository)
        {
            _guestRepository = guestRepository;
            _reservationRepository = reservationRepository;
        }

        public bool HasAccessToResource(string guestIdClaimValue, Guid guestId)
        {
            _ = Guid.TryParse(guestIdClaimValue, out var parsedGuestIdClaimValue);

            var guest = _guestRepository.GetById(guestId);

            if (guest == null)
            {
                return false;
            }

            if (parsedGuestIdClaimValue != guest.Id)
            {
                return false;
            }

            return true;
        }

        public bool HasAccessToResource(string guestIdClaimValue, Guid guestId, Guid reservationId)
        {
            _ = Guid.TryParse(guestIdClaimValue, out var parsedGuestIdClaimValue);

            var guest = _guestRepository.GetById(guestId);

            if (guest == null)
            {
                return false;
            }

            if (parsedGuestIdClaimValue != guest.Id)
            {
                return false;
            }

            var reservation = _reservationRepository.GetById(reservationId);

            if (reservation == null)
            {
                return false;
            }

            if (parsedGuestIdClaimValue != reservation.Guest.Id)
            {
                return false;
            }

            return true;
        }
    }
}
