using CondoNexus.Business.Models;

namespace CondoNexus.Business.Interfaces;

public interface IMoradorRepository : IRepository<Morador>
{
    Task<List<Morador>> ObterMoradoresPorUnidade(Guid unidadeId);
    Task<List<Morador>> ObterMoradoresPorCondominio(Guid condominioId);
    Task<List<Morador>> ObterMoradoresPorDataNascimento(DateTime dataNascimento);
    Task<List<Morador>> ObterMoradoresComVeiculos(Guid unidadeId);
}