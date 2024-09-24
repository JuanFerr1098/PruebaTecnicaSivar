using AutoMapper;
using MediatR;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Command;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;
using PruebaTecnicaSivar.Domain.Repository;

namespace PruebaTecnicaSivar.ApplicationDomain.Handler
{
    public class AssignUserToCompanyHandler : IRequestHandler<AssignUserToCompanyCommand, CompanyDetailResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public AssignUserToCompanyHandler(IUserRepository userRepository, ICompanyRepository companyRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<CompanyDetailResponse> Handle(AssignUserToCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyResponse = await _companyRepository.GetByIdAsync(request.IdCompany);
            if (companyResponse != null)
            {
                var userResponse = await _userRepository.GetByIdAsync(request.IdUser);
                if (userResponse == null) return null;
                companyResponse.UserId = userResponse.Id;
                var result = await _companyRepository.UpdateAsync(companyResponse);
                return _mapper.Map<CompanyDetailResponse>(result);
            }
            return null;
        }
    }
}
