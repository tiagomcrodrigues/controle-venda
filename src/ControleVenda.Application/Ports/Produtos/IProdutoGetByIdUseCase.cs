using ControleVenda.Application.Dto;

namespace ControleVenda.Application.Ports.Produtos
{
    public interface IProdutoGetByIdUseCase
    {
        ProdutoDto? Execute(int id);
    }
}