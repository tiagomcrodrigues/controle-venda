using ControleVenda.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Application.Ports.Pedidos
{
    public interface IPedidoGetAllUseCase
    {
        IEnumerable<PedidoDto?> Execute();
    }
}
