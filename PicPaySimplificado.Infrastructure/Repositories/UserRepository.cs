namespace PicPaySimplificado.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly PicPaySimplificadoContext context;
        public UserRepository(PicPaySimplificadoContext context) : base(context)
        {
            this.context = context;
        }
    }
}
