using ControleVenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Infra.Data.Tables
{
    public class Pedido : IKeyIdentitication
    {
        public int Id { get; private set; }

        public DateTime Data { get; set; }
        public int ClienteId { get; set; }
        public double ValorTotal { get; set; }
        public bool Cancelado { get; set; }
       
        public ICollection<PedidoItem> Itens { get; set; }
        
        public Cliente Cliente { get; set; }
    }
}
