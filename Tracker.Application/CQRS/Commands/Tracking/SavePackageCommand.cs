using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tracker.Contracts.Tracking;
using Tracker.Models;

namespace Tracker.Application.CQRS.Commands.Tracking
{
    public class SavePackageCommand: IRequest<Unit>
    {
        public string TrackingId { get; set; }
        public string UserId { get; set; }
        public PackageDelivererType PackageDeliverer { get; set; }
        private DateTime Date { get; set; }
    }

    public class SavePackageCommandHandler : IRequestHandler<SavePackageCommand, Unit>
    {
        private readonly IPackageService _packageService;

        public SavePackageCommandHandler(IPackageService packageService)
        {
            _packageService = packageService;
        }
        public Task<Unit> Handle(SavePackageCommand request, CancellationToken cancellationToken)
        {
            _packageService.Save(request.TrackingId, request.UserId);
            return Unit.Task;
            // throw new NotImplementedException();
        }
    }
}