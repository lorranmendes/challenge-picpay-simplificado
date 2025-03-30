namespace PicPaySimplificado.Infrastructure.Context
{
    public class PicPaySimplificadoContext : DbContext
    {
        public PicPaySimplificadoContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; private set; }
        public DbSet<Transfer> Transfers { get; private set; }
        public DbSet<Wallet> Wallets { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
