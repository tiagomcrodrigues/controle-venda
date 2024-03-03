using ControleVenda.CrossCutting.Common.Models;

namespace ControleVenda.Api.Models.Responses
{
    public class PedidoItemResponse
    {
        public int? Id { get; set; }
        public SimpleIdNameModel Produto { get; set; }
        public int? Quantidade { get; set; }
        public double ValorUnitario { get; set; }
    }

   
}
