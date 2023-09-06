using HotelManagementSystem.Core.Domain.Services;
using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Core.Application.Dtos;
using HotelManagementSystem.Core.Domain.ValueObjects;

namespace HotelManagementSystem.Core.Application.Services
{
    public class ReservationService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IVerificationService _verificationService;

        public ReservationService(IRoomRepository roomRepository, IGuestRepository guestRepository, IReservationRepository reservationRepository, IVerificationService verificationService)
        {
            _roomRepository = roomRepository;
            _guestRepository = guestRepository;
            _reservationRepository = reservationRepository;
            _verificationService = verificationService;
        }

        public Reservation Create(ReservationDto request)
        {
            _ = DateTime.TryParse(request.CheckInDate, out DateTime checkInDate);
            _ = DateTime.TryParse(request.CheckOutDate, out DateTime checkOutDate);

            var dateRange = DateRange.Create(checkInDate, checkOutDate);

            if (dateRange == null)
            {
                return null;
            }

            var roomType = RoomType.OfType(request.Room.Type);

            if (roomType == null)
            {
                return null;
            }

            var room = _roomRepository.GetRoomWithinDateRange(roomType, dateRange);

            if (room == null)
            {
                return null;
            }

            var guest = _guestRepository.GetGuestByPhoneNr(request.Guest.PhoneNr) ?? Guest.Create(request.Guest.FirstName, request.Guest.LastName, request.Guest.PhoneNr);

            if (guest == null)
            {
                return null;
            }

            var reservation = Reservation.Create(guest, room, dateRange);

            if (reservation == null)
            {
                return null;
            }

            _guestRepository.Create(guest);
            _reservationRepository.Create(reservation);
            _verificationService.Send(guest.PhoneNr);
            return reservation;
        }

        public bool Verify(Guid id, string verificationCode)
        {
            var reservation = _reservationRepository.GetById(id);

            if (reservation == null)
            {
                return false;
            }

            var verificationSucceed = _verificationService.Verify(reservation.Guest.PhoneNr, verificationCode);

            if (reservation.TimeToVerifyHasExpired() || !verificationSucceed)
            {
                return false;
            }

            reservation.SetToVerified();
            _reservationRepository.Update(reservation);
            return true;
        }
    }
}
