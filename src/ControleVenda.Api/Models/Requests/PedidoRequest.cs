namespace ControleVenda.Api.Models.Requests
{
    public class PedidoRequest
    {

        public int? ClenteId { get; set; }
        public IEnumerable<PedidoItemRequest> Itens { get; set; } = new List<PedidoItemRequest>();

    }
}
