using Flunt.Notifications;

namespace ControleVenda.Domain.Entities
{
    public class PedidoItem : Notifiable<Notification>, IKeyIdentitication
    {
        public PedidoItem()
        {
        }

        public PedidoItem(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int ValorUnitario { get; set; }
        public int Quantidade { get; set; }

        public void Validate()
        {
            //TODO: NotImplementedException
            if (ProdutoId == null || ProdutoId <= 0)
                AddNotification(nameof(ProdutoId), "O Produto Id é obrigatório");


            if (PedidoId == null || PedidoId<= 0)
                AddNotification(nameof(PedidoId), "O Pedido Id é obrigatório");

            if (Quantidade == null || Quantidade <= 0)
                AddNotification(nameof(Quantidade), "A quntidade deve ser informada");
        }

    }
}
