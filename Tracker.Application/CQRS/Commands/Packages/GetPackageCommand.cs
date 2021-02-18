using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Tracker.Application.Exceptions;
using Tracker.Contracts.Tracking;
using Tracker.Domain.Tracking;
using Tracker.Models;

namespace Tracker.Application.CQRS.Commands.Packages
{
    public class GetPackageCommand : IRequest<Package>
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        public GetPackageCommand(string packageId, string userId)
        {
            Id = packageId;
            UserId = userId;
        }
        
    }

    public class LookForPackageCommandHandler : BasePackageCommand, IRequestHandler<GetPackageCommand, Package>
    {
        public LookForPackageCommandHandler(IPackageService packageService, ILoggerFactory loggerFactory) : base(packageService, loggerFactory)
        {
        }
        public async Task<Package> Handle(GetPackageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var package = await _packageService.Get(new Guid(request.Id));
                if (package == null)
                {
                    var message = $"Package {request.Id} not found";
                    _logger.LogWarning(message);
                    throw new RecordNotFoundException(message);
                }

                if (request.UserId != package.UserId)
                {
                    var message = $"User, {request.UserId} doesn't have access to {request.Id}";
                    _logger.LogWarning(message);
                    throw new UnauthorizedAccessException(message);
                }

                return package;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
        }
        
        
    }
}