using ControleVenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Domain.Ports
{
    public interface IPedidoRepository
    {
        int Add(Pedido pedido);
        IEnumerable<Pedido> GetAll();
        Pedido? GetById(int id);
        void Cancel(Pedido pedido);
    }
}
