using MediatR;
using AutoMapper;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Query;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;
using PruebaTecnicaSivar.Domain.Repository;

namespace PruebaTecnicaSivar.ApplicationDomain.Handler
{
    public class FindAllUsersHandler : IRequestHandler<FindAllUsersQuery, List<UserDetailResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public FindAllUsersHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDetailResponse>> Handle(FindAllUsersQuery request, CancellationToken cancellationToken)
        {
            var response = await _userRepository.GetAllUsers();
            return _mapper.Map<List<UserDetailResponse>>(response);
        }
    }
}
