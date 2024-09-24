using AutoMapper;
using PruebaTecnicaSivar.Domain.Entity;
using PruebaTecnicaSivar.Domain.Repository;
using PruebaTecnicaSivar.Infrastructure.Context;
using PruebaTecnicaSivar.Infrastructure.Entity;

namespace PruebaTecnicaSivar.Infrastructure.Adapter
{
    public class UserRepositoryAdapter : BaseRepositoryAdapter<User, Guid, UserEntity>, IUserRepository
    {
        public UserRepositoryAdapter(InfrastructureEFContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
