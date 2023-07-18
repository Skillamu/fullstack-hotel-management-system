using Dapper;
using HotelManagementSystem.Core.DomainModel;
using HotelManagementSystem.Core.DomainServices;
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
            var sql = @"INSERT INTO reservation VALUES (@Id, @GuestId, @RoomId)";

            var reservationEntity = reservation.ToEntity();

            using var conn = _sqlConnectionFactory.CreateSqlConnection();
            conn.Execute(sql, reservationEntity);
        }
    }
}