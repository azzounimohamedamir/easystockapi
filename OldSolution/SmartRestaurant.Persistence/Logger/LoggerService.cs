using Microsoft.Extensions.Logging;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistence.Logger
{
    public class LoggerService<T> : ILoggerService<T>
    {
        private readonly ILogger<T> _logger;
        public LoggerService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogCritical(string message, params object[] args)
        {
            _logger.LogCritical(message, args);
           
        }

        public void LogDebug(string message, params object[] args)
        {
            
            _logger.LogDebug(message, args);
        }

        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogTrace(string message, params object[] args)
        {
            _logger.LogTrace(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
            
        }
    }
}
