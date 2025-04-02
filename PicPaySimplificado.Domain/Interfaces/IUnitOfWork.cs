namespace PicPaySimplificado.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public ITransferRepository TransferRepository { get; }
        public Task<ITransaction> BeginTransactionAsync();
        public Task SaveChangesAsync();
    }
}
