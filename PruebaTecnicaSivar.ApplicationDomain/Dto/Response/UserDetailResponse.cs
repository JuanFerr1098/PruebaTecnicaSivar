namespace PruebaTecnicaSivar.ApplicationDomain.Dto.Response
{
    public class UserDetailResponse : CommonDetailResponse<Guid>
    {
        public UserDetailResponse(Guid id) : base(id)
        {
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public RoleDetailResponse Role { get; set; }
        public ICollection<CompanyDetailResponse> Companies { get; set; }
    }
}
