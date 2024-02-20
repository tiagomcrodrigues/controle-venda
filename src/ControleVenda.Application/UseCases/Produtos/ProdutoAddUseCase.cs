using ControleVenda.Application.Dto;
using ControleVenda.Application.Extensions;
using ControleVenda.Application.Ports.Produtos;
using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Ports;

namespace ControleVenda.Application.UseCases.Produtos
{
    public class ProdutoAddUseCase  : UseCaseBase<IProdutoService>, IProdutoAddUseCase
    {

        public ProdutoAddUseCase(IProdutoService ProdutoService) : base(ProdutoService) { }
        
        public IResult<int> Execute(ProdutoDto dto)
            => _service.Add(dto.Map());

    }
}
