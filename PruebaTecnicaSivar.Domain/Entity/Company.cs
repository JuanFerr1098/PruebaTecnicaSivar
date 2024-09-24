using PruebaTecnicaSivar.DomainCommon.Entity;

namespace PruebaTecnicaSivar.Domain.Entity
{
    public class Company : BaseEntity<Guid>
    {
        public string? CompanyName { get; set; }
        public Guid? UserId { get; set; }
    }
}
