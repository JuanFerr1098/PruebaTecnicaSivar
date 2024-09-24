namespace PruebaTecnicaSivar.DomainCommon.Entity
{
    public class BaseDBEntity<ID>
    {
        public required ID Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? UserCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string? UserUpdated { get; set; }
    }
}
