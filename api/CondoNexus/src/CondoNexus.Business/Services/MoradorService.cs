using CondoNexus.Business.Interfaces;
using CondoNexus.Business.Models;
using CondoNexus.Business.Validations;

namespace CondoNexus.Business.Services;

public class MoradorService : BaseService, IMoradorService
{
    public async Task Adicionar(Morador morador)
    {
        if (!ExecutarValidacao(new MoradorValidation(), morador)) return;
    }

    public async Task Atualizar(Morador morador)
    {
        if (!ExecutarValidacao(new MoradorValidation(), morador)) return;
    }

    public async Task Remover(Guid id)
    {

    }

    public void Dispose()
    {

    }
}
