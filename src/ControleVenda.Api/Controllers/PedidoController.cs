using ControleVenda.Api.Extensions;
using ControleVenda.Api.Models.Requests;
using ControleVenda.Api.Models.Responses;
using ControleVenda.Application.Ports.Clientes;
using ControleVenda.Application.Ports.Pedidos;
using ControleVenda.Application.UseCases.Pedidos;
using ControleVenda.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ControleVenda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoAddUseCase _pedidoAddUseCase;

        public PedidoController
        (
            IPedidoAddUseCase pedidoAddUseCase
        )
        {
            _pedidoAddUseCase = pedidoAddUseCase;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] PedidoRequest request)
        {
            var result = _pedidoAddUseCase.Execute(request.Map());
            if (result.Success)
                return Created(uri: string.Empty, new { id = result.Data.ToString() });

            return UnprocessableEntity(result.Errors.CapturaCriticas());
        }

        //[HttpGet]
        //public IActionResult Get()
        //    => Ok(_clienteGetAllUseCase.Execute().Select(s => s.Map()));


        //[HttpGet("{id:int}")]
        //public IActionResult GetById([FromRoute] int id)
        //{
        //    var result = _clienteGetByIdUseCase.Execute(id);
        //    if (result == null)
        //        return NotFound(new NotificacaoModel(nameof(Cliente), "Registro não encontrado"));
        //    return Ok(result.Map());
        //}

        //[HttpPut("{id:int}")]
        //public IActionResult Editar([FromRoute] int id, ClienteRequest request)
        //{
        //    if (_clienteGetByIdUseCase.Execute(id) == null)
        //        return NotFound(new NotificacaoModel(nameof(Cliente), "Registro não encontrado"));

        //    var result = _clienteUpdateUseCase.Execute(request.Map(id));
        //    if (result.Success)
        //        return NoContent();

        //    return UnprocessableEntity(result.Errors.CapturaCriticas());

        //}

        //[HttpDelete("{id:int}")]
        //public IActionResult Excluir([FromRoute] int id)
        //{
        //    _clienteDeleteUseCase.Execute(id);
        //    return NoContent();
        //}


    }
}
