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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define colunas string como "varchar(100)" por padrão
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
        {
                property.SetColumnType("varchar(100)");
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CondoNexusContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
