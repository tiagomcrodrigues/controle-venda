using ControleVenda.Api.Models.Requests;
using ControleVenda.CrossCutting.Common.Models;

namespace ControleVenda.Api.Models.Responses
{
    public class PedidoResponse
    {
        public int? Id { get; set; }
        public SimpleIdNameModel Cliente { get; set; }
        public IEnumerable<PedidoItemResponse> Itens { get; set; } = new List<PedidoItemResponse>();
        public DateTime Data { get; set; }
        public double ValorTotal { get; set; }
        public bool Cancelado { get; set; }


    }

   
}
