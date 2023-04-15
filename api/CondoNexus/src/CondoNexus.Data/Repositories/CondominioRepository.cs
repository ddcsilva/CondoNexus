using CondoNexus.Business.Interfaces.Repositories;
using CondoNexus.Business.Models;
using CondoNexus.Business.Models.Enums;
using CondoNexus.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CondoNexus.Data.Repositories;

public class CondominioRepository : Repository<Condominio>, ICondominioRepository
{
    public CondominioRepository(CondoNexusContext context) : base(context)
    {
    }

    public async Task<Condominio?> ObterCondominioEndereco(Guid condominioId)
    {
        return await _context.Condominios
            .Include(c => c.Endereco)
            .FirstOrDefaultAsync(c => c.Id == condominioId);
    }

    public async Task<Condominio?> ObterCondominioComUnidadesOcupadas(Guid condominioId)
    {
        return await _context.Condominios
            .Include(c => c.Unidades)
            .Include(c => c.Endereco)
            .Where(c => c.Id == condominioId)
            .Select(c => new Condominio
            {
                Id = c.Id,
                Nome = c.Nome,
                CNPJ = c.CNPJ,
                NumeroUnidades = c.NumeroUnidades,
                NumeroBlocos = c.NumeroBlocos,
                NumeroAndares = c.NumeroAndares,
                DataFundacao = c.DataFundacao,
                Unidades = c.Unidades.Where(u => u.StatusResidencial == StatusResidencial.Ocupado).ToList(),
                Endereco = c.Endereco
            })
            .FirstOrDefaultAsync();
    }
}