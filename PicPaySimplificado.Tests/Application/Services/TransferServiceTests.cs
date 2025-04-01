namespace PicPaySimplificado.Tests.Application.Services
{
    public class TransferServiceTests : IClassFixture<UserFixture>
    {
        private readonly Fixture fixture;
        private readonly UserFixture userFixture;
        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        private readonly Mock<INotifier> mockNotifier;
        private readonly Mock<IAuthorizer> mockAuthorizer;
        private readonly ITransferService transferService;

        public TransferServiceTests(UserFixture userFixture)
        {
            fixture = new Fixture();
            mockUnitOfWork = new Mock<IUnitOfWork>();
            mockAuthorizer = new Mock<IAuthorizer>();
            mockNotifier = new Mock<INotifier>();
            transferService = new TransferService(mockUnitOfWork.Object, mockNotifier.Object, mockAuthorizer.Object);
            this.userFixture = userFixture;
        }

        [Fact]
        public async void AddAsync_WithValidData_ShouldCreateTransferWithSuccess()
        {
            decimal amount = 100.00m;
            var payer = userFixture.GetUser();
            payer.Type = UserTypeEnum.Common;
            var payee = userFixture.GetUser();
            payee.Type = UserTypeEnum.Merchant;
            var transfer = new Transfer(payer.Id, payee.Id, amount);
            var notifiedDTO = new NotifiedDTO { Notified = true };
            var transaction = new Mock<ITransaction>();
            mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).ReturnsAsync(transaction.Object);
            mockUnitOfWork.Setup(x => x.UserRepository.GetByIdAsync(payer.Id)).ReturnsAsync(payer);
            mockUnitOfWork.Setup(x => x.TransferRepository.AddAsync(It.IsAny<Transfer>())).ReturnsAsync(transfer);
            mockAuthorizer.Setup(x => x.IsAuthorized()).Returns(true);
            mockNotifier.Setup(x => x.Notify()).Returns(notifiedDTO);

            var result = await transferService.AddAsync(transfer);

            Assert.IsType<Guid>(result.Data);
            Assert.True(result.Success);
        }

        [Fact]
        public async void AddAsync_WithMerchantAsPayer_ShouldThrowException()
        {
            decimal amount = 100.00m;
            var payer = userFixture.GetUser();
            payer.Type = UserTypeEnum.Merchant;
            var payee = userFixture.GetUser();
            payee.Type = UserTypeEnum.Common;
            var transfer = new Transfer(payer.Id, payee.Id, amount);
            var notifiedDTO = new NotifiedDTO { Notified = true };
            mockUnitOfWork.Setup(x => x.UserRepository.GetByIdAsync(payer.Id)).ReturnsAsync(payer);
            mockUnitOfWork.Setup(x => x.TransferRepository.AddAsync(It.IsAny<Transfer>())).ReturnsAsync(transfer);
            mockAuthorizer.Setup(x => x.IsAuthorized()).Returns(true);
            mockNotifier.Setup(x => x.Notify()).Returns(notifiedDTO);

            await Assert.ThrowsAsync<MerchantUserCannotTransferException>(() => transferService.AddAsync(transfer));
        }

        [Fact]
        public async void AddAsync_AmountExceedsThePayersBalance_ShouldThrowException()
        {
            var payer = userFixture.GetUser();
            payer.Type = UserTypeEnum.Common;
            var payee = userFixture.GetUser();
            payee.Type = UserTypeEnum.Merchant;
            decimal amount = payer.Wallet.Balance + fixture.Create<decimal>();
            var transfer = new Transfer(payer.Id, payee.Id, amount);
            var notifiedDTO = new NotifiedDTO { Notified = true };
            mockUnitOfWork.Setup(x => x.UserRepository.GetByIdAsync(payer.Id)).ReturnsAsync(payer);
            mockUnitOfWork.Setup(x => x.TransferRepository.AddAsync(It.IsAny<Transfer>())).ReturnsAsync(transfer);
            mockAuthorizer.Setup(x => x.IsAuthorized()).Returns(true);
            mockNotifier.Setup(x => x.Notify()).Returns(notifiedDTO);

            await Assert.ThrowsAsync<InsufficientBalanceException>(() => transferService.AddAsync(transfer));
        }

        [Fact]
        public async void AddAsync_AmountIsZero_ShouldThrowException()
        {
            decimal amount = 0;
            var payer = userFixture.GetUser();
            payer.Type = UserTypeEnum.Common;
            var payee = userFixture.GetUser();
            payee.Type = UserTypeEnum.Merchant;            
            var transfer = new Transfer(payer.Id, payee.Id, amount);
            var notifiedDTO = new NotifiedDTO { Notified = true };
            mockUnitOfWork.Setup(x => x.UserRepository.GetByIdAsync(payer.Id)).ReturnsAsync(payer);
            mockUnitOfWork.Setup(x => x.TransferRepository.AddAsync(It.IsAny<Transfer>())).ReturnsAsync(transfer);
            mockAuthorizer.Setup(x => x.IsAuthorized()).Returns(true);
            mockNotifier.Setup(x => x.Notify()).Returns(notifiedDTO);

            await Assert.ThrowsAsync<AmountMustBeGreaterThanZeroException>(() => transferService.AddAsync(transfer));
        }

        [Fact]
        public async void AddAsync_NotAuthorized_ShouldThrowException()
        {
            decimal amount = 100.00m;
            var payer = userFixture.GetUser();
            payer.Type = UserTypeEnum.Common;
            var payee = userFixture.GetUser();
            payee.Type = UserTypeEnum.Merchant;
            var transfer = new Transfer(payer.Id, payee.Id, amount);
            var notifiedDTO = new NotifiedDTO { Notified = true };
            var transaction = new Mock<ITransaction>();
            mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).ReturnsAsync(transaction.Object);
            mockUnitOfWork.Setup(x => x.UserRepository.GetByIdAsync(payer.Id)).ReturnsAsync(payer);            
            mockUnitOfWork.Setup(x => x.TransferRepository.AddAsync(It.IsAny<Transfer>())).ReturnsAsync(transfer);
            mockAuthorizer.Setup(x => x.IsAuthorized()).Returns(false);
            mockNotifier.Setup(x => x.Notify()).Returns(notifiedDTO);

            await Assert.ThrowsAsync<NotAuthorizedException>(() => transferService.AddAsync(transfer));
        }

        [Fact]
        public async void AddAsync_NotifyServiceIsOffline_ShouldThrowException()
        {
            decimal amount = 100.00m;
            var payer = userFixture.GetUser();
            payer.Type = UserTypeEnum.Common;
            var payee = userFixture.GetUser();
            payee.Type = UserTypeEnum.Merchant;
            var transfer = new Transfer(payer.Id, payee.Id, amount);
            var notifiedDTO = new NotifiedDTO { Notified = false };
            var transaction = new Mock<ITransaction>();
            mockUnitOfWork.Setup(x => x.BeginTransactionAsync()).ReturnsAsync(transaction.Object);
            mockUnitOfWork.Setup(x => x.UserRepository.GetByIdAsync(payer.Id)).ReturnsAsync(payer);            
            mockUnitOfWork.Setup(x => x.TransferRepository.AddAsync(It.IsAny<Transfer>())).ReturnsAsync(transfer);
            mockAuthorizer.Setup(x => x.IsAuthorized()).Returns(true);
            mockNotifier.Setup(x => x.Notify()).Returns(notifiedDTO);

            await Assert.ThrowsAsync<NotifyServiceOfflineException>(() => transferService.AddAsync(transfer));
        }
    }
}
