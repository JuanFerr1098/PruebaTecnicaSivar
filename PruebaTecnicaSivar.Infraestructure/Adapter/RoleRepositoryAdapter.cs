using PruebaTecnicaSivar.Domain.Entity;
using PruebaTecnicaSivar.Domain.Repository;
using PruebaTecnicaSivar.Infrastructure.Context;

namespace PruebaTecnicaSivar.Infrastructure.Adapter
{
    public class RoleRepositoryAdapter : BaseRepositoryAdapter<Role, Guid>, IRoleRepository
    {
        public RoleRepositoryAdapter(InfrastructureEFContext context) : base(context)
        {
        }
    }
}
