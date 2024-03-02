
using SocialNet.Core.Application.ViewModels.Posts;
using SocialNet.Core.Domain.Entities;

namespace SocialNet.Core.Application.Interfaces.Services
{
    public interface IPostServices : IGenericServices<SavePostViewModel, PostViewModel, Post>
    {
        
    }
}
