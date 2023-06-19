using Dapper;
using HotelManagementSystem.Models;
using System.Data.SqlClient;

namespace HotelManagementSystem.Repository
{
    public class GuestRepository : IGuestRepository
    {
        private readonly SqlConnection _conn;

        public GuestRepository(SqlConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Guest> GetAll()
        {
            var sql = @"SELECT
                        id AS Id,
                        first_name AS FirstName,
                        last_name AS LastName,
                        phone_nr AS PhoneNr
                        FROM guest";

            var guests = _conn.Query<Guest>(sql);

            return guests;
        }
    }
}