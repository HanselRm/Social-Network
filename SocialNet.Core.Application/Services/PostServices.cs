
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
        public PostServices(IPostRepository postRepository, IMapper mapper) : base(postRepository, mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
    }
}
