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
        private readonly IPedidoGetByIdUseCase _pedidoGetByIdUseCase;
        private readonly IPedidoGetAllUseCase _pedidoGetAllUseCase;
 
        public PedidoController
         (
             IPedidoAddUseCase pedidoAddUseCase,
            IPedidoCancelUseCase pedidoCancelUseCase,
            IPedidoGetByIdUseCase pedidoGetByIdUseCase,
            IPedidoGetAllUseCase pedidoGetAllUseCase

         )
        {
            _pedidoAddUseCase = pedidoAddUseCase;
            _pedidoCancelUseCase = pedidoCancelUseCase;
            _pedidoGetByIdUseCase = pedidoGetByIdUseCase;
            _pedidoGetAllUseCase = pedidoGetAllUseCase;
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
            if (result.Success && result.Data == true)
                return NoContent();

            if (result.Data == false)
                return NotFound("Pedido não encontrado");

            return UnprocessableEntity(result.Errors.CapturaCriticas());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _pedidoGetByIdUseCase.Execute(id);
            if (result == null)
                return NotFound(new NotificacaoModel(nameof(Pedido), "Registro não encontrado"));
            return Ok(result.Map());
        }


        [HttpGet]
        public IActionResult GetAll()
         => Ok(_pedidoGetAllUseCase.Execute().Select(s => s.Map()));

    }
}
