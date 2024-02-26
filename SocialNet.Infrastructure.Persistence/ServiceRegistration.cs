using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNet.Infrastructure.Persistence.Context;

namespace SocialNet.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection service, IConfiguration configuracion)
        {
            service.AddDbContext<DbContex>(option =>
                option.UseSqlServer(configuracion.GetConnectionString("Default"),
                m => m.MigrationsAssembly(typeof(DbContex).Assembly.FullName)));

            return service;
        }
    }
}
