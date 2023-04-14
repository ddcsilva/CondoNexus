using CondoNexus.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace CondoNexus.Data.Contexts;

public class CondoNexusContext : DbContext
{
    public CondoNexusContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Condominio> Condominios { get; set; }
    public DbSet<Unidade> Unidades { get; set; }
    public DbSet<Morador> Moradores { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }
}
