using CondoNexus.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CondoNexus.Data.Mappings;

public class MoradorMapping : IEntityTypeConfiguration<Morador>
{
    public void Configure(EntityTypeBuilder<Morador> builder)
    {
        builder.HasKey(m => m.Id)
            .HasName("PK_MRD_ID");

        builder.Property(m => m.Id)
            .HasColumnName("MRD_ID");

        builder.Property(m => m.Nome)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasColumnName("MRD_NOME");

        builder.Property(m => m.CPF)
            .IsRequired()
            .HasColumnType("varchar(11)")
            .HasColumnName("MRD_CPF");

        builder.Property(m => m.Telefone)
            .IsRequired()
            .HasColumnType("varchar(20)")
            .HasColumnName("MRD_TELEFONE");

        builder.Property(m => m.Email)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasColumnName("MRD_EMAIL");

        builder.Property(m => m.DataNascimento)
            .IsRequired()
            .HasColumnName("MRD_DATA_NASCIMENTO");

        builder.Property(m => m.Foto)
            .IsRequired()
            .HasColumnType("varchar(255)")
            .HasColumnName("MRD_FOTO");

        builder.Property(m => m.UnidadeId)
            .HasColumnName("UND_ID");

        // Relacionamento N:1 com Unidade
        builder.HasOne(m => m.Unidade)
            .WithMany(u => u.Moradores)
            .HasForeignKey(m => m.UnidadeId)
            .HasConstraintName("FK_MORADORES_UNIDADES");

        builder.ToTable("TB_MORADORES");
    }
}
