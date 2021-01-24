using System;
using System.Collections.Generic;
using System.Text;

namespace Trex.Service.Logger
{
    public interface ILoggerService
    {
        void AddLog(string level,string message);
    }
}
