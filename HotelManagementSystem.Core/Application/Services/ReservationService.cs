using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Core.Application.Dtos;
using HotelManagementSystem.Core.Domain.ValueObjects;
using HotelManagementSystem.Core.Application.Interfaces;
using HotelManagementSystem.Core.Domain.Repositories;

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

        public Guid? Create(ReservationRequestDto request)
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

            return reservation.Id;
        }

        public bool Verify(Guid id, ReservationVerifyRequestDto reservationVerifyRequestDto)
        {
            var reservation = _reservationRepository.GetById(id);

            if (reservation == null || reservation.IsVerified)
            {
                return false;
            }

            var verificationSucceed = _verificationService.Verify(reservation.Guest.PhoneNr, reservationVerifyRequestDto.VerificationCode);

            if (reservation.TimeToVerifyHasExpired() || !verificationSucceed)
            {
                return false;
            }

            reservation.SetToVerified();
            _reservationRepository.Update(reservation);

            return true;
        }

        public IEnumerable<ReservationResponseDto>? ShowReservations(Guid guestId)
        {
            var guest = _guestRepository.GetById(guestId);

            if (guest == null)
            {
                return null;
            }

            var reservations = _reservationRepository.GetAllByGuestId(guest.Id);

            var reservationsResponseDto = reservations.Select(reservation => new ReservationResponseDto
            {
                RoomNr = reservation.Room.RoomNr,
                Type = reservation.Room.RoomType.Type,
                CheckInDate = reservation.DateRange.CheckInDate.ToShortDateString(),
                CheckOutDate = reservation.DateRange.CheckOutDate.ToShortDateString()
            });

            return reservationsResponseDto;
        }

        public bool? CancelReservation(Guid id)
        {
            var reservation = _reservationRepository.GetById(id);

            if (reservation == null)
            {
                return null;
            }

            if (reservation.ValidCancellationTimeHasExpired())
            {
                // Will not add a feature for this in the application, but
                // the guest will be charged a certain amount of money
                // since the valid cancellation time has expired
            }

            _reservationRepository.Delete(reservation);

            return true;
        }
    }
}
