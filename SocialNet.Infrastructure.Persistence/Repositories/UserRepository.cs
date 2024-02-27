using SocialNet.Core.Application.Interfaces.Repositories;
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

    }

}

