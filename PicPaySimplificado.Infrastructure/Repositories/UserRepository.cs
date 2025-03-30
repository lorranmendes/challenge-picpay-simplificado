namespace PicPaySimplificado.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly PicPaySimplificadoContext context;
        public UserRepository(PicPaySimplificadoContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<User?> GetByIdAsync(int id)
        {
            return await context.Users
                .Include(u => u.Wallet)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
