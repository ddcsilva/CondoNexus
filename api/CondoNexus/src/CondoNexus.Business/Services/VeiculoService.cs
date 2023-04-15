using CondoNexus.Business.Interfaces;
using CondoNexus.Business.Models;
using CondoNexus.Business.Validations;

namespace CondoNexus.Business.Services;

public class VeiculoService : BaseService, IVeiculoService
{
    private readonly IVeiculoRepository _veiculoRepository;

    public VeiculoService(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task Adicionar(Veiculo veiculo)
    {
        if (!ExecutarValidacao(new VeiculoValidation(), veiculo))
        {
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
