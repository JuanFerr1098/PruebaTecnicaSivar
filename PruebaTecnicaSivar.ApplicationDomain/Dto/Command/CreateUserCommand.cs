using MediatR;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;

namespace PruebaTecnicaSivar.ApplicationDomain.Dto.Command
{
    public class CreateUserCommand : IRequest<UserDetailResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
