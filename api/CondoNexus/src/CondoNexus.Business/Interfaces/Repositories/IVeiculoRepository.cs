using CondoNexus.Business.Models;

namespace CondoNexus.Business.Interfaces.Repositories;

public interface IVeiculoRepository : IRepository<Veiculo>
{
    Task<List<Veiculo>> ObterVeiculosPorUnidade(Guid unidadeId);
}