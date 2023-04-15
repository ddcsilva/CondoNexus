using CondoNexus.Business.Models;

namespace CondoNexus.Business.Interfaces.Repositories;

public interface IUnidadeRepository : IRepository<Unidade>
{
    Task<List<Unidade>> ObterUnidadesPorCondominio(Guid condominioId);
    Task<List<Unidade>> ObterUnidadesPorAndar(int andar);
    Task<List<Unidade>> ObterUnidadesComMoradores();
    Task<List<Unidade>> ObterUnidadesComVeiculos();
    Task<List<Unidade>> ObterUnidadesComMoradoresEVeiculos(Guid condominioId);
}