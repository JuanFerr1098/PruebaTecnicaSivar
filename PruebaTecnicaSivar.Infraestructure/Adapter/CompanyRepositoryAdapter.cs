using PruebaTecnicaSivar.Domain.Entity;
using PruebaTecnicaSivar.Domain.Repository;
using PruebaTecnicaSivar.Infrastructure.Context;

namespace PruebaTecnicaSivar.Infrastructure.Adapter
{
    public class CompanyRepositoryAdapter : BaseRepositoryAdapter<Company, Guid>, ICompanyRepository
    {
        public CompanyRepositoryAdapter(InfrastructureEFContext context) : base(context)
        {
        }
    }
}
