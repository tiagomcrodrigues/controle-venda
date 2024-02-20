using ControleVenda.Application.Ports.Produtos;
using ControleVenda.Domain.Ports;

namespace ControleVenda.Application.UseCases.Produtos
{
    public class ProdutoDeleteUseCase : UseCaseBase<IProdutoService>, IProdutoDeleteUseCase
    {

        public ProdutoDeleteUseCase(IProdutoService ProdutoService) : base(ProdutoService) { }


        public void Execute(int id)
            => _service.Delete(id);

    }
}
