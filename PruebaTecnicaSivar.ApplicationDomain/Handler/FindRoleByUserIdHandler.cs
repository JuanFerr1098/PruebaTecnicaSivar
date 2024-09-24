using AutoMapper;
using MediatR;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Query;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;
using PruebaTecnicaSivar.Domain.Repository;

namespace PruebaTecnicaSivar.ApplicationDomain.Handler
{
    public class FindRoleByUserIdHandler : IRequestHandler<FindRoleByUserIdQuery, RoleDetailResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public FindRoleByUserIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<RoleDetailResponse> Handle(FindRoleByUserIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id != null)
            {
                var response = (await _userRepository.GetRoleByUserId(request.Id));
                var resp = new RoleDetailResponse(response.Role.Id)
                {
                    RoleName = response.Role.RoleName
                };
                return resp;
            }
            return null;
        }
    }
}
