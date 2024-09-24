using PruebaTecnicaSivar.DomainCommon.Entity;

namespace PruebaTecnicaSivar.Infrastructure.Entity
{
    public class RoleEntity : BaseDBEntity<Guid>
    {
        public string? RoleName { get; set; }
        public virtual ICollection<UserEntity> Users { get; set; }

        public RoleEntity()
        {
            Users = new List<UserEntity>();
        }
    }
}
