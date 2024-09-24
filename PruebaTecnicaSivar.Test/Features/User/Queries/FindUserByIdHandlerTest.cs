using AutoMapper;
using Moq;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Query;
using PruebaTecnicaSivar.ApplicationDomain.Handler;
using PruebaTecnicaSivar.ApplicationDomain.Mapper;
using PruebaTecnicaSivar.Domain.Repository;
using PruebaTecnicaSivar.Test.Mocks;

namespace PruebaTecnicaSivar.Test.Features.User.Queries
{
    public class FindUserByIdHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _userRepository;

        public FindUserByIdHandlerTest()
        {
            _userRepository = MockUserRepository.GetUserRepository();
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
            var response = await handler.Handle(new FindUserByIdQuery(
                Guid.Parse("E5628C6C-351B-4D2D-3BE9-08DCDC572924"))
            {
                
            },CancellationToken.None);
            Assert.Equal(1,1);
        }
    }
}
