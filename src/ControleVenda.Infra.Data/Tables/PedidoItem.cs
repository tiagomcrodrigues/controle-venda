using ControleVenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Infra.Data.Tables
{
    public class PedidoItem : IKeyIdentitication
    {
        public int Id { get; private set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int ValorUnitario { get; set; }
        public int Quantidade { get; set; }

        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }

    }
}
