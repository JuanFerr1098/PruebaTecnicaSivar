using MediatR;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;

namespace PruebaTecnicaSivar.ApplicationDomain.Dto.Query
{
    public class FindAllUsersQuery : IRequest<List<UserDetailResponse>>
    {
    }
}
