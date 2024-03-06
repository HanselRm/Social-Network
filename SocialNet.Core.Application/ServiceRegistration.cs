using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNet.Core.Application.Interfaces.Services;
using SocialNet.Core.Application.Services;
using System.Reflection;

namespace SocialNet.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddAplicationLayer(this IServiceCollection service, IConfiguration configuracion)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            #region Service Dependency
            service.AddTransient<IUserServices, UserServices>();
            service.AddTransient<IPostServices, PostServices>();
            service.AddTransient<ICommentsServices, CommentsServices>();
            service.AddTransient<IFriendsServices, FriendsServices>();


            #endregion
        }
    }
}
