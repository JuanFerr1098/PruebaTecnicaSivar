namespace PruebaTecnicaSivar.Infrastructure.Entity
{
    public class RoleEntity : BaseDBEntity<Guid>
    {
        public string? RoleName { get; set; }
        public virtual UserEntity? User { get; set; }
    }
}
