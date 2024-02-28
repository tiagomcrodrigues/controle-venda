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
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> b)
        {
            b.ToTable(nameof(Pedido));

            b.HasKey(nameof(Pedido.Id));
            b.Property(nameof(Pedido.Id))
                .ValueGeneratedOnAdd();

            b.Property(b => b.Data)
                .HasColumnName(nameof(Pedido.Data))
                .IsRequired();

            b.Property(b => b.ClienteId)
               .HasColumnName(nameof(Pedido.ClienteId))
               .IsRequired();

            b.Property(b => b.ValorTotal)
                .HasColumnName(nameof(Pedido.ValorTotal))
                .HasColumnType("decimal(16,2)")
                .IsRequired();
            
            b.Property(b => b.Cancelado)
                .HasColumnName(nameof(Pedido.Cancelado))
                .HasColumnType("bit")
                .IsRequired();


            b.HasOne(o => o.Cliente)
                .WithMany(d => d.Pedidos)
                .HasForeignKey(fk => fk.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
