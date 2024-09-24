using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Command;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Query;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;
using PruebaTecnicaSivar.ApplicationDomain.Handler;
using System.Net;

namespace PruebaTecnicaSivar.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetUsers")]
        [ProducesResponseType(typeof(IEnumerable<UserDetailResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<UserDetailResponse>>> GetAllUsers()
        {
            var query = new FindAllUsersQuery();
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        [HttpGet("{id}", Name = "UserById")]
        [ProducesResponseType(typeof(UserDetailResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UserDetailResponse>> GetById(Guid id)
        {
            var query = new FindUserByIdQuery(id);
            var user = await _mediator.Send(query);
            return Ok(user);
        }

        [HttpPost(Name = "CreateUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<UserDetailResponse>> CreateUser([FromBody] CreateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("/AssignRole", Name = "AssignRole")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<UserDetailResponse>> AssignRole([FromBody] AssignRoleCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
