using tb = ControleVenda.Infra.Data.Tables;
using dm = ControleVenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Quntidade = entidade.Quantidade,
                CategoriaId = entidade.Categoria.Id,
                Categoria = entidade.Categoria.Map()
            };
        }
    }
}
