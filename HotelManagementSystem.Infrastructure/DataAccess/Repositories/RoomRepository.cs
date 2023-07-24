using Dapper;
using HotelManagementSystem.Core.Domain.Services;
using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Infrastructure.DataAccess.Entities;
using HotelManagementSystem.Infrastructure.DataAccess.Factories;
using HotelManagementSystem.Infrastructure.DataAccess.Mappers;

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

            var parameters = new { RoomNr = roomNr };

            using var conn = _sqlConnectionFactory.CreateSqlConnection();
            var roomEntity = conn.QuerySingleOrDefault<RoomEntity>(sql, parameters);
            var room = roomEntity.ToDomain();
            return room;
        }
    }
}
