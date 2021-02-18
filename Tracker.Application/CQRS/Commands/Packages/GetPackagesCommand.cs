using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Tracker.Contracts.Tracking;
using Tracker.Domain.Tracking;

namespace Tracker.Application.CQRS.Commands.Packages
{
    public class GetPackagesCommand : IRequest<List<Package>>
    {
        public string UserId { get; set; }
    }

    public class GetPackagesCommandHandler : BasePackageCommand, IRequestHandler<GetPackagesCommand, List<Package>>
    {
        public GetPackagesCommandHandler(IPackageService packageService, ILoggerFactory loggerFactory) : base(packageService,
            loggerFactory)
        {
            
        }


        public async Task<List<Package>> Handle(GetPackagesCommand request, CancellationToken cancellationToken)
        {
            var packages = await _packageService.GetAllByUserId(request.UserId);
            return packages.ToList();
        }
    }
}