using HumarResource.Application.DTO;

namespace HumarResource.Application.Interfaces
{
    public interface IColaboradorService
    {
        Task Add(ColaboradorDTO colaborador);
        Task Update(int id, ColaboradorDTO colaborador);
        Task Delete(int id);
        Task<IEnumerable<ColaboradorDTO>> GetColaborador();
        Task<ColaboradorDTO> GetColaboradorById(int id);
        Task<ColaboradorDTO> GetContratoByNome(string nome);
    }
}
