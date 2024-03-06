using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNet.Core.Application.Interfaces.Repositories;
using SocialNet.Infrastructure.Persistence.Context;
using SocialNet.Infrastructure.Persistence.Repositories;

namespace SocialNet.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        
        public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection service, IConfiguration configuracion)
        {
            #region Context
            service.AddDbContext<DbContex>(option =>
                option.UseSqlServer(configuracion.GetConnectionString("Default"),
                m => m.MigrationsAssembly(typeof(DbContex).Assembly.FullName)));
            #endregion

            #region Repositories
            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<IPostRepository, PostRepository>();
            service.AddTransient<ICommentsRepository, CommentsRepository>();
            service.AddTransient<IFriendsRepossitory, FriendsRepository>();
            #endregion

            return service;
        }
    }
}
