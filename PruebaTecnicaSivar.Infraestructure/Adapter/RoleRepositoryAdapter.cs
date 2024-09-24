using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSivar.Domain.Entity;
using PruebaTecnicaSivar.Domain.Repository;
using PruebaTecnicaSivar.Infrastructure.Context;
using PruebaTecnicaSivar.Infrastructure.Entity;

namespace PruebaTecnicaSivar.Infrastructure.Adapter
{
    public class RoleRepositoryAdapter : BaseRepositoryAdapter<Role, Guid, RoleEntity>, IRoleRepository
    {
        public RoleRepositoryAdapter(InfrastructureEFContext context, IMapper mapper) : base(context, mapper)
        {
        }

    }
}
