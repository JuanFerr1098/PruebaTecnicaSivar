using PruebaTecnicaSivar.Domain.Entity;
using PruebaTecnicaSivar.DomainCommon.Repository;

namespace PruebaTecnicaSivar.Domain.Repository
{
    public interface ICompanyRepository : IBaseAsyncRepository<Company, Guid>
    {
    }
}
