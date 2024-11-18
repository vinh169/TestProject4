using Oracle.ManagedDataAccess.Client;
using System.Data;
using TestProject.Model;
using TestProject.Repository.Interface;
using Dapper.Oracle;
using Dapper;

namespace TestProject.Repository
{
    public class UserRepository : IUserRepository
    {
        IConfiguration configuration;

        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public List<User> Get()
        {
            try
            {
                List<User> result = new List<User>();
                using (var conn = this.GetConnection())
                {
                    if (conn == null)
                    {
                        Console.WriteLine( "Connect failed");
                        return new List<User>();
                    }
                    conn.Open();
                    //Khai báo các tham số cho stored procedure
                    OracleDynamicParameters prams = new OracleDynamicParameters();
                    prams.Add("p_curs", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

                    // Gọi stored procedure "USER_MANAGEMENT.Get_User"
                    result = conn.Query<User>("USER_MANAGEMENT.Get_User", prams, commandType: CommandType.StoredProcedure).ToList();
                    
                    return result ?? new List<User>();
                }
            }
            catch (Exception ex) {
                Console.WriteLine("ERROR: " + ex.Message);
                return new List<User>();
            }
        }
        public IDbConnection GetConnection()
        {
            var connectionString = configuration.GetSection("OracleConnection")
                .GetSection("ConnectionString").Value;
            var conn = new OracleConnection(connectionString);
            return conn;
        }
    }
}
