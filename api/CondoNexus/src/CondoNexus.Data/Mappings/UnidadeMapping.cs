using CondoNexus.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondoNexus.Data.Mappings;

public class UnidadeMapping : IEntityTypeConfiguration<Unidade>
{
    public void Configure(EntityTypeBuilder<Unidade> builder)
    {
        builder.HasKey(u => u.Id)
            .HasName("PK_UND_ID");

        builder.Property(u => u.Id)
            .HasColumnName("UND_ID");

        builder.Property(u => u.Numero)
            .IsRequired()
            .HasColumnType("varchar(10)")
            .HasColumnName("UND_NUMERO");

        builder.Property(u => u.Andar)
            .IsRequired()
            .HasColumnName("UND_ANDAR");

        builder.Property(u => u.Bloco)
            .IsRequired()
            .HasColumnType("varchar(10)")
            .HasColumnName("UND_BLOCO");

        builder.Property(u => u.StatusResidencial)
            .IsRequired()
            .HasColumnName("UND_STATUS_RESIDENCIAL");

        builder.Property(u => u.CondominioId)
            .HasColumnName("CND_ID");

        // Relacionamento N:1 com Condomínio
        builder.HasOne(u => u.Condominio)
            .WithMany(c => c.Unidades)
            .HasForeignKey(u => u.CondominioId)
            .HasConstraintName("FK_UNIDADES_CONDOMINIOS");

        // Relacionamento 1:N com Morador
        builder.HasMany(u => u.Moradores)
            .WithOne(m => m.Unidade)
            .HasForeignKey(m => m.UnidadeId)
            .HasConstraintName("FK_MORADORES_UNIDADES");

        // Relacionamento 1:N com Veículo
        builder.HasMany(u => u.Veiculos)
            .WithOne(v => v.Unidade)
            .HasForeignKey(v => v.UnidadeId)
            .HasConstraintName("FK_VEICULOS_UNIDADES");

        builder.ToTable("TB_UNIDADES");
    }
}
