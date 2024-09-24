using AutoMapper;
using PruebaTecnicaSivar.ApplicationDomain.Dto;
using PruebaTecnicaSivar.Domain.Entity;

namespace PruebaTecnicaSivar.ApplicationDomain.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<User, UserDetailResponse>();
            CreateMap<Role, RoleDetailResponse>();
            CreateMap<Company, CompanyDetailResponse>();
        }
    }
}
