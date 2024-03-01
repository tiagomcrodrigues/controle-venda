using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Entities;

namespace ControleVenda.Domain.Ports
{
    public interface IPedidoService
    {
        IResult<int> Add(Pedido pedido);
        void Cancel(Pedido pedido);
        IEnumerable<Pedido> GetAll();
        Pedido? GetById(int id);
    }
}