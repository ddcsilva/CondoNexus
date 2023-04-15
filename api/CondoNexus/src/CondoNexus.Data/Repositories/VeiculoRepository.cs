using CondoNexus.Business.Interfaces;
using CondoNexus.Business.Models;
using CondoNexus.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CondoNexus.Data.Repositories;

public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
{
    public VeiculoRepository(CondoNexusContext context) : base(context)
    {
    }

    public async Task<List<Veiculo>> ObterVeiculosPorUnidade(Guid unidadeId)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(v => v.UnidadeId == unidadeId)
            .ToListAsync();
    }
}