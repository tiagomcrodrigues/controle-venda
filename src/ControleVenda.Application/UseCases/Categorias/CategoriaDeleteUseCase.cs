using ControleVenda.Application.Ports.Categorias;
using ControleVenda.Domain.Ports;

namespace ControleVenda.Application.UseCases.Categorias
{
    public class CategoriaDeleteUseCase : UseCaseBase<ICategoriaService>, ICategoriaDeleteUseCase
    {

        public CategoriaDeleteUseCase(ICategoriaService categoriaService) : base(categoriaService) { }


        public void Execute(int id)
            => _service.Delete(id);

    }
}
