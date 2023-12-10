using Microsoft.Extensions.Caching.Memory;
using System.Data.Common;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Sparta.Patient.API.DataAccessLayers.Repositories
{
    public class PatientDbContext
    {
        private readonly DbConnection _dbConnection;
        public IDbConnection connection;

        public PatientDbContext(IConfiguration configuration)
        {
            string connectionString = configuration.GetSection("DBInfo:" + "ConnectionString").Value;
            if (connectionString == null)
                throw new Exception($"Failed to find connection string named 'ConnectionString' in appsettings.json or web.config.");
            this.connection = Create(connectionString);
            this.connection.Open();
        }

        public IDbConnection Create(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
