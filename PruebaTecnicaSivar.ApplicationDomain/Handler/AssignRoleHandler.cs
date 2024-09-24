using AutoMapper;
using MediatR;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Command;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;
using PruebaTecnicaSivar.Domain.Repository;

namespace PruebaTecnicaSivar.ApplicationDomain.Handler
{
    public class AssignRoleHandler : IRequestHandler<AssignRoleCommand, UserDetailResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public AssignRoleHandler(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<UserDetailResponse> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
        {
            var userResponse = await _userRepository.GetByIdAsync(request.IdUser);
            if (userResponse != null)
            {
                var roleResponse = await _roleRepository.GetByIdAsync(request.IdRole);
                if (roleResponse != null)
                {
                    if (roleResponse.Id == userResponse?.Role?.Id) { return null; }
                    userResponse.Role = roleResponse;
                    var result = await _userRepository.UpdateAsync(userResponse);
                    return _mapper.Map<UserDetailResponse>(result);
                }
            }
            return null;
        }
    }
}
