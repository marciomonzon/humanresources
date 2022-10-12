using HumanResources.Domain.Interfaces.Repositories;
using HumanResurces.Infra.Data.Context;

namespace HumanResurces.Infra.Data.Repositories
{
    public class UnityOfWork : IUnitOfWork, IDisposable
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
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (_appDbContext == null)
            {
                return;
            }

            _appDbContext.Dispose();
        }
    }
}
