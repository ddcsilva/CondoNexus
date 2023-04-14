using CondoNexus.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CondoNexus.Data.Mappings;

public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName("PK_END_ID");

        builder.Property(e => e.Id)
            .HasColumnName("END_ID");

        builder.Property(e => e.Logradouro)
            .IsRequired()
            .HasColumnType("varchar(200)")
            .HasColumnName("END_LOGRADOURO");

        builder.Property(e => e.Numero)
            .IsRequired()
            .HasColumnType("varchar(10)")
            .HasColumnName("END_NUMERO");

        builder.Property(e => e.Complemento)
            .HasColumnType("varchar(100)")
            .HasColumnName("END_COMPLEMENTO");

        builder.Property(e => e.Cep)
            .IsRequired()
            .HasColumnType("varchar(8)")
            .HasColumnName("END_CEP");

        builder.Property(e => e.Bairro)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasColumnName("END_BAIRRO");

        builder.Property(e => e.Cidade)
            .IsRequired()
            .HasColumnType("varchar(100)")
            .HasColumnName("END_CIDADE");

        builder.Property(e => e.Estado)
            .IsRequired()
            .HasColumnType("varchar(2)")
            .HasColumnName("END_ESTADO");

        builder.Property(e => e.CondominioId)
            .HasColumnName("CND_ID");

        // Relacionamento 1:1 com Condomínio
        builder.HasOne(e => e.Condominio)
            .WithOne(c => c.Endereco)
            .HasForeignKey<Endereco>(e => e.CondominioId)
            .HasConstraintName("FK_ENDERECOS_CONDOMINIOS");

        builder.ToTable("TB_ENDERECOS");
    }
}
