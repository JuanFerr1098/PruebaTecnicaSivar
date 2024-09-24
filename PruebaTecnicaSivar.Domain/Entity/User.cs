using PruebaTecnicaSivar.DomainCommon.Entity;

namespace PruebaTecnicaSivar.Domain.Entity
{
    public class User : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public ICollection<Company> Companies { get; set; }

        public User(Guid id, string name, string lastName, Role role, ICollection<Company> companies) : base(id) 
        {
            Name = name;
            LastName = lastName;
            Role = role;
            Companies = companies;
        }
    }
}
