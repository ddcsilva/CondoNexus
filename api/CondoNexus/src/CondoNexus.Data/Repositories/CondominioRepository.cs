using CondoNexus.Business.Interfaces;
using CondoNexus.Business.Models;
using CondoNexus.Data.Contexts;

namespace CondoNexus.Data.Repositories;

public class CondominioRepository : Repository<Condominio>, ICondominioRepository
{
    public CondominioRepository(CondoNexusContext context) : base(context)
    {
    }
}