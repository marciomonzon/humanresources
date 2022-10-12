using HumanResources.Domain.Entities.Base;
using HumanResources.Domain.Interfaces.Repositories;
using HumanResurces.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HumanResurces.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        public readonly DbSet<TEntity> _dbSet;
        public readonly ApplicationDbContext _appDbContext;

        public RepositoryBase(ApplicationDbContext appDbContext)
        {
            _dbSet = _appDbContext.Set<TEntity>();
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = _dbSet.AsQueryable();

            if (filter != null)
                query = query.Where(filter).AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            var query = _dbSet.AsQueryable();

            
            query = query.Where(filter).AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdAsyn(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
