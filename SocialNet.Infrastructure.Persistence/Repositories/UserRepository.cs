using Microsoft.EntityFrameworkCore;
using SocialNet.Core.Application.Helpers;
using SocialNet.Core.Application.Interfaces.Repositories;
using SocialNet.Core.Application.ViewModels.Users;
using SocialNet.Core.Domain.Entities;
using SocialNet.Infrastructure.Persistence.Context;

namespace SocialNet.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DbContex dbContext;

        public UserRepository(DbContex dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public override async Task UdapteAsync(User entity)
        {
            entity.Password = PasswordEncryption.ComputeSha256Hash(entity.Password);
            await base.UdapteAsync(entity);
        }

        public override async Task<User> AddAsync(User entity)
        {
            entity.Password = PasswordEncryption.ComputeSha256Hash(entity.Password);
            return await base.AddAsync(entity);
        }

        public async Task<User> LoginAsync(LoginViewModel loginVm)
        {
            string passwordEncrypy = PasswordEncryption.ComputeSha256Hash(loginVm.Password);
            User user = await dbContext.Set<User>()
                .FirstOrDefaultAsync(user => user.Password == passwordEncrypy && user.UserName == loginVm.UserName);
            return user;
        }
    }

}

