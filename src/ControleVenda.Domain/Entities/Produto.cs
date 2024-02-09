using Flunt.Notifications;

namespace ControleVenda.Domain.Entities
{
    public class Produto : Notifiable<Notification>
    {
        public Produto()
        {
        }

        public Produto(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
        public string? Nome { get; set; }
        public double ValorUnitario { get; set; }
        public int Quntidade { get; set; }
        
        public Categoria? Categoria { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                AddNotification(nameof(Nome), "O nome é obrigatório");

            if (Nome?.Length > 100 || Nome?.Length<2)
                AddNotification(nameof(Nome), "O nome deve conter entre 2 e 100 caracteres");

            if (Categoria == null)
            {
                AddNotification(nameof(Categoria), "A categoria deve ser informada");
            }
            else
            {
                Categoria.Validate();
                AddNotifications(Categoria.Notifications);
            }
            
            if (ValorUnitario <= 0)
                AddNotification(nameof(ValorUnitario), "o valor unitario é obrigatorio");

            if (Quntidade <= 0 )
                AddNotification(nameof(Quntidade), "A quntidade é obrigatorio");
        }


    }
}
