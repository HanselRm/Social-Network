

using SocialNet.Core.Application.Interfaces.Repositories;
using SocialNet.Core.Domain.Entities;
using SocialNet.Infrastructure.Persistence.Context;

namespace SocialNet.Infrastructure.Persistence.Repositories
{
    public class FriendsRepository : GenericRepository<Friends>, IFriendsRepossitory
    {
        private readonly DbContex dbContext;

        public FriendsRepository(DbContex dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
