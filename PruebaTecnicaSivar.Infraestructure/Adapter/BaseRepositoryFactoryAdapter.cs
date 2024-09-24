using AutoMapper;
using PruebaTecnicaSivar.DomainCommon.Entity;
using PruebaTecnicaSivar.DomainCommon.Repository;
using PruebaTecnicaSivar.Infrastructure.Context;

namespace PruebaTecnicaSivar.Infrastructure.Adapter
{
    public class BaseRepositoryFactoryAdapter : IBaseRepositoryFactory
    {
        private readonly InfrastructureEFContext _context;
        private readonly IMapper _mapper;

        public BaseRepositoryFactoryAdapter(InfrastructureEFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IBaseAsyncRepository<T, ID> Create<T, ID, TInfra>() where T : BaseEntity<ID> where TInfra : BaseDBEntity<ID>
        {
            return new BaseRepositoryAdapter<T, ID, TInfra>(_context, _mapper);
        }
    }
}
