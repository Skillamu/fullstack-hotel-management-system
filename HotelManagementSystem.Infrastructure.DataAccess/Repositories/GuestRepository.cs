using Dapper;
using HotelManagementSystem.Core.DomainModel;
using HotelManagementSystem.Core.DomainServices;
using HotelManagementSystem.Infrastructure.DataAccess.Factories;
using HotelManagementSystem.Infrastructure.DataAccess.Mappers;

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

            var guestEntity = guest.ToEntity();

            using var conn = _sqlConnectionFactory.CreateSqlConnection();
            conn.Execute(sql, guestEntity);
        }
    }
}
