using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Trex.Data;

namespace Trex.Service.Logger
{
    public class LoggerService : ILoggerService
    {
        private readonly ILoggerDal _loggerDal;
        public LoggerService(ILoggerDal loggerDal)
        {
            _loggerDal = loggerDal;
        }

        public void AddLog(string level, string message)
        {
            var cmd = _loggerDal.CreateCommand("Insert Into Log (Level,Message) values (@level,@message)");
            cmd.Parameters.Add(new SqlParameter("@level", level));
            cmd.Parameters.Add(new SqlParameter("@message", message));

            cmd.ExecuteNonQuery();
        }
    }
}