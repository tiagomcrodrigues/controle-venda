using ControleVenda.Api.Extensions;
using ControleVenda.Api.Models.Requests;
using ControleVenda.Api.Models.Responses;
using ControleVenda.Application.Ports.Pedidos;
using ControleVenda.Application.UseCases.Pedido;
using ControleVenda.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ControleVenda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoAddUseCase _pedidoAddUseCase;
        private readonly IPedidoCancelUseCase _pedidoCancelUseCase;

       public PedidoController
        (
            IPedidoAddUseCase pedidoAddUseCase,
           IPedidoCancelUseCase pedidoCancelUseCase

        )
        {
            _pedidoAddUseCase = pedidoAddUseCase;
            _pedidoCancelUseCase = pedidoCancelUseCase;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] PedidoRequest request)
        {
            var result = _pedidoAddUseCase.Execute(request.Map());
            if (result.Success)
                return Created(uri: string.Empty, new { id = result.Data.ToString() });

            return UnprocessableEntity(result.Errors.CapturaCriticas());
        }

        [HttpDelete("{id:int}")]
        public IActionResult CancelarPedido([FromRoute] int id)
        {
            var result = _pedidoCancelUseCase.Execute(id);
            if (result.Success)
                return NoContent();

            return UnprocessableEntity(result.Errors.CapturaCriticas());
        }


    }
}
