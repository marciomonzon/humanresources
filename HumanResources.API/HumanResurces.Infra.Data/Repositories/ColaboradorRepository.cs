using HumanResources.Domain.Entities;
using HumanResources.Domain.Interfaces.Repositories;

namespace HumanResurces.Infra.Data.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly IRepositoryBase<Colaborador> _repositoryBase;

        public ColaboradorRepository(IRepositoryBase<Colaborador> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task Add(Colaborador colaborador)
        {
            await _repositoryBase.AddAsync(colaborador);
        }

        public async Task Update(Colaborador colaborador)
        {
            await _repositoryBase.UpdateAsync(colaborador);
        }

        public async Task Delete(Colaborador colaborador)
        {
            await _repositoryBase.DeleteAsync(colaborador);
        }

        public async Task<IEnumerable<Colaborador>> GetColaborador()
        {
            return await _repositoryBase.Get();
        }

        public async Task<Colaborador> GetColaboradorById(int id)
        {
            return await _repositoryBase.GetByIdAsyn(id);
        }

        public async Task<Colaborador> GetContratoByNome(string nome)
        {
            return await _repositoryBase.GetByFilter(x => x.Nome.Equals(nome, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
