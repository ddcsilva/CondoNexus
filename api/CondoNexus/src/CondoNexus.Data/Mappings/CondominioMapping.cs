using CondoNexus.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondoNexus.Data.Mappings;

public class CondominioMapping : IEntityTypeConfiguration<Condominio>
{
    public void Configure(EntityTypeBuilder<Condominio> builder)
    {
        builder.HasKey(c => c.Id)
            .HasName("PK_CND_ID");

        builder.Property(c => c.Id)
            .HasColumnName("CND_ID");

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasColumnName("CND_NOME");

        builder.Property(c => c.CNPJ)
            .IsRequired()
            .HasColumnType("varchar(14)")
            .HasColumnName("CND_CNPJ");

        builder.Property(c => c.NumeroUnidades)
            .IsRequired()
            .HasColumnName("CND_NUMERO_UNIDADES");

        builder.Property(c => c.NumeroBlocos)
            .IsRequired()
            .HasColumnName("CND_NUMERO_BLOCOS");

        builder.Property(c => c.NumeroAndares)
            .IsRequired()
            .HasColumnName("CND_NUMERO_ANDARES");

        builder.Property(c => c.DataFundacao)
            .IsRequired()
            .HasColumnName("CND_DATA_FUNDACAO");

        // Relacionamento 1:N com Unidade
        builder.HasMany(c => c.Unidades)
            .WithOne(u => u.Condominio)
            .HasForeignKey(u => u.CondominioId)
            .HasConstraintName("FK_UNIDADES_CONDOMINIOS");

        // Relacionamento 1:1 com Endereco
        builder.HasOne(c => c.Endereco)
            .WithOne(e => e.Condominio)
            .HasForeignKey<Endereco>(e => e.CondominioId)
            .HasConstraintName("FK_ENDERECOS_CONDOMINIOS");

        builder.ToTable("TB_CONDOMINIOS");
    }
}