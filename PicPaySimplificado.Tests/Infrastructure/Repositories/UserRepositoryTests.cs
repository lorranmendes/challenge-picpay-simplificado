namespace PicPaySimplificado.Tests.Infrastructure.Repositories
{
    public class UserRepositoryTests
    {
        private readonly Faker faker;
        private readonly Fixture fixture;
        private readonly Mock<IUserRepository> mockUserRepository;
        public UserRepositoryTests()
        {
            this.faker = new Faker();
            this.fixture = new Fixture();
            this.mockUserRepository = new Mock<IUserRepository>();
        }

        [Fact]
        public async void AddAsync_WithValidData_ShouldReturnUser()
        {
            var user = this.GetUser();
            var userRepository = this.mockUserRepository.Object;
            mockUserRepository.Setup(x => x.AddAsync(It.IsAny<User>())).ReturnsAsync(user);

            var result = await userRepository.AddAsync(user);

            Assert.NotNull(result);
        }

        [Fact]
        public async void GetByIdAsync_WithValidId_ShouldReturnUser()
        {
            var user = this.GetUser();
            user.Id = new Random().Next(99);
            var userRepository = this.mockUserRepository.Object;
            mockUserRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(user);

            var result = await userRepository.GetByIdAsync(user.Id);

            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
        }

        private User GetUser()
        {
            var userType = fixture.Create<UserTypeEnum>();
            var email = faker.Internet.Email();
            return new User
            {
                Name = faker.Person.FullName,
                Email = new Email(email),
                Password = faker.Internet.Password(),
                Type = userType,
                Document = userType == UserTypeEnum.Common
                    ? faker.Person.Cpf()
                    : faker.Company.Cnpj()
            };
        }
    }
}
