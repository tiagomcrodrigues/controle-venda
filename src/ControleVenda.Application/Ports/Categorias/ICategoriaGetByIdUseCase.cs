using ControleVenda.Application.Dto;

namespace ControleVenda.Application.Ports.Categorias
{
    public interface ICategoriaGetByIdUseCase
    {
        CategoriaDto? Execute(int id);
    }
}