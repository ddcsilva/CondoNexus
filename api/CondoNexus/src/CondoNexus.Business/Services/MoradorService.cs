using CondoNexus.Business.Interfaces;
using CondoNexus.Business.Interfaces.Repositories;
using CondoNexus.Business.Interfaces.Services;
using CondoNexus.Business.Models;
using CondoNexus.Business.Validations;

namespace CondoNexus.Business.Services;

public class MoradorService : BaseService, IMoradorService
{
    private readonly IMoradorRepository _moradorRepository;

    public MoradorService(IMoradorRepository moradorRepository,
                          INotificador notificador) : base(notificador)
    {
        _moradorRepository = moradorRepository;
    }

    public async Task Adicionar(Morador morador)
    {
        if (!ExecutarValidacao(new MoradorValidation(), morador))
        {
            return;
        }

        if (_moradorRepository.Buscar(f => f.CPF == morador.CPF).Result.Any())
        {
            Notificar("Já existe um morador com este CPF informado.");
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

        var moradorExistente = await _moradorRepository.Buscar(f => f.CPF == morador.CPF && f.Id != morador.Id);
        if (moradorExistente.Any())
        {
            Notificar("Já existe um morador com este CPF informado.");
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
