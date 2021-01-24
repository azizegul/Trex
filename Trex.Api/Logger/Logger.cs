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
    public class Logger : ILogger
    {
        private readonly ILoggerService _loggerService;
        public Logger(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public IDisposable BeginScope<TState>(TState state) => null;
        public bool IsEnabled(LogLevel logLevel) => true;
        public async void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _loggerService.AddLog(logLevel.ToString(), state.ToString());
        }
    }
}
