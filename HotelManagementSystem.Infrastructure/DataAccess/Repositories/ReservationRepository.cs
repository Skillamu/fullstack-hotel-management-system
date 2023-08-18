using Dapper;
using HotelManagementSystem.Core.Domain.Services;
using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Infrastructure.DataAccess.Factories;
using HotelManagementSystem.Infrastructure.DataAccess.Mappers;

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
    }
}