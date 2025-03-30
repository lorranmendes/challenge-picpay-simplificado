namespace PicPaySimplificado.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task<TEntity> AddAsync(TEntity entity);
        public Task<TEntity?> GetByIdAsync(int id);
        public Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate);
        public void Update(TEntity entity);
    }
}
