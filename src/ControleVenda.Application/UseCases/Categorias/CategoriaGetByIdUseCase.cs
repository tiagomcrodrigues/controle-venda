using ControleVenda.Application.Dto;
using ControleVenda.Application.Extensions;
using ControleVenda.Application.Ports.Categorias;
using ControleVenda.Domain.Ports;

namespace ControleVenda.Application.UseCases.Categorias
{
    public class CategoriaGetByIdUseCase : UseCaseBase<ICategoriaService>, ICategoriaGetByIdUseCase
    {
        public CategoriaGetByIdUseCase(ICategoriaService service) : base(service)
        {
        }

        public CategoriaDto? Execute(int id)
            => _service.GetById(id).Map();


    }
}
