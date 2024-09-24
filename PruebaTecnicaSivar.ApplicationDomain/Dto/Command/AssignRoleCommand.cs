using MediatR;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;

namespace PruebaTecnicaSivar.ApplicationDomain.Dto.Command
{
    public class AssignRoleCommand : IRequest<UserDetailResponse>
    {
        public Guid IdUser { get; set; }
        public Guid IdRole { get; set; }

        public AssignRoleCommand(Guid idUser, Guid idRole)
        {
            IdUser = idUser;
            IdRole = idRole;
        }
    }
}
