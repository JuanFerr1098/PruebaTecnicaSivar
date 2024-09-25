using AutoMapper;
using Moq;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Command;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Response;
using PruebaTecnicaSivar.ApplicationDomain.Handler;
using PruebaTecnicaSivar.ApplicationDomain.Mapper;
using PruebaTecnicaSivar.Domain.Entity;
using PruebaTecnicaSivar.Domain.Repository;
using PruebaTecnicaSivar.Test.Mocks;
using Shouldly;

namespace PruebaTecnicaSivar.Test.Features.UserTest.Commands
{
    public class CreateUserHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _userRepository;

        public CreateUserHandlerTest()
        {
            _userRepository = MockUserRepository.GetUserRepository();
            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task CreateUserCommandTest()
        {
            var mockUserRepository = new Mock<IUserRepository>();
            //var user = new User() { Name = "Name", LastName = "lastName" };
            //var userWihtId = new User() { Id = Guid.Parse("AF0F74E1-E2A3-4A83-4A24-08DCDC91D603"), Name = "Name", LastName = "lastName" };
            var userCommand = new CreateUserCommand() { Name = "Name", LastName = "lastName" };

            var handler = new CreateUserHandler(mockUserRepository.Object, _mapper);
            var result = await handler.Handle(userCommand, CancellationToken.None);

            //Assert.NotNull(result);
            mockUserRepository.Verify(repo => repo.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
