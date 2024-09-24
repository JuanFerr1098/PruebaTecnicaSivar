using MediatR;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;

namespace PruebaTecnicaSivar.ApplicationDomain.Dto.Query
{
    public class FindUserByIdQuery : IRequest<UserDetailResponse>
    {
        public Guid Id { get; set; }
        public FindUserByIdQuery(Guid id)
        {
            Id = id;
        }

    }
}
