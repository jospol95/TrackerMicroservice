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
        
        [HttpGet("getDeliverersNameQuery")]
        public async Task<IActionResult> GetDeliverersNameQuery()
        {
            return Ok(null);
        }

        [HttpPost("LookForPackage")]
        public async Task<IActionResult> LookForPackage(LookForPackageCommand command)
        {
            await _mediator.Send(command);
            return Ok("yei");
        }

        [HttpPost("SavePackage")]
        public async Task<IActionResult> SavePackage(SavePackageCommand command)
        {
            await _mediator.Send(command);
            return Ok("saved");
        }
    }
}