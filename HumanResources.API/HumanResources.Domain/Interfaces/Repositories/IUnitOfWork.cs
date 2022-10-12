namespace HumanResources.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        void Rollback();
    }
}
