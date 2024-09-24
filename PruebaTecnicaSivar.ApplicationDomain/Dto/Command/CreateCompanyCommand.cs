using MediatR;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;

namespace PruebaTecnicaSivar.ApplicationDomain.Dto.Command
{
    public class CreateCompanyCommand : IRequest<CompanyDetailResponse>
    {
        public string CompanyName { get; set; } = string.Empty;
    }
}
