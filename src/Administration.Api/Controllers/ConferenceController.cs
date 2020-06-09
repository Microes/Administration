using Administration.Api.Dtoes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Administration.Api.Controllers
{
    [ApiController]
    [Route("Conference")]
    public class ConferenceController : Controller
    {
        private readonly IMediator _mediator;

        public ConferenceController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateConference([FromBody]CreateConferenceCommandDto command)
        {
            return Ok(await _mediator.Send(command.ToDomainCommand()));
        }
    }
}
