using CondoNexus.Business.Models;

namespace CondoNexus.Business.Interfaces.Services
{
    public interface IMoradorService : IDisposable
    {
        Task Adicionar(Morador morador);
        Task Atualizar(Morador morador);
        Task Remover(Guid id);
    }
}
