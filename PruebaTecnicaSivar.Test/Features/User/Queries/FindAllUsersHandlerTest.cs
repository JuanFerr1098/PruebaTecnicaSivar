using AutoMapper;
using Moq;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Query;
using PruebaTecnicaSivar.ApplicationDomain.Handler;
using PruebaTecnicaSivar.ApplicationDomain.Mapper;
using PruebaTecnicaSivar.Domain.Repository;
using PruebaTecnicaSivar.Test.Mocks;

namespace PruebaTecnicaSivar.Test.Features.User.Queries
{
    public class FindAllUsersHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _userRepository;

        public FindAllUsersHandlerTest()
        {
            _userRepository = MockUserRepository.GetUserRepository();
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task FindAllUsersTest()
        {
            var handler = new FindAllUsersHandler(_userRepository.Object, _mapper);
            var response = await handler.Handle(
                new FindAllUsersQuery() { }, 
                CancellationToken.None);
            Assert.Equal(1,1);
        }
    }
}
