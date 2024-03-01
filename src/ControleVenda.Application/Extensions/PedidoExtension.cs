using ControleVenda.Application.Dto;
using ControleVenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ControleVenda.Application.Extensions
{
    public static class PedidoExtension
    {
        public static Pedido Map(this PedidoDto dto )
        {
            Pedido entidade =
                dto.Id.HasValue
                ? new Pedido(dto.Id.Value)
                : new Pedido();
            entidade.Cliente = dto.Cliente;
            entidade.Itens = dto.Itens.Select(s => s.Map()).ToList();
            return entidade;
        }


        public static PedidoDto? Map(this Pedido? entidade)
        {
            if (entidade == null)
                return null;
            return new(entidade.Id)
            {
                Cliente = entidade.Cliente,
                Data = entidade.Data,
                Cancelado = entidade.Cancelado,
                ValorTotal = entidade.ValorTotal,
                Itens = entidade.Itens.Select(s => s.Map()).ToList()
            };

        }
        public static PedidoItemDto Map(this PedidoItem entidade)
        {
            return new PedidoItemDto(entidade.Id)
            {
                Quantidade = entidade.Quantidade,
                ValorUnitario = entidade.ValorUnitario,
                Produto = entidade.Produto
            };
        }

        public static PedidoItem Map(this PedidoItemDto dto)
        {
            return new()
            {
                Produto = dto.Produto,
                Quantidade = dto.Quantidade,
                ValorUnitario = dto.ValorUnitario
            };
        }

    }
}
