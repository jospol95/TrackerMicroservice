using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Tracker.Application.Exceptions;
using Tracker.Contracts.Tracking;
using Tracker.Domain.Tracking;

namespace Tracker.Application.CQRS.Commands.Packages
{
    public class DeletePackageCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
    }
    
    public class DeletePackageCommandHandler : BasePackageCommand, IRequestHandler<DeletePackageCommand, bool>
    {
        public DeletePackageCommandHandler(IPackageService packageService, ILoggerFactory loggerFactory) : base(packageService,
            loggerFactory)
        {
            
        }

        public async Task<bool> Handle(DeletePackageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var packageToDelete = await _packageService.Get(request.Id);
                if (packageToDelete == null)
                {
                    var message = $"Package {request.Id} not found";
                    _logger.LogWarning(message);
                    throw new RecordNotFoundException(message);
                }

                if (packageToDelete.UserId != request.UserId)
                {
                    var message = $"User, {request.UserId} attempted to delete {request.Id}";
                    _logger.LogCritical(message);
                    throw new UnauthorizedAccessException();
                }

                await _packageService.Delete(packageToDelete);
                _logger.LogInformation($"Deleted {packageToDelete.Id} by {request.UserId}");
                return true;
            }
            catch (Exception exceptionPerformingAction)
            {
                _logger.LogError(exceptionPerformingAction.Message, exceptionPerformingAction);
                throw;
            }
          
        }
    }
}