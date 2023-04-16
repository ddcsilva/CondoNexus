using CondoNexus.Business.Models;

namespace CondoNexus.Business.Interfaces.Repositories;

public interface IMoradorRepository : IRepository<Morador>
{
    Task<List<Morador>> ObterMoradoresUnidades();
    Task<List<Morador>> ObterMoradoresPorUnidade(Guid unidadeId);
    Task<List<Morador>> ObterMoradoresPorCondominio(Guid condominioId);
    Task<List<Morador>> ObterMoradoresPorDataNascimento(DateTime dataNascimento);
    Task<List<Morador>> ObterMoradoresComVeiculos(Guid unidadeId);
    Task<Morador> ObterMoradorUnidade(Guid moradorId);
}