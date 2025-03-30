namespace PicPaySimplificado.Infrastructure.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly PicPaySimplificadoContext context;
        private readonly IUserRepository userRepository;
        public EFUnitOfWork(PicPaySimplificadoContext context)
        {
            this.context = context;
        }

        public IUserRepository UserRepository => userRepository ?? new UserRepository(context);
        public async Task<ITransaction> BeginTransactionAsync() => new EFTransaction(await context.Database.BeginTransactionAsync());
    }
}
