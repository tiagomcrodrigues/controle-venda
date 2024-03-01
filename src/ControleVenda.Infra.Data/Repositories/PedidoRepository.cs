using ControleVenda.Domain.Entities;
using ControleVenda.Domain.Ports;
using ControleVenda.Infra.Data.Extensions;

namespace ControleVenda.Infra.Data.Repositories
{
    public class PedidoRepository : RepositoryBase<Pedido, Tables.Pedido>, IPedidoRepository
    {

        private readonly DbVenda _dbVenda;

        public PedidoRepository(DbVenda dbVenda) : base(dbVenda)
        {
            _dbVenda = dbVenda;
        }

        public void Cancel(Pedido pedido)
        {
            pedido.Cancelado = true;
            Update(pedido);
        }

        protected override Pedido Map(Tables.Pedido tabela)
            => tabela.Map();

        protected override Tables.Pedido Map(Pedido entidade)
            => entidade.Map();

        protected override Tables.Pedido Map(Pedido entidade, Tables.Pedido tabela)
            => tabela.Map(entidade);
    }
}
