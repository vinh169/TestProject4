using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace TestProject.Repository
{
    public class TestConnectionRepository
    {
        IConfiguration configuration;

        public TestConnectionRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string TestConnection()
        {
            using (var conn = this.GetConnection())
            {
                if (conn == null)
                {
                    return "Connect failed";
                }
                return "Connect success";
            }
        }

        public IDbConnection GetConnection()
        {
            //Đọc chuỗi kết nối từ appsettings.json qua IConfiguration.
            var connectionString = configuration.GetSection("OracleConnection")
                .GetSection("ConnectionString").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }
    }
}
