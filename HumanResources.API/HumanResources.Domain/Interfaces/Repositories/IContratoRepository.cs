using HumanResources.Domain.Entities;

namespace HumanResources.Domain.Interfaces.Repositories
{
    public interface IContratoRepository
    {
        Task<List<Contrato>> GetContratos();
        Task<Contrato> GetContratoById(int id);
        Task<Contrato> GetContratoByTipoContrato(string tipoContrato);
    }
}
