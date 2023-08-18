using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Core.Domain.ValueObjects;
using HotelManagementSystem.Infrastructure.DataAccess.Entities;
using System.Reflection;

namespace HotelManagementSystem.Infrastructure.DataAccess.Mappers
{
    internal static class ReservationMapper
    {
        public static ReservationEntity ToEntity(this Reservation r)
        {
            return new ReservationEntity(r.Id, r.Guest.Id, r.Room.Id, r.DateRange.CheckInDate, r.DateRange.CheckOutDate, r.CreatedAtDate.Value, r.IsVerified);
        }

        // Reflection is used here due to the lack of Dapper functionality when it comes to mapping multiple
        // tables to one object that is well encapsulated with private setters
        public static Reservation ToDomain(ReservationEntity reservationEntity, GuestEntity guestEntity, RoomEntity roomEntity)
        {
            var reservationType = typeof(Reservation);
            var ctor = reservationType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, new Type[0]);
            var reservation = (Reservation)ctor.Invoke(null);

            var reservationTypeIdBackField = reservationType.GetField("_id", BindingFlags.Instance | BindingFlags.NonPublic);
            reservationTypeIdBackField.SetValue(reservation, reservationEntity.Id);

            var reservationTypeGuestProperty = reservationType.GetProperty("Guest", BindingFlags.Instance | BindingFlags.Public);
            reservationTypeGuestProperty.SetValue(reservation, ToDomain(guestEntity));

            var reservationTypeRoomProperty = reservationType.GetProperty("Room", BindingFlags.Instance | BindingFlags.Public);
            reservationTypeRoomProperty.SetValue(reservation, ToDomain(roomEntity));

            var reservationTypeDateRangeProperty = reservationType.GetProperty("DateRange", BindingFlags.Instance | BindingFlags.Public);
            reservationTypeDateRangeProperty.SetValue(reservation, DateRange.Create(reservationEntity.CheckInDate, reservationEntity.CheckOutDate));

            var reservationTypeCreatedAtDateProperty = reservationType.GetProperty("CreatedAtDate", BindingFlags.Instance | BindingFlags.Public);
            reservationTypeCreatedAtDateProperty.SetValue(reservation, CreatedAtDate.Create(reservationEntity.CreatedAtDate));

            var reservationTypeIsVerifiedProperty = reservationType.GetProperty("IsVerified", BindingFlags.Instance | BindingFlags.Public);
            reservationTypeIsVerifiedProperty.SetValue(reservation, reservationEntity.IsVerified);

            return reservation;
        }

        private static Guest ToDomain(GuestEntity guestEntity)
        {
            var guestType = typeof(Guest);
            var ctor = guestType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, new Type[0]);
            var guest = (Guest)ctor.Invoke(null);

            var guestTypeIdBackField = guestType.GetField("_id", BindingFlags.Instance | BindingFlags.NonPublic);
            guestTypeIdBackField.SetValue(guest, guestEntity.Id);

            var guestTypeFirstNameProperty = guestType.GetProperty("FirstName", BindingFlags.Instance | BindingFlags.Public);
            guestTypeFirstNameProperty.SetValue(guest, guestEntity.FirstName);

            var guestTypeLastNameProperty = guestType.GetProperty("LastName", BindingFlags.Instance | BindingFlags.Public);
            guestTypeLastNameProperty.SetValue(guest, guestEntity.LastName);

            var guestTypePhoneNrProperty = guestType.GetProperty("PhoneNr", BindingFlags.Instance | BindingFlags.Public);
            guestTypePhoneNrProperty.SetValue(guest, guestEntity.PhoneNr);

            return guest;
        }

        private static Room ToDomain(RoomEntity roomEntity)
        {
            var roomType = typeof(Room);
            var ctor = roomType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, new Type[0]);
            var room = (Room)ctor.Invoke(null);

            var roomIdBackField = roomType.GetField("_id", BindingFlags.Instance | BindingFlags.NonPublic);
            roomIdBackField.SetValue(room, roomEntity.Id);

            var roomRoomNrProperty = roomType.GetProperty("RoomNr", BindingFlags.Instance | BindingFlags.Public);
            roomRoomNrProperty.SetValue(room, roomEntity.RoomNr);

            return room;
        }
    }
}