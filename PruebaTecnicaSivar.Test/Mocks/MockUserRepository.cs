using AutoFixture;
using Moq;
using PruebaTecnicaSivar.ApplicationDomain.Dto.Command;
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
            var user = new User() { Name = "Name", LastName = "lastName"};
            var userWihtId = new User() {Id= Guid.Parse("AF0F74E1-E2A3-4A83-4A24-08DCDC91D603"), Name = "Name", LastName = "lastName"};
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(u => u.GetAllAsync()).ReturnsAsync(users);
            mockRepository.Setup(u => u.AddAsync(user)).Callback<User>(u => u.Id = userWihtId.Id).ReturnsAsync(userWihtId);
            return mockRepository;
        }

        public static Mock<IUserRepository> GetUserRepositoryById()
        {
            var fixture = new Fixture();
            var user = fixture.Create<User>();
            user.Id = Guid.Parse("86E86D53-4D2F-4A20-4A25-08DCDC91D603");
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(u => u.GetByIdAsync(Guid.Parse("86E86D53-4D2F-4A20-4A25-08DCDC91D603"))).ReturnsAsync(user);
            return mockRepository;
        }

        public static void AddDataUserRepository()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var users = fixture.CreateMany<User>().ToList();
            users.Add(fixture.Build<User>()
                .With(us => us.Id, Guid.Parse("86E86D53-4D2F-4A20-4A25-08DCDC91D603"))
                .With(us => us.Name, "TestName")
                .With(us => us.LastName, "TestLast")
                .Without(us => us.Role)
                .Without(us => us.Companies)
                .Create());
        }
    }
}
