using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.Application.CQRS.Commands.Tracking;

namespace Tracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrackingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TrackingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<IActionResult> GetDeliverersNameQuery()
        {
            return Ok(null);
        }

        public async Task<IActionResult> LookForPackage(LookForPackageCommand command)
        {
            await _mediator.Send(command);
            return Ok("yei");
        }

        public async Task<IActionResult> SavePackageCommand(SavePackageCommand command)
        {
            await _mediator.Send(command);
            return Ok("yei");
        }
    }
}