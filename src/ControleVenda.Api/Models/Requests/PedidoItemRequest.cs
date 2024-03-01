namespace ControleVenda.Api.Models.Requests
{
    public class PedidoItemRequest
    {

        public int? ProdutoId { get; set; }
        public int? Quantidade { get; set; }
    }
}
