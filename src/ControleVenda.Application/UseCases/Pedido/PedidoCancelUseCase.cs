using ControleVenda.Application.Ports.Pedidos;
using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Ports;

namespace ControleVenda.Application.UseCases.Pedido
{
    public class PedidoCancelUseCase : UseCaseBase<IPedidoService>, IPedidoCancelUseCase
    {
        public PedidoCancelUseCase(IPedidoService service) : base(service)
        {
        }

        public IResult<bool> Execute(int id)
        {
            var pedido = _service.GetById(id);
            if (pedido == null)
                return new Result<bool>(false);
            else
            {
                _service.Cancel(pedido);
                return new Result<bool>(true);
            }


        }
    }
}
