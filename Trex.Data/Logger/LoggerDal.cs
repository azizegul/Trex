using System;
using System.Data.SqlClient;

namespace Trex.Data
{
    public class LoggerDal : ILoggerDal
    {
        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=TrexLog; Trusted_Connection=true");
            connection.Open();
            return connection;
        }

        public SqlCommand CreateCommand(string sql)
        {
            SqlCommand command = new SqlCommand(sql, GetConnection());
            return command;
        }
    }
}
