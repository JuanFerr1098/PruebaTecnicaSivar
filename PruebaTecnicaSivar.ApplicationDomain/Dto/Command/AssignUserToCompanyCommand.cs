using MediatR;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;

namespace PruebaTecnicaSivar.ApplicationDomain.Dto.Command
{
    public class AssignUserToCompanyCommand : IRequest<CompanyDetailResponse>
    {
        public Guid IdUser { get; set; }
        public Guid IdCompany { get; set; }

        public AssignUserToCompanyCommand(Guid idUser, Guid idCompany)
        {
            IdUser = idUser;
            IdCompany = idCompany;
        }
    }
}
