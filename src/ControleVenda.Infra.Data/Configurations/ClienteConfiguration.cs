using ControleVenda.Infra.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleVenda.Infra.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> b)
        {
            b.ToTable(nameof(Cliente));   

            #region Campos

            b.HasKey(nameof(Cliente.Id));
            b.Property(nameof(Cliente.Id))
                .ValueGeneratedOnAdd();

            b.Property(b => b.Nome)
                .HasColumnName(nameof(Cliente.Nome))
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            b.Property(b =>b.TipoPessoa)
                .HasColumnName(nameof(Cliente.TipoPessoa))
                .HasColumnType("char(1)")
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.Documento)
                .HasColumnName(nameof(Cliente.Documento))
                .HasMaxLength(14)
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.TipoLogradouro)
                .HasColumnName(nameof(Cliente.TipoLogradouro))
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.Logradouro)
                .HasColumnName(nameof(Cliente.Logradouro))
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.Numero)
                .HasColumnName(nameof(Cliente.Numero))
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.Complemento)
                .HasColumnName(nameof(Cliente.Complemento))
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.Bairro)
                .HasColumnName(nameof(Cliente.Bairro))
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.Cidade)
                .HasColumnName(nameof(Cliente.Cidade))
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.Uf)
                .HasColumnName(nameof(Cliente.Uf))
                .HasColumnType("char(20)")
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.Telefone)
                .HasColumnName(nameof(Cliente.Telefone))
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsRequired();

            b.Property(b => b.Email)
                .HasColumnName(nameof(Cliente.Email))
                .HasMaxLength(254)
                .IsUnicode(false)
                .IsRequired();

            #endregion


            #region Indices

            b.HasIndex(c => c.Nome)
                .HasDatabaseName($"IX_{nameof(Cliente)}_{nameof(Cliente.Nome)}");

            b.HasIndex(c => c.Documento)
                .HasDatabaseName($"UK_{nameof(Cliente)}_{nameof(Cliente.Documento)}")
                .IsUnique();

            #endregion


        }
    }
}
