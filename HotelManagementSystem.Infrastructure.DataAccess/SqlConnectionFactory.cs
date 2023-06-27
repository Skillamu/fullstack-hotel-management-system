using System.Data.SqlClient;

namespace HotelManagementSystem.Infrastructure.DataAccess
{
    internal class SqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}