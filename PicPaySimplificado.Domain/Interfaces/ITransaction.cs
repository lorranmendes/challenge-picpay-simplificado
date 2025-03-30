namespace PicPaySimplificado.Domain.Interfaces
{
    public interface ITransaction
    {
        public Task CommitAsync();
        public Task RollbackAsync();
    }
}
