using AutoMapper;
using MediatR;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Command;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;
using PruebaTecnicaSivar.Domain.Entity;
using PruebaTecnicaSivar.Domain.Repository;

namespace PruebaTecnicaSivar.ApplicationDomain.Handler
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, RoleDetailResponse>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public CreateRoleHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<RoleDetailResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var roleEntity = _mapper.Map<Role>(request);
            var newRole = await _roleRepository.AddAsync(roleEntity);
            return _mapper.Map<RoleDetailResponse>(newRole);
        }
    }
}
