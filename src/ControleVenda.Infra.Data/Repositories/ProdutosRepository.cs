using ControleVenda.Domain.Entities;
using ControleVenda.Domain.Ports;
using ControleVenda.Infra.Data.Extensions;

namespace ControleVenda.Infra.Data.Repositories
{
    public class ProdutosRepository : RepositoryBase<Categoria, Tables.Categoria>, ICategoriaRepository
    {

        private readonly DbVenda _dbVenda;

        public ProdutosRepository(DbVenda dbVenda) : base(dbVenda)

        {
            _dbVenda = dbVenda;
        }

        protected override Categoria Map(Tables.Categoria tabela)
            => tabela.Map();

        protected override Tables.Categoria Map(Categoria entidade)
            => entidade.Map();

        protected override Tables.Categoria Map(Categoria entidade, Tables.Categoria tabela)
            => tabela.Map(entidade);
    }
}
