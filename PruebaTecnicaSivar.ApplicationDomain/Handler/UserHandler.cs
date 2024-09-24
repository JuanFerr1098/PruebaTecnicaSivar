using AutoMapper;
using MediatR;
using PruebaTecnicaSivar.ApplicationDomain.Dto;
using PruebaTecnicaSivar.Domain.Repository;

namespace PruebaTecnicaSivar.ApplicationDomain.Handler
{
    public class UserHandler : IRequestHandler<UserDetailQuery, UserDetailResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDetailResponse> Handle(UserDetailQuery request, CancellationToken cancellationToken)
        {
            if (request.Id != null) {
                var response = await _userRepository.GetByIdAsync(request.Id);
                return _mapper.Map<UserDetailResponse>(response);
            }
            return null;
        }
    }
}
