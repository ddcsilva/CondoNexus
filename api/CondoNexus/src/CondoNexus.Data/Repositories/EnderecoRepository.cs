using CondoNexus.Business.Interfaces.Repositories;
using CondoNexus.Business.Models;
using CondoNexus.Data.Contexts;

namespace CondoNexus.Data.Repositories;

public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
{
    public EnderecoRepository(CondoNexusContext context) : base(context)
    {
    }
}