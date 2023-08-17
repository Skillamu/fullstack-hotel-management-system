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

        public ReservationDto Create(ReservationDto request)
        {
            _ = DateTime.TryParse(request.DateRange.CheckInDate, out DateTime checkInDate);
            _ = DateTime.TryParse(request.DateRange.CheckOutDate, out DateTime checkOutDate);

            var dateRange = DateRange.Create(checkInDate, checkOutDate);

            if (dateRange == null)
            {
                return null;
            }

            var room = _roomRepository.GetAvailableRoomWithinDateRange(request.Room.RoomNr, dateRange);

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

            var guestAlreadyExists = _guestRepository.GuestByPhoneNrAlreadyExists(guest.PhoneNr);

            if (!guestAlreadyExists)
            {
                _guestRepository.Create(guest);
                _reservationRepository.Create(reservation);
                _verificationService.Send(guest.PhoneNr);
                return request;
            }

            _reservationRepository.Create(reservation);
            _verificationService.Send(guest.PhoneNr);
            return request;
        }

        public bool Verify(VerificationDto request)
        {
            var reservation = _reservationRepository.GetUnverifiedReservationByGuestPhoneNr(request.PhoneNr);
            var verificationSucceed = _verificationService.Verify(request.PhoneNr, request.VerificationCode);

            if (reservation == null || reservation.TimeToVerifyHasExpired() || !verificationSucceed)
            {
                return false;
            }

            reservation.SetToVerified();
            _reservationRepository.Update(reservation);
            return true;
        }
    }
}
