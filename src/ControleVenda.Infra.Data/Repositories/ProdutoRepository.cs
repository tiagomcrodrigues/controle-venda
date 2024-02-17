using ControleVenda.Domain.Entities;
using ControleVenda.Domain.Ports;
using ControleVenda.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ControleVenda.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto, Tables.Produto>, IProdutoRepository
    {

        private readonly DbVenda _dbVenda;

        public ProdutoRepository(DbVenda dbVenda) : base(dbVenda)

        {
            _dbVenda = dbVenda;
        }

        protected override Produto Map(Tables.Produto tabela)
            => tabela.Map();

        protected override Tables.Produto Map(Produto entidade)
            => entidade.Map();

        protected override Tables.Produto Map(Produto entidade, Tables.Produto tabela)
            => tabela.Map(entidade);

    }
}
