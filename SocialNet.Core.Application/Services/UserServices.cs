
using AutoMapper;
using SocialNet.Core.Application.DTOS.Email;
using SocialNet.Core.Application.Helpers;
using SocialNet.Core.Application.Interfaces;
using SocialNet.Core.Application.Interfaces.Repositories;
using SocialNet.Core.Application.Interfaces.Services;
using SocialNet.Core.Application.ViewModels.Users;
using SocialNet.Core.Domain.Entities;

namespace SocialNet.Core.Application.Services
{
    public class UserServices : GenericServices<SaveUserViewModel,UserViewModel,User>, IUserServices, IUserServicesUp<EditUserViewModel>
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
            await _emailServices.sendAsync(new EmailRequest
            {
                To = vm.Email,
                Subject = "Bienvenido a la red social",
                Body = $"<a href=\"https://localhost:7071/User/ChangeUserStatus/{Uservm.Id}\">Activar Usuario</a>"
            });
            return Uservm;
        }

        public async Task<Boolean> GetByUserNameViewModel(string userName)
        {
            var userList = await _userRepository.GetAllAsync();
            User user1 = userList.FirstOrDefault(u => u.UserName == userName);

            if(user1 != null)
            {
                var password = PasswordGenerate.GenerarPassword();
                user1.Password = password;
                await _userRepository.UdapteAsync(user1, user1.Id);
                await _emailServices.sendAsync(new EmailRequest
                {
                    To = user1.Email,
                    Subject = "Cambiar contraseña",
                    Body = $"Hi {user1.UserName} <br> Su nueva contraseña es: {password}"
                });
                return true;
            }

            return false;
        }

        public async Task<EditUserViewModel> GetByIdEditViewModel(int id)
        {
            User user = await _userRepository.GetByIdAsync(id);
            EditUserViewModel vm = _mapper.Map<EditUserViewModel>(user);
            return vm;
        }



        public async Task Update(EditUserViewModel vm, int id)
        {
            var user1 = await _userRepository.GetByIdAsync(id);
            User user = _mapper.Map<User>(vm);

            if (vm.Password != null)
            {
                if (vm.File != null)
                {
                    user.Id = id;
                    user.Password = vm.Password;
                    user.UserName = user1.UserName;
                    await _userRepository.UdapteAsync(user, id);
                }
                else
                {
                   
                    user.Imagen = user1.Imagen;
                    user.Password = vm.Password;
                    user.UserName = user1.UserName;
                    await _userRepository.UdapteAsync(user, id);
                }
                
            }
            else
            {
                if(vm.File != null)
                {
                    user.Id = id;
                    user.Password = user1.Password;
                    user.UserName = user1.UserName;
                    await _userRepository.UdapteAsyncWithoutPassword(user, id);
                }
                else
                {
                    user.Id = id;
                    user.Password = user1.Password;
                    user.Imagen = user1.Imagen;
                    user.UserName = user1.UserName;
                    await _userRepository.UdapteAsyncWithoutPassword(user, id);
                }
                
            }

            
        }

    }
}
