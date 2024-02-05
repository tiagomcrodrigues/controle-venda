using ControleVenda.Api.Extensions;
using ControleVenda.Api.Models.Requests;
using ControleVenda.Api.Models.Responses;
using ControleVenda.Application.Ports.Categorias;
using ControleVenda.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleVenda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoriaAddUseCase _categoriaAddUseCase;

        public CategoriaController(ICategoriaAddUseCase categoriaAddUseCase)
        {
            _categoriaAddUseCase = categoriaAddUseCase;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] CategoriaRequest request)
        {
            var result = _categoriaAddUseCase.Execute(request.Map());
            if (result.Success)
                return Created(uri: string.Empty,new { id = result.Data.ToString() } ); 

            return UnprocessableEntity(result.Errors.CapturaCriticas()); 
        }

        


    }
}
