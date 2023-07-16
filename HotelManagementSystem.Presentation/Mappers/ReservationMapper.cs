using HotelManagementSystem.Core.DomainModel;
using HotelManagementSystem.Presentation.ViewModels;

namespace HotelManagementSystem.Presentation.Mappers
{
    public static class ReservationMapper
    {
        public static Reservation ToDomain(this ReservationViewModel r)
        {
            var guest = new Guest(r.Guest.FirstName, r.Guest.LastName, r.Guest.PhoneNr);
            var room = new Room(r.Room.RoomNr);
            var reservation = new Reservation(guest, room);
            return reservation;
        }

        public static ReservationViewModel ToViewModel(this Reservation r)
        {
            var guestViewModel = new GuestViewModel(r.Guest.FirstName, r.Guest.LastName, r.Guest.LastName);
            var roomViewModel = new RoomViewModel(r.Room.RoomNr);
            var reservationViewModel = new ReservationViewModel(guestViewModel, roomViewModel);
            return reservationViewModel;
        }
    }
}
