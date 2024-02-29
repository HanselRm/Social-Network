using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNet.Core.Application.Interfaces.Services;
using SocialNet.Core.Domain.Settings;
using SocialNet.Infrastructure.Shared.Services;

namespace SocialNet.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection service, IConfiguration configuracion)
        {
            service.Configure<MailSettings>(configuracion.GetSection("MailSettings"));
            service.AddTransient<IEmailServices, EmailServices>();
            
        }
    }
}
