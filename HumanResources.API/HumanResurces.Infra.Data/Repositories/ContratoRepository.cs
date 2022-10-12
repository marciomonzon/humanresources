using HumanResources.Domain.Entities;
using HumanResources.Domain.Interfaces.Repositories;
using HumanResurces.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HumanResurces.Infra.Data.Repositories
{
    public class ContratoRepository : IContratoRepository
    {
        public readonly DbSet<Contrato> _dbSet;
        public readonly ApplicationDbContext _appDbContext;

        public ContratoRepository(ApplicationDbContext appDbContext)
        {
            _dbSet = _appDbContext.Set<Contrato>();
            _appDbContext = appDbContext;
        }

        public async Task<Contrato> GetContratoById(int id)
        {
            var query = _dbSet.AsQueryable();
            query = query.Where(x => x.Id == id).AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Contrato> GetContratoByTipoContrato(string tipoContrato)
        {
            var query = _dbSet.AsQueryable();
            query = query.Where(x => x.TipoContrato.Equals(tipoContrato, StringComparison.CurrentCultureIgnoreCase)).AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Contrato>> GetContratos()
        {
            var query = _dbSet.AsQueryable();
            return await query.ToListAsync();
        }
    }
}
