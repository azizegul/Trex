using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Trex.Service.Logger;

namespace Api.Logger
{
    public class LoggerProvider : ILoggerProvider
    {
        private readonly ILoggerService _loggerService;
        public LoggerProvider(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public ILogger CreateLogger(string categoryName) => new Logger(_loggerService);
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
