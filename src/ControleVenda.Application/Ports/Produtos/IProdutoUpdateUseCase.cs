using ControleVenda.Application.Dto;
using ControleVenda.CrossCutting.Common.Models;

namespace ControleVenda.Application.Ports.Produtos
{
    public interface IProdutoUpdateUseCase
    {
        IResult<bool> Execute(ProdutoDto dto);
    }
}