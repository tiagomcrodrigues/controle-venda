using ControleVenda.Api.Models.Responses;

namespace ControleVenda.Api.Extensions
{
    public static class NotificacaoExtension
    {
        public static IEnumerable<NotificacaoModel> CapturaCriticas(this IDictionary<string, string> dic)
            => dic.Select(itm => new NotificacaoModel(itm.Key, itm.Value));

    }
}
