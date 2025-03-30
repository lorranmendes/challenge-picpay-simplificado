namespace PicPaySimplificado.Tests.Domain
{
    public class WalletTests 
    {
        public const decimal InitialBalance = 100.00m;
        public WalletTests()
        {
            
        }

        [Fact]
        public void Deposit_PositiveAmount_ShouldIncreaseBalance()
        {
            var wallet = GetDefaultWallet();
            decimal depositAmount = 50.50m;
            decimal expectedBalance = InitialBalance + depositAmount;

            wallet.Deposit(depositAmount);

            Assert.Equal(expectedBalance, wallet.Balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-0.01)]
        [InlineData(-100)]
        public void Deposit_InvalidAmount_ShouldThrowException(decimal invalidAmount)
        {
            var wallet = GetDefaultWallet();

            var exception = Assert.Throws<AmountMustBeGreaterThanZeroException>(
                () => wallet.Deposit(invalidAmount));

            Assert.Equal(DefaultMessages.AmountMustBeGreaterThanZero, exception.Message);
            Assert.Equal(InitialBalance, wallet.Balance);
        }

        [Fact]
        public void Withdraw_ValidAmount_ShouldDecreaseBalance()
        {
            var wallet = GetDefaultWallet();
            decimal withdrawAmount = 50.00m;
            decimal expectedBalance = InitialBalance - withdrawAmount;

            wallet.Withdraw(withdrawAmount);

            Assert.Equal(expectedBalance, wallet.Balance);
        }

        [Fact]
        public void Withdraw_EntireBalance_ShouldSetBalanceToZero()
        {
            var wallet = GetDefaultWallet();
            decimal withdrawAmount = InitialBalance;

            wallet.Withdraw(withdrawAmount);

            Assert.Equal(0, wallet.Balance);
        }

        [Theory]
        [InlineData(100.01)]
        [InlineData(200)]
        public void Withdraw_AmountExceedingBalance_ShouldThrowException(decimal excessiveAmount)
        {
            var wallet = GetDefaultWallet();

            var exception = Assert.Throws<InsufficientBalanceException>(
                () => wallet.Withdraw(excessiveAmount));

            Assert.Equal(DefaultMessages.InsufficientBalance, exception.Message);
            Assert.Equal(InitialBalance, wallet.Balance);
        }

        [Fact]
        public void MultipleOperations_ShouldMaintainCorrectBalance()
        {
            var wallet = GetDefaultWallet();
            decimal deposit1 = 50.00m;
            decimal deposit2 = 25.50m;
            decimal withdraw1 = 30.00m;
            decimal withdraw2 = 45.50m;
            decimal expectedBalance = InitialBalance + deposit1 + deposit2 - withdraw1 - withdraw2;

            wallet.Deposit(deposit1);
            wallet.Deposit(deposit2);
            wallet.Withdraw(withdraw1);
            wallet.Withdraw(withdraw2);

            Assert.Equal(expectedBalance, wallet.Balance);
        }

        private Wallet GetDefaultWallet() => new Wallet(
            idUser: new Random().Next(10),
            initialBalance: InitialBalance)
        {
            Id = 1
        };
    }    
}
