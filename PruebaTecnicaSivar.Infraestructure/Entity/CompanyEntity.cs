namespace PruebaTecnicaSivar.Infrastructure.Entity
{
    public class CompanyEntity : BaseDBEntity<Guid>
    {
        public string? CompanyName { get; set; }
        public Guid? UserId { get; set; }
        public virtual UserEntity? User { get; set; }
    }
}
