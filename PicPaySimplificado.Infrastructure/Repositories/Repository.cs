namespace PicPaySimplificado.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly PicPaySimplificadoContext context;
        public Repository(PicPaySimplificadoContext context)
        {
            this.context = context;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate) =>
            await context.Set<TEntity>().FirstOrDefaultAsync(predicate);

        public virtual async Task<TEntity?> GetByIdAsync(int id) => 
            await context.Set<TEntity>().FindAsync(id);

        public void Update(TEntity entity) => 
            context.Set<TEntity>().Update(entity);
    }
}
