using System.Data.SqlClient;

namespace HotelManagementSystem.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly SqlConnection _conn;

        public RoomRepository(SqlConnection conn)
        {
            _conn = conn;
        }
    }
}
