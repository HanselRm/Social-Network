
using AutoMapper;
using SocialNet.Core.Application.Interfaces.Repositories;
using SocialNet.Core.Application.Interfaces.Services;
using SocialNet.Core.Application.ViewModels.Users;
using SocialNet.Core.Domain.Entities;

namespace SocialNet.Core.Application.Services
{
    public class UserServices : GenericServices<SaveUserViewModel,UserViewModel,User>, IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserServices(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper) 
        { 
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<SaveUserViewModel> Login(LoginViewModel vm)
        {
            User user = await _userRepository.LoginAsync(vm);

            if (user == null)
            {
                return null;
            }
            SaveUserViewModel Uservm = _mapper.Map<SaveUserViewModel>(user);
            

            return Uservm;
        }
        public override async Task<SaveUserViewModel> Add(SaveUserViewModel vm)
        {
            SaveUserViewModel Uservm = await base.Add(vm);
            return Uservm;
        }

    }
}
