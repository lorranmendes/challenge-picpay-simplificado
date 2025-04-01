namespace PicPaySimplificado.Infrastructure.Repositories
{
    public class TransferRepository : Repository<Transfer>, ITransferRepository
    {
        private readonly PicPaySimplificadoContext context;
        public TransferRepository(PicPaySimplificadoContext context) : base(context)
        {
            this.context = context;
        }
    }
}
