using ControleVenda.Api.Models.Requests;
using ControleVenda.Api.Models.Responses;
using ControleVenda.Application.Dto;
using ControleVenda.CrossCutting.Common.Models;

namespace ControleVenda.Api.Extensions
{
    public static class PedidoExtension
    {

        public static PedidoDto Map(this PedidoRequest request) 
            => new()
            {
                Cliente = new() { Id = request.ClenteId.Value },
                Itens = request.Itens.Select(s => s.Map()).ToList()
            };

        public static PedidoItemDto Map(this PedidoItemRequest request) 
            => new()
            {
                Produto = new() { Id = request.ProdutoId.Value },
                Quantidade = request.Quantidade.Value
            };



        public static PedidoResponse Map(this PedidoDto dto)
            => new()
            {
                Id = dto.Id,
                Data = dto.Data,
                Cliente = dto.Cliente,
                Itens = dto.Itens.Select(s => s.Map()).ToList(),
                ValorTotal = dto.ValorTotal,
                Cancelado = dto.Cancelado,
            };


        public static PedidoItemResponse Map(this PedidoItemDto dto)
           => new()
           {
              Id = dto.Id,
              Produto = dto.Produto,
              Quantidade = dto.Quantidade,
              ValorUnitario = dto.ValorUnitario
           };



    }

}