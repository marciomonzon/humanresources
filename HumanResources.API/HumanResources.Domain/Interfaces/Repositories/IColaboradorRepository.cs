using HumanResources.Domain.Entities;

namespace HumanResources.Domain.Interfaces.Repositories
{
    public interface IColaboradorRepository
    {
        Task Add(Colaborador colaborador);
        void Update(Colaborador colaborador);
        void Delete(Colaborador colaborador);
        Task<IEnumerable<Colaborador>> GetColaborador();
        Task<Colaborador> GetColaboradorById(int id);
        Task<Colaborador> GetContratoByNome(string nome);
    }
}
