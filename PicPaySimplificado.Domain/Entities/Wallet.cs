namespace PicPaySimplificado.Domain.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public decimal Balance { get; private set; }
        public User User { get; set; }

        public Wallet() { }
        public Wallet(int idUser, decimal initialBalance = 0)
        {
            IdUser = idUser;
            Balance = initialBalance > 0 ? initialBalance : Balance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new AmountMustBeGreaterThanZeroException(string.Format(DefaultMessages.ValueMustBeGreaterThanZero, "Valor"));

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
                throw new InsufficientBalanceException(DefaultMessages.InsufficientBalance);

            Balance -= amount;
        }
    }
}