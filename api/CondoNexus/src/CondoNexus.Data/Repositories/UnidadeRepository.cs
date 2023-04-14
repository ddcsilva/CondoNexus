using CondoNexus.Business.Interfaces;
using CondoNexus.Business.Models;
using CondoNexus.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CondoNexus.Data.Repositories;

public class UnidadeRepository : Repository<Unidade>, IUnidadeRepository
{
    public UnidadeRepository(CondoNexusContext context) : base(context)
    {
    }

    public async Task<List<Unidade>> ObterUnidadesPorCondominio(Guid condominioId)
    {
        return await _dbSet.AsNoTracking()
            .Where(u => u.CondominioId == condominioId)
            .ToListAsync();
    }

    public async Task<List<Unidade>> ObterUnidadesPorAndar(int andar)
    {
        return await _dbSet.AsNoTracking()
            .Where(u => u.Andar == andar)
            .ToListAsync();
    }

    public async Task<List<Unidade>> ObterUnidadesComMoradores()
    {
        return await _dbSet.AsNoTracking()
            .Include(u => u.Moradores)
            .ToListAsync();
    }

    public async Task<List<Unidade>> ObterUnidadesComVeiculos()
    {
        return await _dbSet.AsNoTracking()
            .Include(u => u.Veiculos)
            .ToListAsync();
    }

    public async Task<List<Unidade>> ObterUnidadesComMoradoresEVeiculos(Guid condominioId)
    {
        return await _dbSet.AsNoTracking()
            .Include(u => u.Moradores)
            .Include(u => u.Veiculos)
            .Where(u => u.CondominioId == condominioId)
            .ToListAsync();
    }
}
