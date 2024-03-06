using SocialNet.Core.Application.Interfaces.Repositories;
using SocialNet.Core.Domain.Entities;
using SocialNet.Infrastructure.Persistence.Context;

namespace SocialNet.Infrastructure.Persistence.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly DbContex dbContext;

        public PostRepository(DbContex dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

    }

}

