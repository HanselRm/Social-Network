
using SocialNet.Core.Application.DTOS.Email;

namespace SocialNet.Core.Application.Interfaces.Services
{
    public interface IEmailServices
    {
        Task sendAsync(EmailRequest request);
    }
}
