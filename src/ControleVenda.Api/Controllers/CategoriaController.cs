using ControleVenda.Api.Extensions;
using ControleVenda.Api.Models.Requests;
using ControleVenda.Api.Models.Responses;
using ControleVenda.Application.Ports.Categorias;
using ControleVenda.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ControleVenda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoriaAddUseCase _categoriaAddUseCase;
        private readonly ICategoriaGetAllUseCase _categoriaGetAllUseCase;
        private readonly ICategoriaGetByIdUseCase _categoriaGetByIdUseCase;
        private readonly ICategoriaUpdateUseCase _categoriaUpdateUseCase;
        private readonly ICategoriaDeleteUseCase _categoriaDeleteUseCase;

        public CategoriaController
        (
            ICategoriaAddUseCase categoriaAddUseCase, 
            ICategoriaGetAllUseCase categoriaGetAllUseCase, 
            ICategoriaGetByIdUseCase categoriaGetByIdUseCase, 
            ICategoriaUpdateUseCase categoriaUpdateUseCase, 
            ICategoriaDeleteUseCase categoriaDeleteUseCase
        )
        {
            _categoriaAddUseCase = categoriaAddUseCase;
            _categoriaGetAllUseCase = categoriaGetAllUseCase;
            _categoriaGetByIdUseCase = categoriaGetByIdUseCase;
            _categoriaUpdateUseCase = categoriaUpdateUseCase;
            _categoriaDeleteUseCase = categoriaDeleteUseCase;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] CategoriaRequest request)
        {
            var result = _categoriaAddUseCase.Execute(request.Map());
            if (result.Success)
                return Created(uri: string.Empty, new { id = result.Data.ToString() });

            return UnprocessableEntity(result.Errors.CapturaCriticas());
        }

        [HttpGet]
        public IActionResult Get()
            => Ok(_categoriaGetAllUseCase.Execute().Select(s => s.Map()));


        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var result = _categoriaGetByIdUseCase.Execute(id);
            if (result == null)
                return NotFound(new NotificacaoModel(nameof(Categoria), "Registro não encontrado"));
            return Ok(result.Map());
        }

        [HttpPut("{id:int}")]
        public IActionResult Editar([FromRoute] int id, CategoriaRequest request)
        {
            if (_categoriaGetByIdUseCase.Execute(id) == null)
                return NotFound(new NotificacaoModel(nameof(Categoria), "Registro não encontrado"));

            var result  = _categoriaUpdateUseCase.Execute(request.Map(id));
            if (result.Success)
                return NoContent();

            return UnprocessableEntity(result.Errors.CapturaCriticas());

        }

        [HttpDelete("{id:int}")]
        public IActionResult Excluir([FromRoute] int id)
        {
            _categoriaDeleteUseCase.Execute(id);
            return NoContent();
        }

    }
}
