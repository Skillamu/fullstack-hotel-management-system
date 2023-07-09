using Dapper;
using HotelManagementSystem.Core.DomainServices;

namespace HotelManagementSystem.Infrastructure.DataAccess
{
    public class RoomRepository : IRoomRepository
    {
        private readonly SqlConnectionFactory _sqlConnectionFactory;

        public RoomRepository(SqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public Guid GetRoomByRoomNr(short roomNr)
        {
            var sql = @"SELECT id FROM room WHERE room_nr = @RoomNr";

            var parameters = new
            {
                RoomNr = roomNr
            };

            using var conn = _sqlConnectionFactory.CreateSqlConnection();
            var id = conn.QuerySingleOrDefault<Guid>(sql, parameters);
            return id;
        }
    }
}
