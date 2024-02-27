using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNet.Core.Application.Interfaces.Services;
using SocialNet.Core.Application.Services;

namespace SocialNet.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddAplicationLayer(this IServiceCollection service, IConfiguration configuracion)
        {
            #region Service Dependency
            service.AddTransient<IUserServices, UserServices>();

            #endregion
        }
    }
}
