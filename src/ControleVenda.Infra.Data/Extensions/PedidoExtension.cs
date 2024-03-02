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
                ClienteId = entidade.Cliente.Id,
                ValorTotal = entidade.ValorTotal,
                Cancelado = entidade.Cancelado,
                Itens = entidade.Itens.Select(e => e.Map()).ToList()

            };

        }

        public static tb.PedidoItem Map(this dm.PedidoItem entidade)
        {
            return new tb.PedidoItem()
            {
                ProdutoId = entidade.Produto.Id,
                ValorUnitario = entidade.ValorUnitario,
                Quantidade = entidade.Quantidade
            };
        }
        public static dm.PedidoItem Map(this tb.PedidoItem tabela)
        {
            return new dm.PedidoItem(tabela.Produto.Id)
            {
                
                ValorUnitario = tabela.ValorUnitario,
                Quantidade = tabela.Quantidade,
                Produto = new() { Id = tabela.Produto.Id,Nome =  tabela.Produto.Nome}
                
            };
        }


        public static dm.Pedido Map(this tb.Pedido tabela)
        {
            return new dm.Pedido(tabela.Id)
            {
                Data = tabela.Data,
                Cliente = new() { Id = tabela.ClienteId,Nome = tabela.Cliente.Nome},
                Cancelado = tabela.Cancelado,
                Itens = tabela.Itens.Select(i => i.Map()).ToList(),
                
            };
            
        }

    }
}
