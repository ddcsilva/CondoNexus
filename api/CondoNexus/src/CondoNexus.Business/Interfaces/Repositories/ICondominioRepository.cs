using CondoNexus.Business.Models;

namespace CondoNexus.Business.Interfaces.Repositories;

public interface ICondominioRepository : IRepository<Condominio>
{
    Task<Condominio?> ObterCondominioEndereco(Guid condominioId);
    Task<Condominio?> ObterCondominioComUnidadesOcupadas(Guid condominioId);
}