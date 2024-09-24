using AutoMapper;
using PruebaTecnicaSivar.Domain.Entity;
using PruebaTecnicaSivar.Infrastructure.Entity;

namespace PruebaTecnicaSivar.Infrastructure.Mapping
{
    public class InfrastructureMappingProfile : Profile
    {
        public InfrastructureMappingProfile() {
            CreateMap<User, UserEntity>()
                .ReverseMap()
                .ForMember(dest => dest.Id, y => y.MapFrom(s => s.Id))
                ;
            CreateMap<Role, RoleEntity>().ReverseMap();
            CreateMap<Company, CompanyEntity>().ReverseMap();
        }
    }
}
