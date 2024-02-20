using ControleVenda.Application.Dto;
using ControleVenda.Application.Extensions;
using ControleVenda.Application.Ports.Produtos;
using ControleVenda.Domain.Ports;

namespace ControleVenda.Application.UseCases.Produtos
{
    public class ProdutoGetAllUseCase : UseCaseBase<IProdutoService>, IProdutoGetAllUseCase
    {
        public ProdutoGetAllUseCase(IProdutoService service) : base(service) { }

        public IEnumerable<ProdutoDto?> Execute()
            => _service.GetAll().Select(s => s.Map());


    }
}
