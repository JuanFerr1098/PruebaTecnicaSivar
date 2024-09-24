using PruebaTecnicaSivar.DomainCommon.Entity;

namespace PruebaTecnicaSivar.Domain.Entity
{
    public class User : BaseEntity<Guid>
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public Role? Role { get; set; }
        public ICollection<Company> Companies { get; set; }

        public User()
        {
            Companies = new HashSet<Company>();
        }
    }
}
