using Microsoft.Data.SqlClient;
using System.Data;

namespace Sparta.Patient.API.DataAccessLayers.Repositories
{
    internal class DbConnection
    {
        private readonly string _connectionString;
        private readonly string _name;

        public DbConnection(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new AccessViolationException("configuration");
            }
            this._name = "ConnectionString";
            this._connectionString = configuration.GetSection("DBInfo:" + this._name).Value;
            if (this._connectionString == null)
            {
                throw new Exception($"Failed to find connection string named '{this._name}' in appsetting.json or wen config.");
            }
        }
        public IDbConnection Create()
        {
            SqlConnection connection = new SqlConnection(this._connectionString);
            if (connection == null)
            {
                throw new Exception($"Failed to create a connection using the connection string named '{this._name}' in appsetting.json or wen config.");
            }
            return connection;
        }
    }
}
