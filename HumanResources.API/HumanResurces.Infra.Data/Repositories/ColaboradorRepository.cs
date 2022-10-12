using HumanResources.Domain.Entities;
using HumanResources.Domain.Interfaces.Repositories;
using HumanResurces.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HumanResurces.Infra.Data.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        public readonly DbSet<Colaborador> _dbSet;
        public readonly ApplicationDbContext _appDbContext;

        public ColaboradorRepository(ApplicationDbContext appDbContext)
        {
            _dbSet = _appDbContext.Set<Colaborador>();
            _appDbContext = appDbContext;
        }

        public async Task Add(Colaborador colaborador)
        {
            await _appDbContext.AddAsync(colaborador);
        }

        public void Update(Colaborador colaborador)
        {
            _appDbContext.Update(colaborador);
        }

        public void Delete(Colaborador colaborador)
        {
            _appDbContext.Remove(colaborador);
        }

        public async Task<IEnumerable<Colaborador>> GetColaborador()
        {
            var query = _dbSet.AsQueryable();
            return await query.ToListAsync();
        }

        public async Task<Colaborador> GetColaboradorById(int id)
        {
            var query = _dbSet.AsQueryable();
            query = query.Where(x => x.Id == id).AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Colaborador> GetContratoByNome(string nome)
        {
            var query = _dbSet.AsQueryable();
            query = query.Where(x => x.Nome.Equals(nome, StringComparison.CurrentCultureIgnoreCase)).AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }
    }
}
