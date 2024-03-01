using ControleVenda.Api.Models.Requests;
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

    }

}