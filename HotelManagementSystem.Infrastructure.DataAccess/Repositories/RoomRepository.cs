using Dapper;
using HotelManagementSystem.Core.DomainModel;
using HotelManagementSystem.Core.DomainServices;
using HotelManagementSystem.Infrastructure.DataAccess.Factories;

namespace HotelManagementSystem.Infrastructure.DataAccess.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly SqlConnectionFactory _sqlConnectionFactory;

        public RoomRepository(SqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public Room GetRoomByRoomNr(short roomNr)
        {
            var sql = @"SELECT id AS Id, room_nr AS RoomNr FROM room WHERE room_nr = @RoomNr";

            var parameters = new
            {
                RoomNr = roomNr
            };

            using var conn = _sqlConnectionFactory.CreateSqlConnection();
            var room = conn.QuerySingleOrDefault<Room>(sql, parameters);
            return room;
        }
    }
}
