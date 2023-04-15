using CondoNexus.Business.Models;

namespace CondoNexus.Business.Interfaces.Services;

public interface IUnidadeService : IDisposable
{
    Task Adicionar(Unidade unidade);
    Task Atualizar(Unidade unidade);
    Task Remover(Guid id);
}
