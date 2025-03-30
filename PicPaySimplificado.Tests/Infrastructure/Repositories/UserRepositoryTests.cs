namespace PicPaySimplificado.Tests.Infrastructure.Repositories
{
    public class UserRepositoryTests : IClassFixture<UserFixture>
    {
        private readonly UserFixture userFixture;
        private readonly Mock<IUserRepository> mockUserRepository;
        public UserRepositoryTests(UserFixture userFixture)
        {
            this.userFixture = userFixture;
            this.mockUserRepository = new Mock<IUserRepository>();
        }

        [Fact]
        public async void AddAsync_WithValidData_ShouldReturnUser()
        {
            var user = userFixture.GetUser();
            var userRepository = this.mockUserRepository.Object;
            mockUserRepository.Setup(x => x.AddAsync(It.IsAny<User>())).ReturnsAsync(user);

            var result = await userRepository.AddAsync(user);

            Assert.NotNull(result);
        }

        [Fact]
        public async void GetByIdAsync_WithValidId_ShouldReturnUser()
        {
            var user = userFixture.GetUser();
            user.Id = new Random().Next(99);
            var userRepository = this.mockUserRepository.Object;
            mockUserRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(user);

            var result = await userRepository.GetByIdAsync(user.Id);

            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
        }
    }
}
