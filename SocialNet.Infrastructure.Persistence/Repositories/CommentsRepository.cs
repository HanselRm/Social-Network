using SocialNet.Core.Application.Interfaces.Repositories;
using SocialNet.Core.Domain.Entities;
using SocialNet.Infrastructure.Persistence.Context;

namespace SocialNet.Infrastructure.Persistence.Repositories
{
    public class CommentsRepository : GenericRepository<Comments>, ICommentsRepository
    {
        private readonly DbContex dbContext;

        public CommentsRepository(DbContex dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

    }

}

