using ControleVenda.Application.Dto;
using ControleVenda.Application.Ports.Pedidos;
using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Application.UseCases.Pedido
{
    public class PedidoCancelUseCase : UseCaseBase<IPedidoService>, IPedidoCancelUseCase
    {
        public PedidoCancelUseCase(IPedidoService service) : base(service)
        {
        }

        public IResult<int> Execute(int id)
        {
            var pedido = _service.GetById(id);
           = _service.Cancel(pedido);
        }
    }
}
