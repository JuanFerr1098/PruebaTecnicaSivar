using PruebaTecnicaSivar.DomainCommon.Entity;

namespace PruebaTecnicaSivar.Infrastructure.Entity
{
    public class UserEntity : BaseDBEntity<Guid>
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public Guid? RoleId { get; set; }
        public virtual RoleEntity? Role { get; set; }
        public virtual ICollection<CompanyEntity> Companies { get; set; }

        public UserEntity()
        {
            Companies = new List<CompanyEntity>();
        }
    }
}
