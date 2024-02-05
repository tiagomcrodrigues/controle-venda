namespace ControleVenda.Api.Models.Responses
{
    public class NotificacaoModel
    {
        public NotificacaoModel(string propriedade, string mensagem)
        {
            Propriedade = propriedade;
            Mensagem = mensagem;
        }

        public string Propriedade { get; private set; }
        public string Mensagem { get; private set; }

    }
}
