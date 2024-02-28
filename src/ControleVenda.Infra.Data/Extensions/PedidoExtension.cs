using tb = ControleVenda.Infra.Data.Tables;
using dm = ControleVenda.Domain.Entities;


namespace ControleVenda.Infra.Data.Extensions
{
    public static class PedidoExtension
    {
        public static tb.Pedido Map(this dm.Pedido entidade)
        {
            return new tb.Pedido()
            {
                Data = entidade.Data,
                ClienteId = entidade.ClienteId,
                ValorTotal = entidade.ValorTotal,
                Cancelado = entidade.Cancelado,
                Itens = entidade.Itens.Select(e => e.Map()).ToList()

            };

        }

        public static tb.PedidoItem Map(this dm.PedidoItem entidade)
        {
            return new tb.PedidoItem()
            {
                ProdutoId = entidade.ProdutoId,
                ValorUnitario = entidade.ValorUnitario,
                Quantidade = entidade.Quantidade
            };
        }


    }
}
