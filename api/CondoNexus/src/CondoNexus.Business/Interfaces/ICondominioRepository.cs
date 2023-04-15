using CondoNexus.Business.Models;

namespace CondoNexus.Business.Interfaces;

public interface ICondominioRepository : IRepository<Condominio>
{
    Task<Condominio?> ObterCondominioComUnidadesOcupadas(Guid condominioId);
}