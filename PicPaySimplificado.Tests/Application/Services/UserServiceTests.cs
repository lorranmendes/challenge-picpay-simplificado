namespace PicPaySimplificado.Tests.Application.Services
{    
    public class UserServiceTests : IClassFixture<UserFixture>
    {
        private readonly UserFixture userFixture;
        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        private readonly IUserService userService;
        public UserServiceTests(UserFixture userFixture) 
        {
            this.userFixture = userFixture;
            this.mockUnitOfWork = new Mock<IUnitOfWork>();
            this.userService = new UserService(this.mockUnitOfWork.Object);
        }

        [Fact]
        public async void AddAsync_WithValidData_ShouldCreateUserWithSuccess()
        {
            var user = userFixture.GetUser();
            mockUnitOfWork.Setup(x => x.UserRepository.AddAsync(It.IsAny<User>())).ReturnsAsync(user);

            var result = await userService.AddAsync(user);

            Assert.IsType<int>(result.Data);
            Assert.True(result.Success);
        }

        [Fact]
        public async void AddAsync_WithAlreadyUsedDocument_ShouldThrowException()
        {
            var userExists = userFixture.GetUser();
            var newUser = userFixture.GetUser();
            newUser.Document = userExists.Document;
            mockUnitOfWork.Setup(x => x.UserRepository.FindAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(userExists);

            await Assert.ThrowsAsync<AlreadyUsedException>(() => userService.AddAsync(newUser));
        }

        [Fact]
        public async void AddAsync_WithAlreadyUsedEmail_ShouldThrowException()
        {
            var userExists = userFixture.GetUser();
            var newUser = userFixture.GetUser();
            newUser.Email = userExists.Email;
            mockUnitOfWork.Setup(x => x.UserRepository.FindAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(userExists);

            await Assert.ThrowsAsync<AlreadyUsedException>(() => userService.AddAsync(newUser));
        }
    }
}
