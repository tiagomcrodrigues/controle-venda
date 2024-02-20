using ControleVenda.Application.Dto;
using ControleVenda.Domain.Entities;

namespace ControleVenda.Application.Extensions
{
    public static class ProdutoExtension
    {

        public static Produto Map(this ProdutoDto dto)
        {
            Produto entidade = 
                dto.Id.HasValue
                ? new Produto(dto.Id.Value)
                : new Produto();
            entidade.Nome = dto.Nome;
            entidade.Categoria = dto.Categoria?.Map();
            entidade.Quantidade = dto.Quantidade;
            entidade.ValorUnitario = dto.ValorUnitario;
            return entidade;
        }

        public static ProdutoDto? Map(this Produto? entidade)
        {
            if (entidade == null)
                return null;
            return new(entidade.Id)
            {
                Nome = entidade.Nome,
                Categoria = entidade.Categoria.Map(),
                Quantidade = entidade.Quantidade,
                ValorUnitario = entidade.ValorUnitario,
            };
        }







    }
}
