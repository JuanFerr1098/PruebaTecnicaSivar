using PruebaTecnicaSivar.DomainCommon.Entity;

namespace PruebaTecnicaSivar.Domain.Entity
{
    public class Role : BaseEntity<Guid>
    {
        public string RoleName { get; set; }

        public Role(Guid id, string roleName) : base(id)
        {
            RoleName = roleName;
        }
    }
}
