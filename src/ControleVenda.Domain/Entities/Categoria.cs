using Flunt.Notifications;

namespace ControleVenda.Domain.Entities
{
    public class Categoria : Notifiable<Notification>, IKeyIdentitication
    {
        public Categoria()
        {
        }

        public Categoria(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }

        public string? Nome { get; set; }

        public void Validate()
        {

            if (string.IsNullOrWhiteSpace(Nome))
                AddNotification(nameof(Nome), "O nome é obrigatório");

            if (Nome?.Length <2 || Nome?.Length > 100)
                AddNotification(nameof(Nome), "O nome deve conter entre 2 e 100 caracteres");
        }

    }
}
