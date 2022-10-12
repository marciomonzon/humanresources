using HumanResources.Domain.Entities;
using HumanResources.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResurces.Infra.Data.Repositories
{
    public class CargoFuncaoRepository : ICargoFuncaoRepository
    {
        private readonly IRepositoryBase<CargoFuncao> _repositoryBase;

        public CargoFuncaoRepository(IRepositoryBase<CargoFuncao> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task Add(CargoFuncao cargoFuncao)
        {
            await _repositoryBase.AddAsync(cargoFuncao);
        }

        public async Task<IEnumerable<CargoFuncao>> GetCargoFuncao()
        {
            return await _repositoryBase.Get();
        }

        public async Task<CargoFuncao> GetCargoFuncaoById(int id)
        {
            return await _repositoryBase.GetByIdAsyn(id);
        }

        public async Task Update(CargoFuncao cargoFuncao)
        {
            await _repositoryBase.UpdateAsync(cargoFuncao);
        }

        public async Task Delete(CargoFuncao cargoFuncao)
        {
            await _repositoryBase.DeleteAsync(cargoFuncao);
        }
    }
}
