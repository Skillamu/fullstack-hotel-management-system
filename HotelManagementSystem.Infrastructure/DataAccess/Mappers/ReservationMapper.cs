using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Core.Domain.ValueObjects;
using HotelManagementSystem.Infrastructure.DataAccess.Tables;
using System.Reflection;

namespace HotelManagementSystem.Infrastructure.DataAccess.Mappers
{
    internal static class ReservationMapper
    {
        // NOTE!
        // Reflection is used here due to the lack of Dapper functionality when it comes to mapping multiple
        // tables to one object that is well encapsulated with private setters
        public static Reservation ToDomain(ReservationTable reservationTable, GuestTable guestTable, RoomTable roomTable, RoomTypeTable roomTypeTable)
        {
            var reservationType = typeof(Reservation);
            var ctor = reservationType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, new Type[0]);
            var reservation = (Reservation)ctor.Invoke(null);

            var reservationTypeIdBackField = reservationType.GetField("_id", BindingFlags.Instance | BindingFlags.NonPublic);
            reservationTypeIdBackField.SetValue(reservation, reservationTable.Id);

            var reservationTypeGuestProperty = reservationType.GetProperty("Guest", BindingFlags.Instance | BindingFlags.Public);
            reservationTypeGuestProperty.SetValue(reservation, ToDomain(guestTable));

            var reservationTypeRoomProperty = reservationType.GetProperty("Room", BindingFlags.Instance | BindingFlags.Public);
            reservationTypeRoomProperty.SetValue(reservation, RoomMapper.ToDomain(roomTable, roomTypeTable));

            var reservationTypeDateRangeProperty = reservationType.GetProperty("DateRange", BindingFlags.Instance | BindingFlags.Public);
            reservationTypeDateRangeProperty.SetValue(reservation, ToDomain(reservationTable.CheckInDate, reservationTable.CheckOutDate));

            var reservationTypeCreatedAtDateProperty = reservationType.GetProperty("CreatedAtDate", BindingFlags.Instance | BindingFlags.Public);
            reservationTypeCreatedAtDateProperty.SetValue(reservation, ToDomain(reservationTable.CreatedAtDate));

            var reservationTypeIsVerifiedProperty = reservationType.GetProperty("IsVerified", BindingFlags.Instance | BindingFlags.Public);
            reservationTypeIsVerifiedProperty.SetValue(reservation, reservationTable.IsVerified);

            return reservation;
        }

        private static Guest ToDomain(GuestTable guestTable)
        {
            var guestType = typeof(Guest);
            var ctor = guestType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, new Type[0]);
            var guest = (Guest)ctor.Invoke(null);

            var guestTypeIdBackField = guestType.GetField("_id", BindingFlags.Instance | BindingFlags.NonPublic);
            guestTypeIdBackField.SetValue(guest, guestTable.Id);

            var guestTypeFirstNameProperty = guestType.GetProperty("FirstName", BindingFlags.Instance | BindingFlags.Public);
            guestTypeFirstNameProperty.SetValue(guest, guestTable.FirstName);

            var guestTypeLastNameProperty = guestType.GetProperty("LastName", BindingFlags.Instance | BindingFlags.Public);
            guestTypeLastNameProperty.SetValue(guest, guestTable.LastName);

            var guestTypePhoneNrProperty = guestType.GetProperty("PhoneNr", BindingFlags.Instance | BindingFlags.Public);
            guestTypePhoneNrProperty.SetValue(guest, guestTable.PhoneNr);

            return guest;
        }

        private static DateRange ToDomain(DateTime checkInDate, DateTime checkOutDate)
        {
            var dateRangeType = typeof(DateRange);
            var ctor = dateRangeType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, new Type[] { typeof(DateTime), typeof(DateTime) });
            var dateRange = (DateRange)ctor.Invoke(new object[] { checkInDate, checkOutDate });

            return dateRange;
        }

        private static CreatedAtDate ToDomain(DateTime value)
        {
            var createdAtDateType = typeof(CreatedAtDate);
            var ctor = createdAtDateType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, new Type[] { typeof(DateTime) });
            var createdAtDate = (CreatedAtDate)ctor.Invoke(new object[] { value });

            return createdAtDate;
        }
    }
}