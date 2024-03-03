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
            var comments = await _commentsRepository.GetAllWithIncludeAsync(new List<string> { "User", "ParentComment" });

            var childCommentsDict = comments
                .Where(c => c.ParentComment != null)
                .GroupBy(c => c.ParentCommentId) 
                .ToDictionary(g => g.Key, g => g.Select(c => new CommentsViewModel
                {
                    Id = c.Id,
                    Content = c.Comment,
                    PhotoUrl = c.User.Imagen,
                    PublicationsId = c.IdPost,
                    UserId = c.IdUser,
                    UserName = c.User.UserName
                }).ToList());

            
            var mainComments = comments
                .Where(c => c.ParentComment == null) 
                .Select(c => new CommentsViewModel
                {
                    Id = c.Id,
                    Content = c.Comment,
                    PhotoUrl = c.User.Imagen,
                    PublicationsId = c.IdPost,
                    UserId = c.IdUser,
                    UserName = c.User.UserName,
                    CommentsChild = childCommentsDict.ContainsKey(c.Id) ? childCommentsDict[c.Id] : new List<CommentsViewModel>()
                })
                .ToList();

            return mainComments;

        }
    }

    
}
