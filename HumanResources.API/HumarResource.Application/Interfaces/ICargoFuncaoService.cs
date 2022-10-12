using HumarResource.Application.DTO;

namespace HumarResource.Application.Interfaces
{
    public interface ICargoFuncaoService
    {
        Task Add(CargoFuncaoDTO cargoFuncao);
        Task Update(int id, CargoFuncaoDTO cargoFuncao);
        Task Delete(int id);
        Task<List<CargoFuncaoDTO>> GetCargoFuncao();
        Task<CargoFuncaoDTO> GetCargoFuncaoById(int id);
    }
}
