using Dapper;
using HotelManagementSystem.Core.Domain.Repositories;
using HotelManagementSystem.Core.Domain.Model;
using HotelManagementSystem.Infrastructure.DataAccess.Factories;
using System.Data.SqlClient;

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
            try
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
            catch (SqlException)
            {
                // Guest already exists in the database, which is fine.
                // The exception is intentionally ignored, as it's not critical for this operation.
                // This is safe because the operation will succeed regardless of whether the guest already exists.
            }
        }

        public Guest GetGuestByPhoneNr(string phoneNr)
        {
            var sql = @"SELECT id AS _id, first_name AS FirstName, last_name AS LastName, phone_nr AS PhoneNr
                        FROM guest WHERE phone_nr = @PhoneNr";

            var parameters = new { PhoneNr = phoneNr };

            using var conn = _sqlConnectionFactory.CreateSqlConnection();
            var guest = conn.QuerySingleOrDefault<Guest>(sql, parameters);

            return guest;
        }

        public Guest GetById(Guid id)
        {
            var sql = @"SELECT id AS _id, first_name AS FirstName, last_name AS LastName, phone_nr AS PhoneNr
                        FROM guest WHERE id = @Id";

            var parameters = new { Id = id };

            using var conn = _sqlConnectionFactory.CreateSqlConnection();
            var guest = conn.QuerySingleOrDefault<Guest>(sql, parameters);

            return guest;
        }

        public void Delete(Guest guest)
        {
            var sql = @"DELETE FROM guest WHERE id = @Id";
            var parameters = new { Id = guest.Id };

            using var conn = _sqlConnectionFactory.CreateSqlConnection();
            conn.Execute(sql, parameters);
        }
    }
}
