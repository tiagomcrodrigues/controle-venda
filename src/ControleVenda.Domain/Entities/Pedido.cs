using Flunt.Notifications;

namespace ControleVenda.Domain.Entities
{
    public class Pedido : Notifiable<Notification>, IKeyIdentitication
    {
        public Pedido()
        {
        }

        public Pedido(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

        public DateTime Data { get; set; }= DateTime.Now;
        public int ClienteId { get; set; }
        public double ValorTotal => Itens.Sum(i => i.Quantidade * i.ValorUnitario);
        public bool Cancelado { get; set; } = false;
        public List<PedidoItem> Itens { get; set; }= new List<PedidoItem>();

        public void Validate()
        {
            // Validar campos da entidade de pedido
            if (ClienteId == null || ClienteId <= 0)
                AddNotification(nameof(ClienteId), "O Cliente Id é obrigatório");


            if (Itens == null || Itens.Count <= 0)
                AddNotification(nameof(Itens), "O Item é obrigatório");

            // Validar os campos das entidades e pedidoitem
            foreach (var item in Itens)
            {
                item.Validate();
                AddNotifications(item);
            }

        }

    }
}
