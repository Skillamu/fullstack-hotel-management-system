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

            var isRoomAvailable = _roomRepository.IsRoomAvailableWithinDateRange(request.Room.RoomNr, dateRange);

            if (!isRoomAvailable)
            {
                return null;
            }

            var room = _roomRepository.GetRoomByRoomNr(request.Room.RoomNr);

            var isGuestReserved = _guestRepository.IsGuestWithPhoneNrReserved(request.Guest.PhoneNr);

            if (!isGuestReserved)
            {
                var guest = Guest.Create(request.Guest.FirstName, request.Guest.LastName, request.Guest.PhoneNr);
                var reservation = Reservation.Create(guest, room, dateRange);

                _guestRepository.Create(guest);
                _reservationRepository.Create(reservation);
                _verificationService.Send(guest.PhoneNr);
            }
            else
            {
                var guest = _guestRepository.GetGuestByPhoneNr(request.Guest.PhoneNr);
                var reservation = Reservation.Create(guest, room, dateRange);

                _reservationRepository.Create(reservation);
                _verificationService.Send(guest.PhoneNr);
            }

            return request;
        }
    }
}
