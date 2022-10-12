using HumanResources.Domain.Entities;
using HumanResources.Domain.Interfaces.Repositories;

namespace HumanResurces.Infra.Data.Repositories
{
    public class ContratoRepository : IContratoRepository
    {
        private readonly IRepositoryBase<Contrato> _repositoryBase;

        public ContratoRepository(IRepositoryBase<Contrato> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<Contrato> GetContratoById(int id)
        {
            return await _repositoryBase.GetByIdAsyn(id);    
        }

        public async Task<Contrato> GetContratoByTipoContrato(string tipoContrato)
        {
            var contratos = await _repositoryBase.Get(x => x.TipoContrato == tipoContrato);

            return contratos?.FirstOrDefault();
        }

        public async Task<List<Contrato>> GetContratos()
        {
            var contratos = await _repositoryBase.Get();

            return contratos?.ToList();
        }
    }
}
