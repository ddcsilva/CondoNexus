using CondoNexus.Business.Interfaces;
using CondoNexus.Business.Models;
using CondoNexus.Business.Validations;

namespace CondoNexus.Business.Services;

public class UnidadeService : BaseService, IUnidadeService
{
    private readonly IUnidadeRepository _unidadeRepository;

    public UnidadeService(IUnidadeRepository unidadeRepository)
    {
        _unidadeRepository = unidadeRepository;
    }

    public async Task Adicionar(Unidade unidade)
    {
        if (!ExecutarValidacao(new UnidadeValidation(), unidade))
        {
            return;
        }

        await _unidadeRepository.Adicionar(unidade);
    }

    public async Task Atualizar(Unidade unidade)
    {
        if (!ExecutarValidacao(new UnidadeValidation(), unidade))
        {
            return;
        }

        await _unidadeRepository.Atualizar(unidade);
    }

    public async Task Remover(Guid id)
    {
        await _unidadeRepository.Remover(id);
    }

    public void Dispose()
    {
        _unidadeRepository?.Dispose();
    }
}
