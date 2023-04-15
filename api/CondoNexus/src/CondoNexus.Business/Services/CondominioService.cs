using CondoNexus.Business.Interfaces;
using CondoNexus.Business.Models;
using CondoNexus.Business.Validations;

namespace CondoNexus.Business.Services;

public class FornecedorService : BaseService, ICondominioService
{
    public async Task Adicionar(Condominio condominio)
    {
        if (!ExecutarValidacao(new CondominioValidation(), condominio)) return;

        if (!ExecutarValidacao(new EnderecoValidation(), condominio.Endereco)) return;
    }

    public async Task Atualizar(Condominio condominio)
    {
        if (!ExecutarValidacao(new CondominioValidation(), condominio)) return;
    }

    public async Task AtualizarEndereco(Endereco endereco)
    {
        if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;
    }

    public async Task Remover(Guid id)
    {

    }

    public void Dispose()
    {

    }
}
