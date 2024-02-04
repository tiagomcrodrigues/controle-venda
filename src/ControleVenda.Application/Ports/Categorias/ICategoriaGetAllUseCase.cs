using ControleVenda.Application.Dto;

namespace ControleVenda.Application.Ports.Categorias
{
    public interface ICategoriaGetAllUseCase
    {
        IEnumerable<CategoriaDto?> Execute();
    }
}