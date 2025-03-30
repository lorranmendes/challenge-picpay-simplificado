namespace PicPaySimplificado.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PicPaySimplificadoContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                
                options.UseSqlServer(
                    connectionString, 
                    opt => opt.MigrationsAssembly(typeof(PicPaySimplificadoContext).Assembly.FullName));    
            });
        }
    }
}
