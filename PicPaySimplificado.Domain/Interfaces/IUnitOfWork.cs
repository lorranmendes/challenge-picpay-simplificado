namespace PicPaySimplificado.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public Task<ITransaction> BeginTransactionAsync();
    }
}
