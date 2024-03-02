using ControleVenda.Application.Dto;
using ControleVenda.Application.Extensions;
using ControleVenda.Application.Ports.Produtos;
using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Ports;

namespace ControleVenda.Application.UseCases.Produtos
{
    public class ProdutoUpdateUseCase : UseCaseBase<IProdutoService>, IProdutoUpdateUseCase
    {
        public ProdutoUpdateUseCase(IProdutoService service) : base(service)
        {
        }

        public IResult<bool> Execute(ProdutoDto dto)
            =>_service.Update(dto.Map());



    }
}
