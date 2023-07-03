using Dapper;
using HotelManagementSystem.Core.DomainModel;
using HotelManagementSystem.Core.DomainServices;

namespace HotelManagementSystem.Infrastructure.DataAccess
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
            var sql = @"INSERT INTO reservation VALUES (@Id, @GuestId, @RoomId)";

            var parameters = new
            {
                Id = reservation.Id,
                GuestId = reservation.Guest.Id,
                RoomId = reservation.Room.Id
            };

            using var conn = _sqlConnectionFactory.CreateSqlConnection();
            conn.Execute(sql, parameters);
        }
    }
}