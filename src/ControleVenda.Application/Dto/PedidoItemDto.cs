using ControleVenda.CrossCutting.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Application.Dto
{
    public class PedidoItemDto
    {
        public PedidoItemDto() { }

        public PedidoItemDto(int? id)
        {
            Id = id;
        }

        public int? Id { get; private set; }
        public SimpleIdNameModel Produto { get; set; }
        public double ValorUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}
