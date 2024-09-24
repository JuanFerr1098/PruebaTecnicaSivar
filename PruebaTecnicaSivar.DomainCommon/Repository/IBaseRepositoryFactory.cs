using PruebaTecnicaSivar.DomainCommon.Entity;

namespace PruebaTecnicaSivar.DomainCommon.Repository
{
    public interface IBaseRepositoryFactory
    {
        IBaseAsyncRepository<T, ID> Create<T, ID, TInfra>() where T : BaseEntity<ID> where TInfra : BaseDBEntity<ID>;
    }
}
