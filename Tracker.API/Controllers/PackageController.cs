using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tracker.Application.CQRS.Commands.Packages;
using Tracker.Application.Exceptions;

namespace Tracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PackageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id, string userId)
        {
            try
            {
                var getCommand = new GetPackageCommand(id, userId);
                var package = await _mediator.Send(getCommand);
                return Ok(package);
            }
            catch (RecordNotFoundException recordNotFoundException)
            {
                return NotFound(recordNotFoundException.Message);
            }
            catch (UnauthorizedAccessException unauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(GetPackagesCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok("yei");
            }
            catch (Exception exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(SavePackageCommand command)
        {
            try
            {
                var savedId = await _mediator.Send(command);
                return Ok(savedId);
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(GetPackageCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (UnauthorizedAccessException unauthorizedToPerformActionException)
            {
                return Unauthorized();
            }
            catch (Exception exception)
            {
                return StatusCode(500, "An error occurred");
            }
        }
    }
}