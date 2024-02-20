using AutoFixture;
using ControleVenda.Application.Dto;
using ControleVenda.Application.UseCases.Produtos;
using ControleVenda.CrossCutting.Common.Models;
using ControleVenda.Domain.Entities;
using Moq;

namespace ControleVenda.Test.Application.UseCases.Produtos
{
    public class ProdutoAddUseCaseTest : ProdutoUseCaseBaseTest<ProdutoAddUseCase>
    {
        protected override void Setup()
        {
            _useCase = new(_service.Object);
        }

        [Fact]
        public void ExecuteOk()
        {
            _service
                .Setup(p => p.Add(It.IsAny<Produto>()))
                .Returns(new Result<int>(ID_CATETORIA));

            var dto = _fixture.Create<ProdutoDto>();
            var result = _useCase.Execute(dto);

            Assert.True(result.Success);
            Assert.Equal(ID_CATETORIA, result.Data);

        }

       
    }
}
