using ControleVenda.CrossCutting.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Application.Dto
{
    public class PedidoDto
    {

        public PedidoDto() { }

        public PedidoDto(int? id)
        {
            Id = id;
        }

        public int? Id { get; private set; }

        public DateTime Data { get; set; }
        public SimpleIdNameModel Cliente { get; set; }
        public double ValorTotal { get; set; }
        public bool Cancelado { get; set; }
        public IEnumerable<PedidoItemDto> Itens { get; set; }


    }
}
