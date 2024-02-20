using AutoFixture;
using ControleVenda.Application.UseCases.Produtos;
using ControleVenda.Domain.Entities;
using Moq;

namespace ControleVenda.Test.Application.UseCases.Produtos
{
    public class ProdutoGetByIdUseCaseTest : ProdutoUseCaseBaseTest<ProdutoGetByIdUseCase>
    {
        protected override void Setup()
        {
            _useCase = new(_service.Object);
        }

        [Fact]
        public void ExecuteOk()
        {
            Produto Produto = _fixture.Create<Produto>();
            _service
                .Setup(p => p.GetById(It.IsAny<int>()))
                .Returns(Produto);

            var result = _useCase.Execute(ID_CATETORIA);

            Assert.NotNull(result);

        }
    }
}
