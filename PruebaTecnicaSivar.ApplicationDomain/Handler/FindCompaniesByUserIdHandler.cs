using AutoMapper;
using MediatR;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Query;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;
using PruebaTecnicaSivar.Domain.Repository;

namespace PruebaTecnicaSivar.ApplicationDomain.Handler
{
    public class FindCompaniesByUserIdHandler : IRequestHandler<FindCompaniesByUserIdQuery, List<CompanyDetailResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public FindCompaniesByUserIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<CompanyDetailResponse>> Handle(FindCompaniesByUserIdQuery request, CancellationToken cancellationToken)
        {
            if(request.Id != null)
            {
                var response = await _userRepository.GetCompaniesByUserId(request.Id);
                return _mapper.Map<List<CompanyDetailResponse>>(response);
            }
            return null;
        }
    }
}
