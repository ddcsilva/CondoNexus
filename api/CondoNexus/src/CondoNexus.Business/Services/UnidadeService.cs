using CondoNexus.Business.Interfaces;
using CondoNexus.Business.Models;
using CondoNexus.Business.Validations;

namespace CondoNexus.Business.Services;

public class UnidadeService : BaseService, IUnidadeService
{
    public async Task Adicionar(Unidade unidade)
    {
        if (!ExecutarValidacao(new UnidadeValidation(), unidade)) return;
    }

    public async Task Atualizar(Unidade unidade)
    {
        if (!ExecutarValidacao(new UnidadeValidation(), unidade)) return;
    }

    public async Task Remover(Guid id)
    {

    }

    public void Dispose()
    {

    }
}
