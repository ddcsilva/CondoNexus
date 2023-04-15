using CondoNexus.Business.Models;
using System;
using System.Threading.Tasks;

namespace CondoNexus.Business.Interfaces
{
    public interface IUnidadeService : IDisposable
    {
        Task Adicionar(Unidade unidade);
        Task Atualizar(Unidade unidade);
        Task Remover(Guid id);
    }
}
