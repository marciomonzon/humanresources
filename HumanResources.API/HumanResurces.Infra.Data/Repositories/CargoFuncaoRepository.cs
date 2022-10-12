using HumanResources.Domain.Entities;
using HumanResources.Domain.Interfaces.Repositories;
using HumanResurces.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HumanResurces.Infra.Data.Repositories
{
    public class CargoFuncaoRepository : ICargoFuncaoRepository
    {
        public readonly DbSet<CargoFuncao> _dbSet;
        public readonly ApplicationDbContext _appDbContext;

        public CargoFuncaoRepository(ApplicationDbContext appDbContext)
        {
            _dbSet = _appDbContext.Set<CargoFuncao>();
            _appDbContext = appDbContext;
        }

        public async Task Add(CargoFuncao cargoFuncao)
        {
            await _appDbContext.AddAsync(cargoFuncao);
        }

        public async Task<IEnumerable<CargoFuncao>> GetCargoFuncao()
        {
            var query = _dbSet.AsQueryable();
            return await query.ToListAsync();
        }

        public async Task<CargoFuncao> GetCargoFuncaoById(int id)
        {
            var query = _dbSet.AsQueryable();
            query = query.Where(x => x.Id == id).AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public void Update(CargoFuncao cargoFuncao)
        {
            _appDbContext.Update(cargoFuncao);
        }

        public void Delete(CargoFuncao cargoFuncao)
        {
            _appDbContext.Remove(cargoFuncao);
        }
    }
}
