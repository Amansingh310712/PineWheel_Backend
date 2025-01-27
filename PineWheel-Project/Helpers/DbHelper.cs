using System.Data;
using Microsoft.Data.SqlClient;

namespace PineWheel_Project.Helpers
{
    public class DbHelper
    {
        private readonly IConfiguration configuration;
        private readonly string _connectionString;

        public DbHelper(IConfiguration configuration)

        {
            this.configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public SqlConnection GetSqlConnection() => new SqlConnection(_connectionString);
    }
}
