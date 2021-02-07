using Microsoft.Extensions.Logging;

namespace Tracker.Application.CQRS.Commands.Tracking
{
    public class TrackingBaseCommand
    {
        protected readonly ILogger _logger;

        protected TrackingBaseCommand(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("TrackingCommand");
        }
        
        
    }
}