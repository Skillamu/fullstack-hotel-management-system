using Dapper;
using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Core.Domain.Repositories;
using HotelManagementSystem.Infrastructure.DataAccess.Factories;
using HotelManagementSystem.Infrastructure.DataAccess.Mappers;
using HotelManagementSystem.Infrastructure.DataAccess.Tables;

namespace HotelManagementSystem.Infrastructure.DataAccess.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly SqlConnectionFactory _sqlConnectionFactory;

        public ReservationRepository(SqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public void Create(Reservation reservation)
        {
            var sql = @"INSERT INTO reservation VALUES (@Id, @GuestId, @RoomId, @CheckInDate, @CheckOutDate, @CreatedAtDate, @IsVerified)";

            var parameters = new
            {
                Id = reservation.Id,
                GuestId = reservation.Guest.Id,
                RoomId = reservation.Room.Id,
                CheckInDate = reservation.DateRange.CheckInDate,
                CheckOutDate = reservation.DateRange.CheckOutDate,
                CreatedAtDate = reservation.CreatedAtDate.Value,
                IsVerified = reservation.IsVerified
            };

            using var conn = _sqlConnectionFactory.CreateSqlConnection();
            conn.Execute(sql, parameters);
        }

        public Reservation GetUnverifiedReservationByGuestPhoneNr(string phoneNr)
        {
            var sql = @"SELECT reservation.id AS Id, check_in_date AS CheckInDate, check_out_date AS CheckOutDate,
                        created_at_date AS CreatedAtdate, is_verified AS IsVerified,
                        guest_id AS Id, first_name AS FirstName, last_name AS LastName, phone_nr AS PhoneNr,
                        room_id AS Id, room_nr AS RoomNr, room_type_id AS Id, room_type.type AS Type,
                        has_city_view AS HasCityView, has_bathtub AS HasBathtub
                        FROM reservation
                        JOIN guest ON reservation.guest_id = guest.id
                        JOIN room ON reservation.room_id = room.id
                        JOIN room_type ON room.room_type_id = room_type.id
                        WHERE phone_nr = @PhoneNr AND is_verified = 'False'";

            using var conn = _sqlConnectionFactory.CreateSqlConnection();

            var reservation = conn.Query<ReservationTable, GuestTable, RoomTable, RoomTypeTable, Reservation>(
                sql, (reservationTable, guestTable, roomTable, roomTypeTable) =>
            {
                return ReservationMapper.ToDomain(reservationTable, guestTable, roomTable, roomTypeTable);
            },
            param: new { PhoneNr = phoneNr },
            splitOn: "Id, Id, Id").SingleOrDefault();

            return reservation;
        }

        public Reservation GetById(Guid id)
        {
            var sql = @"SELECT reservation.id AS Id, check_in_date AS CheckInDate, check_out_date AS CheckOutDate,
                        created_at_date AS CreatedAtdate, is_verified AS IsVerified,
                        guest_id AS Id, first_name AS FirstName, last_name AS LastName, phone_nr AS PhoneNr,
                        room_id AS Id, room_nr AS RoomNr, room_type_id AS Id, room_type.type AS Type,
                        has_city_view AS HasCityView, has_bathtub AS HasBathtub
                        FROM reservation
                        JOIN guest ON reservation.guest_id = guest.id
                        JOIN room ON reservation.room_id = room.id
                        JOIN room_type ON room.room_type_id = room_type.id
                        WHERE reservation.id = @Id";

            using var conn = _sqlConnectionFactory.CreateSqlConnection();

            var reservation = conn.Query<ReservationTable, GuestTable, RoomTable, RoomTypeTable, Reservation>(
                sql, (reservationTable, guestTable, roomTable, roomTypeTable) =>
            {
                return ReservationMapper.ToDomain(reservationTable, guestTable, roomTable, roomTypeTable);
            },
            param: new { Id = id },
            splitOn: "Id, Id, Id").SingleOrDefault();

            return reservation;
        }

        public IEnumerable<Reservation> GetAllByGuestId(Guid guestId)
        {
            var sql = @"SELECT reservation.id AS Id, check_in_date AS CheckInDate, check_out_date AS CheckOutDate,
                        created_at_date AS CreatedAtdate, is_verified AS IsVerified,
                        guest_id AS Id, first_name AS FirstName, last_name AS LastName, phone_nr AS PhoneNr,
                        room_id AS Id, room_nr AS RoomNr, room_type_id AS Id, room_type.type AS Type,
                        has_city_view AS HasCityView, has_bathtub AS HasBathtub
                        FROM reservation
                        JOIN guest ON reservation.guest_id = guest.id
                        JOIN room ON reservation.room_id = room.id
                        JOIN room_type ON room.room_type_id = room_type.id
                        WHERE guest.id = @Id";

            using var conn = _sqlConnectionFactory.CreateSqlConnection();

            var reservations = conn.Query<ReservationTable, GuestTable, RoomTable, RoomTypeTable, Reservation>(
                sql, (reservationTable, guestTable, roomTable, roomTypeTable) =>
                {
                    return ReservationMapper.ToDomain(reservationTable, guestTable, roomTable, roomTypeTable);
                },
            param: new { Id = guestId },
            splitOn: "Id, Id, Id");

            return reservations;
        }

        public void Update(Reservation reservation)
        {
            var sql = @"UPDATE reservation SET 
                        check_in_date = @CheckInDate,
                        check_out_date = @CheckOutDate,
                        is_verified = @IsVerified
                        WHERE id = @Id";

            var parameters = new
            {
                Id = reservation.Id,
                CheckInDate = reservation.DateRange.CheckInDate,
                CheckOutDate = reservation.DateRange.CheckOutDate,
                IsVerified = reservation.IsVerified
            };

            using var conn = _sqlConnectionFactory.CreateSqlConnection();
            conn.Execute(sql, parameters);
        }

        public void Delete(Reservation reservation)
        {
            var sql = @"DELETE FROM reservation WHERE id = @Id";
            var parameters = new { Id = reservation.Id };

            using var conn = _sqlConnectionFactory.CreateSqlConnection();
            conn.Execute(sql, parameters);
        }
    }
}