namespace HotelManagementSystem.Infrastructure.DataAccess
{
    public class GuestRepository
    {
        private readonly SqlConnectionFactory _sqlConnectionFactory;

        public GuestRepository(SqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
    }
}
