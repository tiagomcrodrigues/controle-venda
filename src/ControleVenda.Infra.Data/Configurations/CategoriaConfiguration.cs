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
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> b)
        {
            b.ToTable(nameof(Categoria));

            b.HasKey(nameof(Categoria.Id));
            b.Property(nameof(Categoria.Id))
                .ValueGeneratedOnAdd();

            b.Property(b => b.Nome)
                .HasColumnName(nameof(Categoria.Nome))
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            b.HasIndex(c => c.Nome)
                .HasDatabaseName($"UK_{nameof(Categoria)}_{nameof(Categoria.Nome)}")
                .IsUnique();
        }
    }
}
