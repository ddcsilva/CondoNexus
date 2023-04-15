using CondoNexus.Business.Models;

namespace CondoNexus.Business.Interfaces
{
    public interface IVeiculoService : IDisposable
    {
        Task Adicionar(Veiculo veiculo);
        Task Atualizar(Veiculo veiculo);
        Task Remover(Guid id);
    }
}
