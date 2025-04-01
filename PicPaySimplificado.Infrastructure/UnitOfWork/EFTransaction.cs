namespace PicPaySimplificado.Infrastructure.UnitOfWork
{
    public class EFTransaction : ITransaction
    {
        private readonly IDbContextTransaction transaction;
        public EFTransaction(IDbContextTransaction transaction)
        {
            this.transaction = transaction;
        }
        public async Task CommitAsync() => await transaction.CommitAsync();
        public async Task RollbackAsync() => await transaction.RollbackAsync();
        public async void Dispose() => await transaction.DisposeAsync();
    }
}
