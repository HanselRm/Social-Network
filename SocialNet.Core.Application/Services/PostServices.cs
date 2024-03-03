
using AutoMapper;
using SocialNet.Core.Application.Interfaces.Repositories;
using SocialNet.Core.Application.Interfaces.Services;
using SocialNet.Core.Application.ViewModels.Posts;
using SocialNet.Core.Domain.Entities;

namespace SocialNet.Core.Application.Services
{
    public class PostServices : GenericServices<SavePostViewModel, PostViewModel, Post>, IPostServices
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly ICommentsServices _commentsService;
        public PostServices(IPostRepository postRepository, IMapper mapper, ICommentsServices commentsService) : base(postRepository, mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _commentsService = commentsService;
        }

        public async Task<List<PostViewModel>> GetAllViewModelWithInclude()
        {
            var Post = await _postRepository.GetAllWithIncludeAsync(new List<string> { "Comments" });
            var commentList = await _commentsService.GetAllViewModelWithInclude();

            return Post.Select(model => new PostViewModel
            {
                Id = model.Id,
                Caption = model.Caption,
                ImgPost = model.ImgPost,
                Date = model.Date,
                Hour = model.Hour,
                IdUser = model.IdUser,
                CommentList = commentList.Where(a => a.PublicationsId == model.Id).ToList(),
            }).ToList();

        }
    }
    
}
