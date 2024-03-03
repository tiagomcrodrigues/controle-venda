using ControleVenda.Application.Dto;
using ControleVenda.Application.Extensions;
using ControleVenda.Application.Ports.Categorias;
using ControleVenda.Application.Ports.Pedidos;
using ControleVenda.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Application.UseCases.Pedido
{
    public class PedidoGetAllUseCase : UseCaseBase<IPedidoService>, IPedidoGetAllUseCase
    {
        public PedidoGetAllUseCase(IPedidoService service) : base(service)
        {
        }

        public IEnumerable<PedidoDto> Execute()
            => _service.GetAll().Select(s => s.Map());
    }
}
