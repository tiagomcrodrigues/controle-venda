using ControleVenda.Application.Dto;
using ControleVenda.Application.Extensions;
using ControleVenda.Application.Ports.Pedidos;
using ControleVenda.Domain.Ports;

namespace ControleVenda.Application.UseCases.Pedido
{
    public class PedidoGetByIdUseCase : UseCaseBase<IPedidoService>, IPedidoGetByIdUseCase
    {
        public PedidoGetByIdUseCase(IPedidoService service) : base(service)
        {
        }

        public PedidoDto? Execute(int id)
         => _service.GetById(id).Map();
    }
}
