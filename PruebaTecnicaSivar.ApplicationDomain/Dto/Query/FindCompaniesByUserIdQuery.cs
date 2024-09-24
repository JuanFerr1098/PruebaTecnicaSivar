using MediatR;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;

namespace PruebaTecnicaSivar.ApplicationDomain.Dto.Query
{
    public class FindCompaniesByUserIdQuery :IRequest<List<CompanyDetailResponse>>
    {
        public Guid Id { get; set; }
        public FindCompaniesByUserIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
