using ControleVenda.Api.Extensions;
using ControleVenda.Api.Models.Requests;
using ControleVenda.Api.Models.Responses;
using ControleVenda.Application.Ports.Produtos;
using ControleVenda.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ControleVenda.Api.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAddUseCase _ProdutoAddUseCase;
        private readonly IProdutoGetAllUseCase _ProdutoGetAllUseCase;
        private readonly IProdutoGetByIdUseCase _ProdutoGetByIdUseCase;
        private readonly IProdutoUpdateUseCase _ProdutoUpdateUseCase;
        private readonly IProdutoDeleteUseCase _ProdutoDeleteUseCase;

        public ProdutoController
        (
            IProdutoAddUseCase ProdutoAddUseCase,
            IProdutoGetAllUseCase ProdutoGetAllUseCase,
            IProdutoGetByIdUseCase ProdutoGetByIdUseCase,
            IProdutoUpdateUseCase ProdutoUpdateUseCase,
            IProdutoDeleteUseCase ProdutoDeleteUseCase
        )
        {
            _ProdutoAddUseCase = ProdutoAddUseCase;
            _ProdutoGetAllUseCase = ProdutoGetAllUseCase;
            _ProdutoGetByIdUseCase = ProdutoGetByIdUseCase;
            _ProdutoUpdateUseCase = ProdutoUpdateUseCase;
            _ProdutoDeleteUseCase = ProdutoDeleteUseCase;
        }


        [HttpPost]
        public IActionResult Criar([FromBody] ProdutoRequest request)
        {
            var result = _ProdutoAddUseCase.Execute(request.Map());
            if (result.Success)
                return Created(uri: string.Empty, new { id = result.Data.ToString() });

            return UnprocessableEntity(result.Errors.CapturaCriticas());
        }

        [HttpGet]
        public IActionResult Get()
            => Ok(_ProdutoGetAllUseCase.Execute().Select(s => s.Map()));


        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _ProdutoGetByIdUseCase.Execute(id);
            if (result == null)
                return NotFound(new NotificacaoModel(nameof(Produto), "Registro não encontrado"));
            return Ok(result.Map());
        }

        [HttpPut("{id:int}")]
        public IActionResult Editar([FromRoute] int id, ProdutoRequest request)
        {
            if (_ProdutoGetByIdUseCase.Execute(id) == null)
                return NotFound(new NotificacaoModel(nameof(Produto), "Registro não encontrado"));

            var result = _ProdutoUpdateUseCase.Execute(request.Map(id));
            if (result.Success)
                return NoContent();

            return UnprocessableEntity(result.Errors.CapturaCriticas());

        }

        [HttpDelete("{id:int}")]
        public IActionResult Excluir([FromRoute] int id)
        {
            _ProdutoDeleteUseCase.Execute(id);
            return NoContent();
        }


    }
}
