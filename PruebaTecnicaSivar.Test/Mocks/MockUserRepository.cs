using AutoFixture;
using Moq;
using PruebaTecnicaSivar.Domain.Entity;
using PruebaTecnicaSivar.Domain.Repository;

namespace PruebaTecnicaSivar.Test.Mocks
{
    public static class MockUserRepository
    {
        public static Mock<IUserRepository> GetUserRepository()
        {
            var fixture = new Fixture();
            var users = fixture.CreateMany<User>().ToList();
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(u => u.GetAllAsync()).ReturnsAsync(users);
            return mockRepository;
        }
    }
}
