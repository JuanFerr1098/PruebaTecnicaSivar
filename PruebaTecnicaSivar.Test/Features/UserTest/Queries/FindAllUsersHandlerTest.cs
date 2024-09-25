using AutoMapper;
using Moq;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Query;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;
using PruebaTecnicaSivar.ApplicationDomain.Handler;
using PruebaTecnicaSivar.ApplicationDomain.Mapper;
using PruebaTecnicaSivar.Domain.Repository;
using PruebaTecnicaSivar.Test.Mocks;
using Shouldly;

namespace PruebaTecnicaSivar.Test.Features.UserTest.Queries
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
            var req = new FindAllUsersQuery();
            var res = await handler.Handle(req, CancellationToken.None);
            res.ShouldBeOfType<List<UserDetailResponse>>();
            res.Count.ShouldBe(3);
        }
    }
}
