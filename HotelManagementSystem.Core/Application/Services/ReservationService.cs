using HotelManagementSystem.Core.Domain.Services;
using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Core.Application.Dtos;

namespace HotelManagementSystem.Core.Application.Services
{
    public class ReservationService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IRoomRepository roomRepository, IGuestRepository guestRepository, IReservationRepository reservationRepository)
        {
            _roomRepository = roomRepository;
            _guestRepository = guestRepository;
            _reservationRepository = reservationRepository;
        }

        public ReservationDto Create(ReservationDto request)
        {
            var guest = Guest.Create(Guid.NewGuid(), request.Guest.FirstName, request.Guest.LastName, request.Guest.PhoneNr);

            var room = _roomRepository.GetRoomByRoomNr(request.Room.RoomNr);

            var reservation = Reservation.Create(Guid.NewGuid(), guest, room);

            if (reservation == null)
            {
                return null;
            }

            _guestRepository.Create(reservation.Guest);
            _reservationRepository.Create(reservation);

            return request;
        }
    }
}
