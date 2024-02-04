using ControleVenda.Application.Dto;
using ControleVenda.Application.Extensions;
using ControleVenda.Application.Ports.Categorias;
using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Ports;

namespace ControleVenda.Application.UseCases.Categorias
{
    public class CategoriaAddUseCase  : UseCaseBase<ICategoriaService>, ICategoriaAddUseCase
    {

        public CategoriaAddUseCase(ICategoriaService categoriaService) : base(categoriaService) { }
        
        public IResult<int> Execute(CategoriaDto dto)
            => _service.Add(dto.Map());

    }
}
