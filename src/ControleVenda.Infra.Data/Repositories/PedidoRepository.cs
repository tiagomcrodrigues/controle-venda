using ControleVenda.Domain.Entities;
using ControleVenda.Domain.Ports;
using ControleVenda.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;

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
            // pedido.Cancelado = true;
            // Update(pedido);
            _dbVenda.Database.ExecuteSqlRaw(
                $"UPDATE {nameof(Pedido)} " +
                $"SET {nameof(Pedido.Cancelado)}=b'1' " +
                $"WHERE  {nameof(Pedido.Id)}={pedido.Id};");
        }

        public override Pedido? GetById(int id)
        {
            Tables.Pedido? tabela = GetRows()
                .Where(p => p.Id == id)
                .FirstOrDefault();
            if (tabela == null)
                return null;
            return Map(tabela);
        }

        protected override IQueryable<Tables.Pedido> GetRows()
            => _dbVenda.Pedidos
                .Include(i => i.Cliente)
                .Include(i => i.Itens)
                .ThenInclude(i => i.Produto);

        protected override Pedido Map(Tables.Pedido tabela)
            => tabela.Map();

        protected override Tables.Pedido Map(Pedido entidade)
            => entidade.Map();

        protected override Tables.Pedido Map(Pedido entidade, Tables.Pedido tabela)
            => throw new InvalidOperationException("Alteração de pedido não é permitida");
    }
}
