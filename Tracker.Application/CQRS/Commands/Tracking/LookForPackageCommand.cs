using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Tracker.Models;

namespace Tracker.Application.CQRS.Commands.Tracking
{
    public class LookForPackageCommand : IRequest<bool>
    {
        public string TrackingId { get; set; }
        public int UserId { get; set; }
        public PackageDelivererType PackageDeliverer { get; set; }
        
    }

    public class LookForPackageCommandHandler : TrackingBaseCommand, IRequestHandler<LookForPackageCommand, bool>
    {
        protected LookForPackageCommandHandler(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }
        public Task<bool> Handle(LookForPackageCommand request, CancellationToken cancellationToken)
        {
            // _logger.Log("LookForPackageCommandExecuted",);
            throw new System.NotImplementedException();
        }
        
        
    }
}