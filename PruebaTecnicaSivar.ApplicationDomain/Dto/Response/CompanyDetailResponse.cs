namespace PruebaTecnicaSivar.ApplicationDomain.Dto.Response
{
    public class CompanyDetailResponse : CommonDetailResponse<Guid>
    {
        public CompanyDetailResponse(Guid id) : base(id)
        {
        }

        public string CompanyName { get; set; }
    }
}
