using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Contracts.Logging;
using Microsoft.Extensions.Logging;

namespace HrLeaveManagement.InfraStructure.Logging
{
    public class LoggerAdapter <T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;
        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }
        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message , args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message , args);
        }
    }
}
