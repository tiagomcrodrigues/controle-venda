using ControleVenda.Application.Dto;
using ControleVenda.CrossCutting.Common.Models;

namespace ControleVenda.Application.Ports.Categorias
{
    public interface ICategoriaUpdateUseCase
    {
        IResult<bool> Execute(CategoriaDto dto);
    }
}