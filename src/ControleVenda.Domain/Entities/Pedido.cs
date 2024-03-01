using ControleVenda.CrossCutting.Common.Models;
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
        public SimpleIdNameModel Cliente { get; set; }
        public double ValorTotal => Itens.Sum(i => i.Quantidade * i.ValorUnitario);
        public bool Cancelado { get; set; } = false;
        public List<PedidoItem> Itens { get; set; }= new List<PedidoItem>();

        public void Validate()
        {
            // Validar campos da entidade de pedido
            if (Cliente.Id <= 0)
                AddNotification(nameof(Cliente), "O Cliente Id é obrigatório");


            if (!Itens?.Any() ?? false)
            {
                AddNotification(nameof(Itens), "O Item é obrigatório");
            }
            else
            {
                // Validar os campos das entidades e pedidoitem
                foreach (var item in Itens)
                {
                    item.Validate();
                    AddNotifications(item);
                }
            }

        }

    }
}
