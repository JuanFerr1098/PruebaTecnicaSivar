using AutoMapper;
using PruebaTecnicaSivar.Domain.Entity;
using PruebaTecnicaSivar.Domain.Repository;
using PruebaTecnicaSivar.Infrastructure.Context;
using PruebaTecnicaSivar.Infrastructure.Entity;

namespace PruebaTecnicaSivar.Infrastructure.Adapter
{
    public class CompanyRepositoryAdapter : BaseRepositoryAdapter<Company, Guid, CompanyEntity>, ICompanyRepository
    {
        public CompanyRepositoryAdapter(InfrastructureEFContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
