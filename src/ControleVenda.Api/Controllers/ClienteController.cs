using ControleVenda.Api.Extensions;
using ControleVenda.Api.Models.Requests;
using ControleVenda.Api.Models.Responses;
using ControleVenda.Application.Ports.Clientes;
using ControleVenda.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ControleVenda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAddUseCase _clienteAddUseCase;
        private readonly IClienteGetAllUseCase _clienteGetAllUseCase;
        private readonly IClienteGetByIdUseCase _clienteGetByIdUseCase;
        private readonly IClienteUpdateUseCase _clienteUpdateUseCase;
        private readonly IClienteDeleteUseCase _clienteDeleteUseCase;

        public ClienteController
        (
            IClienteAddUseCase clienteAddUseCase,
            IClienteGetAllUseCase clienteGetAllUseCase,
            IClienteGetByIdUseCase clienteGetByIdUseCase,
            IClienteUpdateUseCase clienteUpdateUseCase,
            IClienteDeleteUseCase clienteDeleteUseCase
        )
        {
            _clienteAddUseCase = clienteAddUseCase;
            _clienteGetAllUseCase = clienteGetAllUseCase;
            _clienteGetByIdUseCase = clienteGetByIdUseCase;
            _clienteUpdateUseCase = clienteUpdateUseCase;
            _clienteDeleteUseCase = clienteDeleteUseCase;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] ClienteRequest request)
        {
            var result = _clienteAddUseCase.Execute(request.Map());
            if (result.Success)
                return Created(uri: string.Empty, new { id = result.Data.ToString() });

            return UnprocessableEntity(result.Errors.CapturaCriticas());
        }

        [HttpGet]
        public IActionResult Get()
            => Ok(_clienteGetAllUseCase.Execute().Select(s => s.Map()));


        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _clienteGetByIdUseCase.Execute(id);
            if (result == null)
                return NotFound(new NotificacaoModel(nameof(Cliente), "Registro não encontrado"));
            return Ok(result.Map());
        }

        [HttpPut("{id:int}")]
        public IActionResult Editar([FromRoute] int id, ClienteRequest request)
        {
            if (_clienteGetByIdUseCase.Execute(id) == null)
                return NotFound(new NotificacaoModel(nameof(Cliente), "Registro não encontrado"));

            var result = _clienteUpdateUseCase.Execute(request.Map(id));
            if (result.Success)
                return NoContent();

            return UnprocessableEntity(result.Errors.CapturaCriticas());

        }

        [HttpDelete("{id:int}")]
        public IActionResult Excluir([FromRoute] int id)
        {
            _clienteDeleteUseCase.Execute(id);
            return NoContent();
        }


    }
}
