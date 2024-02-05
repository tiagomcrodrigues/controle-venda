using ControleVenda.Api.Models.Responses;
using Flunt.Notifications;

namespace ControleVenda.Api.Extensions
{
    public static class NotificacaoExtension
    {
        public static IEnumerable<NotificacaoModel> CapturaCriticas(this IEnumerable<Notification> notificacoes)
            => notificacoes.Select(itm => new NotificacaoModel(itm.Key, itm.Message));

    }
}
