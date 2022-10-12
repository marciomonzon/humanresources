using HumanResources.Domain.Entities.Base;
using System.Linq.Expressions;

namespace HumanResources.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetByIdAsyn(int id);
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);   
    }
}
