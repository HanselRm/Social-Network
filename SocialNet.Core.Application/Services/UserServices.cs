
using AutoMapper;
using SocialNet.Core.Application.DTOS.Email;
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
        private readonly IEmailServices _emailServices;
        public UserServices(IUserRepository userRepository, IMapper mapper, IEmailServices emailServices) : base(userRepository, mapper) 
        { 
            _userRepository = userRepository;
            _mapper = mapper;
            _emailServices = emailServices;
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
            _emailServices.sendAsync(new EmailRequest
            {
                To = vm.Email,
                Subject = "Bienvenido a la red social",
                Body = $"<a href=\"https://localhost:7071/User/ChangeUserStatus/{Uservm.Id}\">Activar Usuario</a>"
            });
            return Uservm;
        }

    }
}
