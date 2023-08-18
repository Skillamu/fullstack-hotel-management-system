using Dapper;
using HotelManagementSystem.Core.Domain.Services;
using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Infrastructure.DataAccess.Factories;
using HotelManagementSystem.Infrastructure.DataAccess.Mappers;
using HotelManagementSystem.Infrastructure.DataAccess.Entities;

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

        public Reservation? GetUnverifiedReservationByPhoneNr(string phoneNr)
        {
            var sql = @"SELECT reservation.id AS Id, check_in_date AS CheckInDate, check_out_date AS CheckOutDate,
                        created_at_date AS CreatedAtdate, is_verified AS IsVerified,
                        guest_id AS Id, first_name AS FirstName, last_name AS LastName, phone_nr AS PhoneNr,
                        room_id AS Id, room_nr AS RoomNr
                        FROM reservation
                        JOIN guest ON reservation.guest_id = guest.id
                        JOIN room ON reservation.room_id = room.id
                        WHERE phone_nr = @PhoneNr AND is_verified = 'False'";

            using var conn = _sqlConnectionFactory.CreateSqlConnection();

            var reservation = conn.Query<ReservationEntity, GuestEntity, RoomEntity, Reservation>(sql, (reservationEntity, guestEntity, roomEntity) =>
            {
                return ReservationMapper.ToDomain(reservationEntity, guestEntity, roomEntity);
            },
            param: new { PhoneNr = phoneNr },
            splitOn: "Id, Id").SingleOrDefault();

            return reservation;
        }
    }
}