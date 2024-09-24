using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Command;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;
using System.Net;

namespace PruebaTecnicaSivar.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateCompany")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<CompanyDetailResponse>> CreateUser([FromBody] CreateCompanyCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("/AssignUser", Name = "AssingUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<CompanyDetailResponse>> AssignUser([FromBody] AssignUserToCompanyCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
