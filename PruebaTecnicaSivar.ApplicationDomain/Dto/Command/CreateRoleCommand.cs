using MediatR;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;

namespace PruebaTecnicaSivar.ApplicationDomain.Dto.Command
{
    public class CreateRoleCommand : IRequest<RoleDetailResponse> 
    {
        public string RoleName { get; set; } = string.Empty;
    }
}
