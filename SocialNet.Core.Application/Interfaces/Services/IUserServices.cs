﻿
using SocialNet.Core.Application.ViewModels.Users;
using SocialNet.Core.Domain.Entities;

namespace SocialNet.Core.Application.Interfaces.Services
{
    public interface IUserServices : IGenericServices<SaveUserViewModel, UserViewModel, User>, IUserServicesUp<EditUserViewModel>


    {
        
    }
}
