using AutoMapper;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Command;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;
using PruebaTecnicaSivar.Domain.Entity;

namespace PruebaTecnicaSivar.ApplicationDomain.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<User, UserDetailResponse>();
            CreateMap<Role, RoleDetailResponse>();
            CreateMap<Company, CompanyDetailResponse>();
            CreateMap<CreateUserCommand, User>();
            CreateMap<CreateRoleCommand, Role>();
            CreateMap<CreateCompanyCommand, Company>();
        }
    }
}
