﻿using CondoNexus.Business.Interfaces;
using CondoNexus.Business.Interfaces.Repositories;
using CondoNexus.Business.Interfaces.Services;
using CondoNexus.Business.Models;
using CondoNexus.Business.Validations;

namespace CondoNexus.Business.Services;

public class UnidadeService : BaseService, IUnidadeService
{
    private readonly IUnidadeRepository _unidadeRepository;

    public UnidadeService(IUnidadeRepository unidadeRepository, 
                          INotificador notificador) : base(notificador)
    {
        _unidadeRepository = unidadeRepository;
    }

    public async Task Adicionar(Unidade unidade)
    {
        if (!ExecutarValidacao(new UnidadeValidation(), unidade))
        {
            return;
        }

        if (_unidadeRepository.Buscar(f => f.Numero == unidade.Numero && f.CondominioId == unidade.CondominioId).Result.Any())
        {
            Notificar("Já existe uma unidade com este número no condomínio.");
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

        var unidadeExistente = await _unidadeRepository.Buscar(f => f.Numero == unidade.Numero && f.CondominioId == unidade.CondominioId && f.Id != unidade.Id);
        if (unidadeExistente.Any())
        {
            Notificar("Já existe uma unidade com este número no condomínio.");
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
