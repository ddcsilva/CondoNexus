using CondoNexus.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondoNexus.Data.Mappings;

public class VeiculoMapping : IEntityTypeConfiguration<Veiculo>
{
    public void Configure(EntityTypeBuilder<Veiculo> builder)
    {
        builder.HasKey(v => v.Id)
            .HasName("PK_VCL_ID");

        builder.Property(v => v.Id)
            .HasColumnName("VCL_ID");

        builder.Property(v => v.Placa)
            .IsRequired()
            .HasColumnType("varchar(7)")
            .HasColumnName("VCL_PLACA");

        builder.Property(v => v.Marca)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasColumnName("VCL_MARCA");

        builder.Property(v => v.Modelo)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasColumnName("VCL_MODELO");

        builder.Property(v => v.Cor)
            .IsRequired()
            .HasColumnType("varchar(50)")
            .HasColumnName("VCL_COR");

        builder.Property(v => v.Ano)
            .IsRequired()
            .HasColumnName("VCL_ANO");

        builder.Property(v => v.UnidadeId)
            .HasColumnName("UND_ID");

        // Relacionamento N:1 com Unidade
        builder.HasOne(v => v.Unidade)
            .WithMany(u => u.Veiculos)
            .HasForeignKey(v => v.UnidadeId)
            .HasConstraintName("FK_VEICULOS_UNIDADES");

        builder.ToTable("TB_VEICULOS");
    }
}
