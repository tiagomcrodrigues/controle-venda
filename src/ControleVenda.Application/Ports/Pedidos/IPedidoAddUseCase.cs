using ControleVenda.Application.Dto;
using ControleVenda.CrossCutting.Common.Models;

namespace ControleVenda.Application.Ports.Pedidos
{
    public interface IPedidoAddUseCase
    {
        IResult<int> Execute(PedidoDto dto);
    }
}
