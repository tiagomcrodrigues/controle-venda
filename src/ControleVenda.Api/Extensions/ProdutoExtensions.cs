using ControleVenda.Api.Models.Requests;
using ControleVenda.Api.Models.Responses;
using ControleVenda.Application.Dto;

namespace ControleVenda.Api.Extensions
{
    public static class ProdutoExtensions
    {
        public static ProdutoDto Map(this ProdutoRequest request, int? id = null)
        {
            return new ProdutoDto()
            {
                Id = id,
                Nome = request.Nome,
                ValorUnitario = request.ValorUnitario,
                Quantidade = request.Quantidade,
                Categoria = new CategoriaDto(request.CategoriaId)
            };
        }

        public static ProdutoResponse Map(this ProdutoDto dto)
        {
            return new()
            {
                Id = dto.Id.Value,
                Nome = dto.Nome,
                Categoria = dto.Categoria.Map(),
                Quantidade= dto.Quantidade,
                ValorUnitario = dto.ValorUnitario
            };
        }






    }
}
