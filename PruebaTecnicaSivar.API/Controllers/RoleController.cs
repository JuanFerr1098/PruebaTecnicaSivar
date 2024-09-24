using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Command;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Query;
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

        [HttpGet("/FindRoleByUserId/{idUser}", Name = "FindRoleByUserId")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<RoleDetailResponse>> FindRoleByUserId(Guid idUser)
        {
            var query = new FindRoleByUserIdQuery(idUser);
            var role = await _mediator.Send(query);
            return Ok(role);
        }

    }
}
