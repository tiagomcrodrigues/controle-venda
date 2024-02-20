using ControleVenda.Application.Dto;
using ControleVenda.Application.Extensions;
using ControleVenda.Application.Ports.Produtos;
using ControleVenda.Domain.Ports;

namespace ControleVenda.Application.UseCases.Produtos
{
    public class ProdutoGetByIdUseCase : UseCaseBase<IProdutoService>, IProdutoGetByIdUseCase
    {
        public ProdutoGetByIdUseCase(IProdutoService service) : base(service)
        {
        }

        public ProdutoDto? Execute(int id)
            => _service.GetById(id).Map();


    }
}
