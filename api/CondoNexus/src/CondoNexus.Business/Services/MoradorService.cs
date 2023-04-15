using CondoNexus.Business.Interfaces;
using CondoNexus.Business.Models;
using CondoNexus.Business.Validations;

namespace CondoNexus.Business.Services;

public class MoradorService : BaseService, IMoradorService
{
    private readonly IMoradorRepository _moradorRepository;

    public MoradorService(IMoradorRepository moradorRepository)
    {
        _moradorRepository = moradorRepository;
    }

    public async Task Adicionar(Morador morador)
    {
        if (!ExecutarValidacao(new MoradorValidation(), morador))
        {
            return;
        }

        await _moradorRepository.Adicionar(morador);
    }

    public async Task Atualizar(Morador morador)
    {
        if (!ExecutarValidacao(new MoradorValidation(), morador))
        {
            return;
        }

        await _moradorRepository.Atualizar(morador);
    }

    public async Task Remover(Guid id)
    {
        await _moradorRepository.Remover(id);
    }

    public void Dispose()
    {
        _moradorRepository?.Dispose();
    }
}
