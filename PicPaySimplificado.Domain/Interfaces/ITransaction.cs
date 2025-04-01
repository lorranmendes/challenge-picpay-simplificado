namespace PicPaySimplificado.Domain.Interfaces
{
    public interface ITransaction : IDisposable
    {
        public Task CommitAsync();
        public Task RollbackAsync();
    }
}
