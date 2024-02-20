using ControleVenda.Application.Dto;

namespace ControleVenda.Application.Ports.Produtos
{
    public interface IProdutoGetAllUseCase
    {
        IEnumerable<ProdutoDto?> Execute();
    }
}