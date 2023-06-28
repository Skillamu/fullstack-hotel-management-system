namespace HotelManagementSystem.Infrastructure.DataAccess
{
    public class ReservationRepository
    {
        private readonly SqlConnectionFactory _sqlConnectionFactory;

        public ReservationRepository(SqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
    }
}
