using Dapper;
using HotelManagementSystem.Core.Domain.Services;
using HotelManagementSystem.Infrastructure.DataAccess.Factories;
using HotelManagementSystem.Core.Domain.ValueObjects;
using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Infrastructure.DataAccess.Tables;
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

        public Room GetRoomWithinDateRange(RoomType roomType, DateRange dateRange)
        {
            var sql = @"SELECT room.id AS Id, room.room_nr AS RoomNr,
                        room_type_id AS Id, room_type.type AS Type,
                        room_type.has_city_view AS HasCityView,
                        room_type.has_bathtub AS HasBathtub 
                        FROM room
                        JOIN room_type ON room.room_type_id = room_type.id
                        LEFT JOIN reservation
                        ON room.id = reservation.room_id
                        AND reservation.check_in_date <= @CheckOutDate
                        AND reservation.check_out_date >= @CheckInDate
                        WHERE reservation.room_id IS NULL
                        AND room_type.type = @Type";

            var parameters = new
            {
                Type = roomType.Type,
                CheckInDate = dateRange.CheckInDate,
                CheckOutDate = dateRange.CheckOutDate
            };

            using var conn = _sqlConnectionFactory.CreateSqlConnection();
            var room = conn.Query<RoomTable, RoomTypeTable, Room>(sql, (roomTable, roomTypeTable) =>
            {
                return RoomMapper.ToDomain(roomTable, roomTypeTable);
            },
            param: parameters,
            splitOn: "Id").FirstOrDefault();

            return room;
        }

        public IEnumerable<RoomType> GetRoomTypes()
        {
            var sql = @"SELECT type AS Type, has_city_view AS HasCityView, has_bathtub AS HasBathtub
                        FROM room_type";

            using var conn = _sqlConnectionFactory.CreateSqlConnection();
            var roomTypes = conn.Query<RoomType>(sql);

            return roomTypes;
        }
    }
}