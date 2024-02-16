using ControleVenda.Infra.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Infra.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> b)
        {

            b.ToTable(nameof(Produto));

            b.HasKey(nameof(Produto.Id));
            b.Property(nameof(Produto.Id))
                .ValueGeneratedOnAdd();

            b.Property(b => b.Nome)
                .HasColumnName(nameof(Produto.Nome))
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            b.Property(nameof(Produto.CategoriaId))
                .HasColumnName(nameof(Produto.CategoriaId))
                .IsUnicode(false)
                .IsRequired();

            b.HasOne(o => o.Categoria)
                .WithMany(d => d.Produtos)
                .HasForeignKey(fk => fk.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            b.Property(b => b.ValorUnitario)
                .HasColumnName(nameof(Produto.ValorUnitario))
                .HasColumnType("decimal(16,2)")
                .IsRequired();

            b.Property(nameof(Produto.Quntidade))
                .HasColumnName(nameof(Produto.Quntidade))
                .IsUnicode(false)
                .IsRequired();

            b.HasIndex(c => c.Nome)
                .HasDatabaseName($"UK_{nameof(Produto)}" +
                $"_{nameof(Produto.Nome)}")
                .IsUnique();

        }
    }
}
