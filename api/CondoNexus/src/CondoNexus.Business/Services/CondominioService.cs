using CondoNexus.Business.Interfaces;
using CondoNexus.Business.Models;
using CondoNexus.Business.Validations;

namespace CondoNexus.Business.Services;

public class CondominioService : BaseService, ICondominioService
{
    private readonly ICondominioRepository _condominioRepository;
    private readonly IEnderecoRepository _enderecoRepository;

    public CondominioService(ICondominioRepository condominioRepository,
                             IEnderecoRepository enderecoRepository)
    {
        _condominioRepository = condominioRepository;
        _enderecoRepository = enderecoRepository;
    }

    public async Task Adicionar(Condominio condominio)
    {
        if (!ExecutarValidacao(new CondominioValidation(), condominio))
        {
            return;
        }

        if (!ExecutarValidacao(new EnderecoValidation(), condominio.Endereco))
        {
            return;
        }

        if (_condominioRepository.Buscar(f => f.CNPJ == condominio.CNPJ).Result.Any())
        {
            Notificar("Já existe um condomínio com este CNPJ infomado.");
            return;
        }

        await _condominioRepository.Adicionar(condominio);
    }

    public async Task Atualizar(Condominio condominio)
    {
        if (!ExecutarValidacao(new CondominioValidation(), condominio))
        {
            return;
        }

        await _condominioRepository.Atualizar(condominio);
    }

    public async Task AtualizarEndereco(Endereco endereco)
    {
        if (!ExecutarValidacao(new EnderecoValidation(), endereco))
        {
            return;
        }

        await _enderecoRepository.Atualizar(endereco);
    }

    public async Task Remover(Guid id)
    {
        if (_condominioRepository.ObterCondominioComUnidadesOcupadas(id).Result.Unidades.Any())
        {
            Notificar("O condominio possui unidades que estão ocupadas!");
            return;
        }

        await _condominioRepository.Remover(id);
    }

    public void Dispose()
    {
        _enderecoRepository?.Dispose();
        _condominioRepository?.Dispose();
    }
}
