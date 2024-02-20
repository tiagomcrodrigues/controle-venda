using tb = ControleVenda.Infra.Data.Tables;
using dm = ControleVenda.Domain.Entities;

namespace ControleVenda.Infra.Data.Extensions
{
    public static class ProdutoExtensions
    {
        public static tb.Produto Map(this dm.Produto entidade)
        {
            return new tb.Produto()
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                ValorUnitario = entidade.ValorUnitario,
                Quantidade = entidade.Quantidade,
                CategoriaId = entidade.Categoria.Id
            };
        }

        public static dm.Produto Map(this tb.Produto tabela)
            => new(tabela.Id)
            {
                Nome = tabela.Nome,
                ValorUnitario = tabela.ValorUnitario,
                Quantidade = tabela.Quantidade,
                Categoria = tabela.Categoria.Map()
            };


        public static tb.Produto Map(this tb.Produto tabela, dm.Produto entidade)
        {
            tabela.Nome = entidade.Nome;
            tabela.ValorUnitario = entidade.ValorUnitario;
            tabela.Quantidade = entidade.Quantidade;
            tabela.CategoriaId = entidade.Categoria.Id;
            return tabela;
        }


    }
}
