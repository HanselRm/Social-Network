using Microsoft.EntityFrameworkCore;
using SocialNet.Infrastructure.Persistence.Context;
using SocialNet.Core.Application.Interfaces.Repositories;

namespace SocialNet.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity>
        where Entity : class
    {
        private readonly DbContex dbContext;

        public GenericRepository(DbContex dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual async Task<Entity> AddAsync(Entity entity)
        {
            await dbContext.Set<Entity>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
        public virtual async Task UdapteAsync(Entity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Entity entity)
        {
            dbContext.Set<Entity>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }
        public async Task<List<Entity>> GetAllAsync()
        {
            return await dbContext.Set<Entity>().ToListAsync();
        }

        public async Task<List<Entity>> GetAllWithIncludeAsync(List<string> properties)
        {
            var query = dbContext.Set<Entity>().AsQueryable();
            foreach (var property in properties)
            {
                query = query.Include(property);
            }
            return await query.ToListAsync();
        }
        public async Task<Entity> GetByIdAsync(int id)
        {
            return await dbContext.Set<Entity>().FindAsync(id);
        }
    }
}
