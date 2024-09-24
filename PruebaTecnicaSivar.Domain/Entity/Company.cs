using PruebaTecnicaSivar.DomainCommon.Entity;

namespace PruebaTecnicaSivar.Domain.Entity
{
    public class Company : BaseEntity<Guid>
    {
        public string CompanyName { get; set; }

        public Company(Guid id, string companyName) : base(id)
        {
            CompanyName = companyName;
        }
    }
}
