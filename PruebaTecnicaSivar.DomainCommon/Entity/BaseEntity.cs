namespace PruebaTecnicaSivar.DomainCommon.Entity
{
    public class BaseEntity<ID>
    {
        public ID Id { get; set; }

        public BaseEntity(ID id)
        {
            Id = id;
        }

        public override bool Equals(object? obj) => obj is BaseEntity<ID> entity &&
                EqualityComparer<ID>.Default.Equals(Id, entity.Id);

        public override int GetHashCode() => HashCode.Combine(Id);
    }
}
