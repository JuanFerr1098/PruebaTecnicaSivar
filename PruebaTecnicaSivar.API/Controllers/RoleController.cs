using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Command;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;
using System.Net;

namespace PruebaTecnicaSivar.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateRole")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<RoleDetailResponse>> CreateRole([FromBody] CreateRoleCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
