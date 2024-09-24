namespace PruebaTecnicaSivar.ApplicationDomain.Dto.Response
{
    public class RoleDetailResponse : CommonDetailResponse<Guid>
    {
        public RoleDetailResponse(Guid id) : base(id)
        {
        }

        public string RoleName { get; set; }
    }
}
