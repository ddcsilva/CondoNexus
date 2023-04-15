using CondoNexus.Business.Interfaces;
using CondoNexus.Business.Interfaces.Repositories;
using CondoNexus.Business.Interfaces.Services;
using CondoNexus.Business.Models;
using CondoNexus.Business.Validations;

namespace CondoNexus.Business.Services;

public class VeiculoService : BaseService, IVeiculoService
{
    private readonly IVeiculoRepository _veiculoRepository;

    public VeiculoService(IVeiculoRepository veiculoRepository, 
                          INotificador notificador) : base(notificador)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task Adicionar(Veiculo veiculo)
    {
        if (!ExecutarValidacao(new VeiculoValidation(), veiculo))
        {
            return;
        }

        if (_veiculoRepository.Buscar(f => f.Placa == veiculo.Placa).Result.Any())
        {
            Notificar("Já existe um veículo com esta placa informada.");
            return;
        }

        await _veiculoRepository.Adicionar(veiculo);
    }

    public async Task Atualizar(Veiculo veiculo)
    {
        if (!ExecutarValidacao(new VeiculoValidation(), veiculo))
        {
            return;
        }

        var veiculoExistente = await _veiculoRepository.Buscar(f => f.Placa == veiculo.Placa && f.Id != veiculo.Id);
        if (veiculoExistente.Any())
        {
            Notificar("Já existe um veículo com esta placa informada.");
            return;
        }

        await _veiculoRepository.Atualizar(veiculo);
    }

    public async Task Remover(Guid id)
    {
        await _veiculoRepository.Remover(id);
    }

    public void Dispose()
    {
        _veiculoRepository?.Dispose();
    }
}
