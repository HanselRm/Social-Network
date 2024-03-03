using AutoMapper;
using SocialNet.Core.Application.Interfaces.Repositories;
using SocialNet.Core.Application.Interfaces.Services;
using SocialNet.Core.Application.ViewModels.Comments;
using SocialNet.Core.Domain.Entities;

namespace SocialNet.Core.Application.Services
{
    public class CommentsServices : GenericServices<SaveCommentViewModel, CommentsViewModel, Comments>, ICommentsServices
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IMapper _mapper;
        public CommentsServices(ICommentsRepository commentsRepository, IMapper mapper) : base(commentsRepository, mapper)
        {
            _commentsRepository = commentsRepository;
            _mapper = mapper;
        }
        public async Task<List<CommentsViewModel>> GetAllViewModelWithInclude()
        {
            var Post = await _commentsRepository.GetAllWithIncludeAsync(new List<string> { "User" });

            return Post.Select(model => new CommentsViewModel
            {
                Id = model.Id,
                Content = model.Comment,
                PhotoUrl = model.User.Imagen,
                PublicationsId = model.IdPost,
                UserId = model.IdUser,
                UserName = model.User.UserName
    
            }).ToList();
        }
    }

    
}
