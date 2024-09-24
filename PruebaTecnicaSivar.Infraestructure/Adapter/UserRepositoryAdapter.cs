using PruebaTecnicaSivar.Domain.Entity;
using PruebaTecnicaSivar.Domain.Repository;
using PruebaTecnicaSivar.Infrastructure.Context;

namespace PruebaTecnicaSivar.Infrastructure.Adapter
{
    public class UserRepositoryAdapter : BaseRepositoryAdapter<User, Guid>, IUserRepository
    {
        public UserRepositoryAdapter(InfrastructureEFContext context) : base(context)
        {
        }
    }
}
