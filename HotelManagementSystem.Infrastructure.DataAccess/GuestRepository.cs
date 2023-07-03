using Dapper;
using HotelManagementSystem.Core.DomainModel;
using HotelManagementSystem.Core.DomainServices;

namespace HotelManagementSystem.Infrastructure.DataAccess
{
    public class GuestRepository : IGuestRepository
    {
        private readonly SqlConnectionFactory _sqlConnectionFactory;

        public GuestRepository(SqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public void Create(Guest guest)
        {
            var sql = @"INSERT INTO guest
                        VALUES (@Id, @FirstName, @LastName, @PhoneNr)";

            var parameters = new
            {
                guest.Id,
                guest.FirstName,
                guest.LastName,
                guest.PhoneNr
            };

            using var conn = _sqlConnectionFactory.CreateSqlConnection();
            conn.Execute(sql, parameters);
        }
    }
}
