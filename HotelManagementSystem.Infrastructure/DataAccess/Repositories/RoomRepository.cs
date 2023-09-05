using Dapper;
using HotelManagementSystem.Core.Domain.Services;
using HotelManagementSystem.Infrastructure.DataAccess.Factories;
using HotelManagementSystem.Core.Domain.ValueObjects;
using HotelManagementSystem.Core.Domain.Model;

namespace HotelManagementSystem.Infrastructure.DataAccess.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly SqlConnectionFactory _sqlConnectionFactory;

        public RoomRepository(SqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public Room GetRoomWithinDateRange(bool hasCityView, DateRange dateRange)
        {
            var sql = @"SELECT room.id AS _id, room.room_nr AS RoomNr, has_city_view AS HasCityView
                        FROM room
                        LEFT JOIN reservation
                        ON room.id = reservation.room_id
                        AND reservation.check_in_date <= @CheckOutDate
                        AND reservation.check_out_date >= @CheckInDate
                        WHERE reservation.room_id IS NULL
                        AND room.has_city_view = @HasCityView";

            var parameters = new
            {
                HasCityView = hasCityView,
                CheckInDate = dateRange.CheckInDate,
                CheckOutDate = dateRange.CheckOutDate
            };

            using var conn = _sqlConnectionFactory.CreateSqlConnection();
            var room = conn.QueryFirstOrDefault<Room>(sql, parameters);

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