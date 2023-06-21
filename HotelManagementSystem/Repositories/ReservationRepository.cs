using System.Data.SqlClient;

namespace HotelManagementSystem.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly SqlConnection _conn;

        public ReservationRepository(SqlConnection conn)
        {
            _conn = conn;
        }
    }
}
