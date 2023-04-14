using CondoNexus.Business.Interfaces;
using CondoNexus.Business.Models;
using CondoNexus.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CondoNexus.Data.Repositories;

public class MoradorRepository : Repository<Morador>, IMoradorRepository
{
    public MoradorRepository(CondoNexusContext context) : base(context)
    {
    }

    public async Task<List<Morador>> ObterMoradoresPorUnidade(Guid unidadeId)
    {
        return await _dbSet.AsNoTracking()
            .Where(m => m.UnidadeId == unidadeId)
            .ToListAsync();
    }

    public async Task<List<Morador>> ObterMoradoresPorCondominio(Guid condominioId)
    {
        return await _dbSet.AsNoTracking()
            .Include(m => m.Unidade)
            .Where(m => m.Unidade.CondominioId == condominioId)
            .ToListAsync();
    }

    public async Task<List<Morador>> ObterMoradoresPorDataNascimento(DateTime dataNascimento)
    {
        return await _dbSet.AsNoTracking()
            .Where(m => m.DataNascimento.Date == dataNascimento.Date)
            .ToListAsync();
    }

    public async Task<List<Morador>> ObterMoradoresComVeiculos(Guid unidadeId)
    {
        return await _dbSet.AsNoTracking()
            .Include(m => m.Unidade)
            .ThenInclude(u => u.Veiculos)
            .Where(m => m.UnidadeId == unidadeId)
            .ToListAsync();
    }

}
