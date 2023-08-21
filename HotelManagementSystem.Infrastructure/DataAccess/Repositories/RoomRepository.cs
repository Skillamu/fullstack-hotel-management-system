using Dapper;
using HotelManagementSystem.Core.Domain.Services;
using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Infrastructure.DataAccess.Entities;
using HotelManagementSystem.Infrastructure.DataAccess.Factories;
using HotelManagementSystem.Infrastructure.DataAccess.Mappers;
using HotelManagementSystem.Core.Domain.ValueObjects;

namespace HotelManagementSystem.Infrastructure.DataAccess.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly SqlConnectionFactory _sqlConnectionFactory;

        public RoomRepository(SqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public Room GetAvailableRoomWithinDateRange(short roomNr, DateRange dateRange)
        {
            var sql = @"SELECT room.id AS _id, room.room_nr AS RoomNr 
                        FROM room
                        LEFT JOIN reservation
                        ON room.id = reservation.room_id
                        AND reservation.check_in_date <= @CheckOutDate
                        AND reservation.check_out_date >= @CheckInDate
                        WHERE reservation.room_id IS NULL
                        AND room.room_nr = @RoomNr;";

            var parameters = new
            {
                RoomNr = roomNr,
                CheckInDate = dateRange.CheckInDate,
                CheckOutDate = dateRange.CheckOutDate
            };

            using var conn = _sqlConnectionFactory.CreateSqlConnection();
            var room = conn.QuerySingleOrDefault<Room>(sql, parameters);

            return room;
        }
    }
}
