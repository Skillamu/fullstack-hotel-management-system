using Dapper;
using HotelManagementSystem.Core.Domain.Services;
using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Infrastructure.DataAccess.Factories;

namespace HotelManagementSystem.Infrastructure.DataAccess.Repositories
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
                Id = guest.Id,
                FirstName = guest.FirstName,
                LastName = guest.LastName,
                PhoneNr = guest.PhoneNr
            };

            using var conn = _sqlConnectionFactory.CreateSqlConnection();
            conn.Execute(sql, parameters);
        }

        public Guest GetGuestByPhoneNr(string phoneNr)
        {
            var sql = @"SELECT id AS Id, first_name AS FirstName, last_name AS LastName, phone_nr AS PhoneNr
                        FROM guest WHERE phone_nr = @PhoneNr";

            var parameters = new { PhoneNr = phoneNr };

            using var conn = _sqlConnectionFactory.CreateSqlConnection();
            var guest = conn.QuerySingleOrDefault<Guest>(sql, parameters);

            return guest;
        }
    }
}
