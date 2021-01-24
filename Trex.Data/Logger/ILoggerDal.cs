using System;
using System.Data.SqlClient;

namespace Trex.Data
{
    public interface ILoggerDal
    {
        SqlConnection GetConnection();
        SqlCommand CreateCommand(string sql);
    }
}
