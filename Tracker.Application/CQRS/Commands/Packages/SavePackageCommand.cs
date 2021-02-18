using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Tracker.Contracts.Tracking;
using Tracker.Models;

namespace Tracker.Application.CQRS.Commands.Packages
{
    public class SavePackageCommand: IRequest<Guid>
    {
        public string TrackingId { get; set; }
        public string UserId { get; set; }
        public PackageDelivererType PackageDeliverer { get; set; }
        private DateTime Date { get; set; }
    }

    public class SavePackageCommandHandler :BasePackageCommand, IRequestHandler<SavePackageCommand, Guid>
    {
        public SavePackageCommandHandler(IPackageService packageService, ILoggerFactory loggerFactory) : base(packageService, loggerFactory)
        {
        }
        public async Task<Guid> Handle(SavePackageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var savedId = await _packageService.Save(request.TrackingId, request.UserId);
                _logger.LogInformation($"Saved {savedId} by {request.UserId}");
                return savedId;
            }
            catch (Exception exceptionPerformingAction)
            {
                _logger.LogError(exceptionPerformingAction.Message, exceptionPerformingAction);
                throw;
            }
        }
    }
}