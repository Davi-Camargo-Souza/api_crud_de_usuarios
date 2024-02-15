using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Data.Sqlite;

namespace SeboScrob.Persistence.Context
{
    public class DapperContext
    {
        private readonly string _connectionString;

        public DapperContext (string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqliteConnection(_connectionString);
        }
    }
}
