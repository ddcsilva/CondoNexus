using CondoNexus.Business.Interfaces;
using CondoNexus.Business.Models;
using CondoNexus.Business.Validations;

namespace CondoNexus.Business.Services;

public class VeiculoService : BaseService, IVeiculoService
{
    public async Task Adicionar(Veiculo veiculo)
    {
        if (!ExecutarValidacao(new VeiculoValidation(), veiculo)) return;
    }

    public async Task Atualizar(Veiculo veiculo)
    {
        if (!ExecutarValidacao(new VeiculoValidation(), veiculo)) return;
    }

    public async Task Remover(Guid id)
    {

    }

    public void Dispose()
    {

    }
}
