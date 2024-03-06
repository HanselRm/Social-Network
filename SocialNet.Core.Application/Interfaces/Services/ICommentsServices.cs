
using SocialNet.Core.Application.ViewModels.Comments;
using SocialNet.Core.Domain.Entities;

namespace SocialNet.Core.Application.Interfaces.Services
{
    public interface ICommentsServices : IGenericServices<SaveCommentViewModel, CommentsViewModel, Comments>
    {
        Task<List<CommentsViewModel>> GetAllViewModelWithInclude();
    }
}
