using ControleVenda.Infra.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleVenda.Infra.Data.Configurations
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> b)
        {
            b.ToTable(nameof(PedidoItem));

            b.HasKey(nameof(PedidoItem.Id));
            b.Property(nameof(PedidoItem.Id))
                .ValueGeneratedOnAdd();

            b.Property(b => b.PedidoId)
                .HasColumnName(nameof(PedidoItem.PedidoId))
                .IsRequired();

            b.Property(b => b.ProdutoId)
                .HasColumnName(nameof(PedidoItem.ProdutoId))
                .IsRequired();

            b.Property(b => b.ValorUnitario)
                .HasColumnName(nameof(PedidoItem.ValorUnitario))
                .HasColumnType("decimal(16,2)")
                .IsRequired();

            b.Property(nameof(PedidoItem.Quantidade))
                .HasColumnName(nameof(PedidoItem.Quantidade))
                .IsUnicode(false)
                .IsRequired();

            b.HasOne(o => o.Pedido)
                .WithMany(d => d.Itens)
                .HasForeignKey(fk => fk.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);

            b.HasOne(o => o.Produto)
                .WithMany(d => d.Itens)
                .HasForeignKey(fk =>fk.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
