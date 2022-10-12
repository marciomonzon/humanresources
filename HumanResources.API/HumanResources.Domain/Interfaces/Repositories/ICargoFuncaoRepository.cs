using HumanResources.Domain.Entities;

namespace HumanResources.Domain.Interfaces.Repositories
{
    public interface ICargoFuncaoRepository
    {
        Task Add(CargoFuncao cargoFuncao);
        Task Update(CargoFuncao cargoFuncao);
        Task Delete(CargoFuncao cargoFuncao);
        Task<IEnumerable<CargoFuncao>> GetCargoFuncao();
        Task<CargoFuncao> GetCargoFuncaoById(int id);
    }
}
