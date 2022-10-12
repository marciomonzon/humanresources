using HumanResources.Domain.Interfaces.Repositories;
using HumanResurces.Infra.Data.Context;

namespace HumanResurces.Infra.Data.Repositories
{
    public class UnityOfWork : IUnityOfWork, IDisposable
    {
        public readonly ApplicationDbContext _appDbContext;

        public UnityOfWork(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Commit()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        public void Rollback()
        {
            //
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
