using Dapper;
using HotelManagementSystem.Models.Entities;
using HotelManagementSystem.Models.Dtos;
using System.Data.SqlClient;

namespace HotelManagementSystem.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly SqlConnection _conn;

        public GuestRepository(SqlConnection conn)
        {
            _conn = conn;
        }

        public void Insert(GuestDto guestDto)
        {
            var guest = new Guest(Guid.NewGuid(), guestDto.FirstName, guestDto.LastName, guestDto.PhoneNr);

            var sql = @"INSERT INTO guest
                        VALUES (@Id, @FirstName, @LastName, @PhoneNr)";

            var parameters = new
            {
                guest.Id,
                guest.FirstName,
                guest.LastName,
                guest.PhoneNr
            };

            _conn.Execute(sql, parameters);
        }
    }
}