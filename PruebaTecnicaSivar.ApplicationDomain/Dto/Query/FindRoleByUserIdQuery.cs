using MediatR;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;

namespace PruebaTecnicaSivar.ApplicationDomain.Dto.Query
{
    public class FindRoleByUserIdQuery : IRequest<RoleDetailResponse>
    {
        public Guid Id { get; set; }
        public FindRoleByUserIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
