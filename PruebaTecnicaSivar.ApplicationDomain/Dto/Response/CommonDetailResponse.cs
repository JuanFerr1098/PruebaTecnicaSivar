namespace PruebaTecnicaSivar.ApplicationDomain.Dto.Response
{
    public class CommonDetailResponse<ID>
    {
        public ID Id { get; set; }

        public CommonDetailResponse(ID id)
        {
            Id = id;
        }

        public override bool Equals(object? obj) => obj is CommonDetailResponse<ID> entity &&
                EqualityComparer<ID>.Default.Equals(Id, entity.Id);

        public override int GetHashCode() => HashCode.Combine(Id);

        //public DateTime DateCreated { get; set; }
        //public string UserCreated { get; set; }
        //public DateTime DateUpdated { get; set; }
        //public string UserUpdated { get; set; }
    }
}
