using ControleVenda.Application.Dto;
using ControleVenda.Application.Extensions;
using ControleVenda.Application.Ports.Pedidos;
using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Ports;

namespace ControleVenda.Application.UseCases.Pedidos
{
    public class PedidoAddUseCase : UseCaseBase<IPedidoService>, IPedidoAddUseCase
    {

        public PedidoAddUseCase(IPedidoService pedidoService) : base(pedidoService) { }
        
        public IResult<int> Execute(PedidoDto dto)
            => _service.Add(dto.Map());

    }
}
