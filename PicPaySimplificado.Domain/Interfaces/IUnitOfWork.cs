namespace PicPaySimplificado.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public Task<ITransaction> BeginTransactionAsync();
    }
}
