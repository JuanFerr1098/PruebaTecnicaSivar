using AutoMapper;
using Moq;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Query;
using PruebaTecnicaSivar.ApplicationDomain.Handler;
using PruebaTecnicaSivar.ApplicationDomain.Mapper;
using PruebaTecnicaSivar.Domain.Repository;
using PruebaTecnicaSivar.Test.Mocks;

namespace PruebaTecnicaSivar.Test.Features.UserTest.Queries
{
    public class FindUserByIdHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _userRepository;

        public FindUserByIdHandlerTest()
        {
            _userRepository = MockUserRepository.GetUserRepositoryById();
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task FindUserByIdTest()
        {
            var handler = new FindUserByIdHandler(_userRepository.Object, _mapper);
            var req = new FindUserByIdQuery(Guid.Parse("86E86D53-4D2F-4A20-4A25-08DCDC91D603"));
            var response = await handler.Handle(req,CancellationToken.None);
            Assert.Equal(Guid.Parse("86E86D53-4D2F-4A20-4A25-08DCDC91D603"), response.Id);
        }
    }
}
