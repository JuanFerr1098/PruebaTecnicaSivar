using AutoMapper;
using MediatR;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Command;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;
using PruebaTecnicaSivar.Domain.Entity;
using PruebaTecnicaSivar.Domain.Repository;

namespace PruebaTecnicaSivar.ApplicationDomain.Handler
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CompanyDetailResponse>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CreateCompanyHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<CompanyDetailResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyEntity = _mapper.Map<Company>(request);
            var newCompany = await _companyRepository.AddAsync(companyEntity);
            return _mapper.Map<CompanyDetailResponse>(newCompany);
        }
    }
}
