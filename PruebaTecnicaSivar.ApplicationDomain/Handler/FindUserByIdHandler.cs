using MediatR;
using AutoMapper;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Query;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;
using PruebaTecnicaSivar.Domain.Repository;

namespace PruebaTecnicaSivar.ApplicationDomain.Handler
{
    public class FindUserByIdHandler : IRequestHandler<FindUserByIdQuery, UserDetailResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public FindUserByIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDetailResponse> Handle(FindUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id != null) {
                var response = await _userRepository.GetByIdAsync(request.Id);
                return _mapper.Map<UserDetailResponse>(response);
            }
            return null;
        }
    }
}
