using ControleVenda.Application.Dto;
using ControleVenda.Application.Extensions;
using ControleVenda.Application.Ports.Categorias;
using ControleVenda.Domain.Ports;

namespace ControleVenda.Application.UseCases.Categorias
{
    public class CategoriaGetAllUseCase : UseCaseBase<ICategoriaService>, ICategoriaGetAllUseCase
    {
        public CategoriaGetAllUseCase(ICategoriaService service) : base(service) { }

        public IEnumerable<CategoriaDto?> Execute()
            => _service.GetAll().Select(s => s.Map());


    }
}
