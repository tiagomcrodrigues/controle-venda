using tb = ControleVenda.Infra.Data.Tables;
using dm = ControleVenda.Domain.Entities;

namespace ControleVenda.Infra.Data.Extensions
{
    internal static class CategoriaExtension
    {
        public static tb.Categoria Map(this dm.Categoria entidade)
        {
            return new tb.Categoria()
            {
                Nome = entidade.Nome
            };
        }

        public static dm.Categoria Map(this tb.Categoria tabela)
            => new(tabela.Id)
            {
                Nome = tabela.Nome
            };

        public static tb.Categoria Map(this tb.Categoria tabela, dm.Categoria entidade)
        {
            tabela.Nome = entidade.Nome;
            return tabela;
        }

    }

}
