using CondoNexus.Business.Models;

namespace CondoNexus.Business.Interfaces;

public interface IVeiculoRepository : IRepository<Veiculo>
{
    Task<List<Veiculo>> ObterVeiculosPorUnidade(Guid unidadeId);
}