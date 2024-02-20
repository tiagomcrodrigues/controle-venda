using Flunt.Notifications;

namespace ControleVenda.Domain.Entities
{
    public class Cliente : Notifiable<Notification>, IKeyIdentitication
    {

        public Cliente()
        {
        }

        public Cliente(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
        public string? Nome { get; set; }
        public string? TipoDePessoa { get; set; }
        public string? Documento { get; set; }
        public string? TipoLogradouro { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                AddNotification(nameof(Nome), "O nome é obrigatório");

            if (Nome?.Length > 100 || Nome?.Length < 2)
                AddNotification(nameof(Nome), "O nome deve conter entre 2 e 50 caracteres");

            if (string.IsNullOrWhiteSpace(TipoDePessoa))
                AddNotification(nameof(TipoDePessoa), "O Tipo De Pessoa é obrigatório");

            if (TipoDePessoa?.Length > 1)
                AddNotification(nameof(TipoDePessoa), "O Tipo De Pessoa deve conter a letra  ( J ) para Juridica ou ( F ) fisica ");

            if (string.IsNullOrWhiteSpace(TipoLogradouro))
                AddNotification(nameof(TipoLogradouro), $"O {nameof(TipoLogradouro)} é obrigatório");

            if (TipoLogradouro?.Length < 2 || Documento?.Length > 30)
                AddNotification(nameof(TipoLogradouro), $"O {nameof(TipoLogradouro)} deve conter entre 1 e 30 caracteres");

            if (string.IsNullOrWhiteSpace(Documento))
                AddNotification(nameof(Documento), $"O {nameof(Documento)} é obrigatório");

            if (Documento?.Length < 2 || Documento?.Length > 14)
                AddNotification(nameof(Documento), $"O {nameof(Documento)} esta invalido");

            if (string.IsNullOrWhiteSpace(Logradouro))
                AddNotification(nameof(Logradouro), $"O {nameof(Logradouro)} é obrigatório");

            if (Logradouro?.Length < 2 || Logradouro?.Length > 30)
                AddNotification(nameof(Logradouro), $"O {nameof(Logradouro)} deve conter entre 2 e 30 Caracteres ");

            if (string.IsNullOrWhiteSpace(Numero ))
                AddNotification(nameof(Numero), $"O {nameof(Numero)} é obrigatório");

            if (Numero?.Length <= 1 || Numero?.Length > 20)
                AddNotification(nameof(Numero), $"O {nameof(Numero)} deve conter entre 2 e 20 Caracteres");

            if (Complemento?.Length <= 1 || Complemento?.Length > 50)
                AddNotification(nameof(Complemento), $"O {nameof(Complemento)} deve conter entre 2 e 50 Caracteres");

            if (string.IsNullOrWhiteSpace(Bairro))
                AddNotification(nameof(Bairro), $"O {nameof(Bairro)} é obrigatório");

            if (Bairro?.Length <= 1 || Bairro?.Length > 50)
                AddNotification(nameof(Bairro), $"O {nameof(Bairro)} deve conter entre 2 e 50 Caracteres ");

            if (string.IsNullOrWhiteSpace(Cidade))
                AddNotification(nameof(Cidade), $"O {nameof(Cidade)} é obrigatório");

            if (Cidade?.Length <= 1 || Cidade?.Length > 100)
                AddNotification(nameof(Cidade), $"O {nameof(Cidade)} deve conter entre 2 e 100 Caracteres ");

            if (string.IsNullOrWhiteSpace(Uf))
                AddNotification(nameof(Uf), $"O {nameof(Uf)} é obrigatório");

            if (Uf?.Length <= 1 || Uf?.Length > 20)
                AddNotification(nameof(Uf), $"O {nameof(Uf)} deve conter entre 2 e 20 Caracteres ");

            if (Telefone?.Length <= 1 || Telefone?.Length > 15)
                AddNotification(nameof(Telefone), $"O {nameof(Telefone)} deve conter 2 e 15 Caracteres ");

            if (Email?.Length <= 1 || Email?.Length > 254)
                AddNotification(nameof(Email), $"O {nameof(Email)} deve conter entre 2 e 254 Caracteres ");
        }

    }
}
