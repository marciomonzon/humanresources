using HumarResource.Application.DTO;

namespace HumarResource.Application.Interfaces
{
    public interface IContratoService
    {
        Task<List<ContratoDTO>> GetContratos();
        Task<ContratoDTO> GetContratoById(int id);
        Task<ContratoDTO> GetContratoByTipoContrato(string tipoContrato);
    }
}
