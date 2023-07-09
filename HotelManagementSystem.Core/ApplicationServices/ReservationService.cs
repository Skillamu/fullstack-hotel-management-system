using HotelManagementSystem.Core.DomainModel;
using HotelManagementSystem.Core.DomainServices;

namespace HotelManagementSystem.Core.ApplicationServices
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

        public Reservation Create(Reservation reservation)
        {
            var room = _roomRepository.GetRoomByRoomNr(reservation.Room.RoomNr);

            if (room == null)
            {
                return null;
            }

            reservation.AddRoom(room);
            _guestRepository.Create(reservation.Guest);
            _reservationRepository.Create(reservation);

            return reservation;
        }
    }
}
