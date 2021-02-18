using Microsoft.Extensions.Logging;
using Tracker.Contracts.Tracking;

namespace Tracker.Application.CQRS.Commands.Packages
{
    public class BasePackageCommand
    {
        protected readonly IPackageService _packageService;
        protected readonly ILogger _logger;

        public BasePackageCommand(IPackageService packageService, ILoggerFactory loggerFactory)
        {
            _packageService = packageService;
            _logger = loggerFactory.CreateLogger("Packages");
        }
    }
}