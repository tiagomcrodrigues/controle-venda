using ControleVenda.CrossCutting.Common.Models;
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
        public SimpleIdNameModel Produto { get; set; }
        public double ValorUnitario { get; set; }
        public int Quantidade { get; set; }

        public void Validate()
        {
            if (Produto == null || Produto.Id <= 0)
                AddNotification(nameof(Produto), "O Produto Id é obrigatório");

            if (ValorUnitario <= 0)
                AddNotification(nameof(PedidoId), "O valor unitário não pode ser zero ou negativo");

            if (Quantidade <= 0)
                AddNotification(nameof(Quantidade), "A quntidade deve ser informada");
        }

    }
}
