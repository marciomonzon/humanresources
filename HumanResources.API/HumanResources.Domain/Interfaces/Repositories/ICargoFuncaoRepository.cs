using HumanResources.Domain.Entities;

namespace HumanResources.Domain.Interfaces.Repositories
{
    public interface ICargoFuncaoRepository
    {
        Task Add(CargoFuncao cargoFuncao);
        void Update(CargoFuncao cargoFuncao);
        void Delete(CargoFuncao cargoFuncao);
        Task<IEnumerable<CargoFuncao>> GetCargoFuncao();
        Task<CargoFuncao> GetCargoFuncaoById(int id);
    }
}
