
using SocialNet.Core.Application.Interfaces.Repositories;
using SocialNet.Core.Application.Interfaces.Services;
using SocialNet.Core.Application.ViewModels.Users;
using SocialNet.Core.Domain.Entities;

namespace SocialNet.Core.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository) 
        { 
            _userRepository = userRepository;
        }
        public async Task<SaveUserViewModel> Login(LoginViewModel vm)
        {
            User user = await _userRepository.LoginAsync(vm);

            if (user == null)
            {
                return null;
            }
            SaveUserViewModel Uservm = new();
            Uservm.Id = user.Id;
            Uservm.Name = user.Name;
            Uservm.LastName = user.LastName;
            Uservm.Email = user.Email;
            Uservm.UserName = user.UserName;
            Uservm.Password = user.Password;
            Uservm.Status = user.Status;
            Uservm.Imagen = user.Imagen;
            Uservm.Phone = user.Phone;
            

            return Uservm;
        }
        public async Task<SaveUserViewModel> Add(SaveUserViewModel vm)
        {
            User user = new User
            {
                Id = vm.Id,
                Name = vm.Name,
                LastName = vm.LastName,
                Phone = vm.Phone,
                Email = vm.Email,
                Imagen = vm.Imagen,
                UserName = vm.UserName,
                Password = vm.Password,
            };
            user = await _userRepository.AddAsync(user);

            SaveUserViewModel model = new SaveUserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Phone = user.Phone,
                Email = user.Email,
                Imagen = user.Imagen,
                UserName = user.UserName,
                Password = user.Password
            };
            return model;
        }

        public Task<List<SaveUserViewModel>> GetAllViewModels()
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }


        public Task<SaveUserViewModel> GetByIdSaveViewModel(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(SaveUserViewModel vm)
        {
            throw new NotImplementedException();
        }
    }
}
