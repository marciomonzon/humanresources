namespace HumanResources.Domain.Interfaces.Repositories
{
    public interface IUnityOfWork
    {
        Task<bool> Commit();
        void Rollback();
    }
}
