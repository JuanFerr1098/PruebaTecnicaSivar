using MediatR;

namespace PruebaTecnicaSivar.ApplicationDomain.Dto
{
    public class UserDetailQuery :IRequest<UserDetailResponse>
    {
        public Guid Id { get; set; }
    }
}
