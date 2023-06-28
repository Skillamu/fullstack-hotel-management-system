﻿using System.Data.SqlClient;

namespace HotelManagementSystem.Infrastructure.DataAccess
{
    public class SqlConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection CreateSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}