using ControleVenda.Application.Dto;
using ControleVenda.Application.UseCases.Produtos;
using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Entities;
using Moq;

namespace ControleVenda.Test.Application.UseCases.Produtos
{
    public class ProdutoUpdateUseCaseTest : ProdutoUseCaseBaseTest<ProdutoUpdateUseCase>
    {
        protected override void Setup()
        {
            _useCase = new(_service.Object);
        }

        [Fact]
        public void ExecuteOk()
        {

            _service
                .Setup(p => p.Update(It.IsAny<Produto>()))
                .Returns(new Result<bool>(true));

            var Produto = new ProdutoDto(ID_CATETORIA) { Nome = "Produto TEST" };
            var resut = _useCase.Execute(Produto);

            Assert.True(resut.Success);

        }
    }
}
