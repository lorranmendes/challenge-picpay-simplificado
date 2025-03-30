namespace PicPaySimplificado.Infrastructure.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly PicPaySimplificadoContext context;
        public EFUnitOfWork(PicPaySimplificadoContext context)
        {
            this.context = context;
        }
        public async Task<ITransaction> BeginTransactionAsync() => new EFTransaction(await context.Database.BeginTransactionAsync());
    }
}
