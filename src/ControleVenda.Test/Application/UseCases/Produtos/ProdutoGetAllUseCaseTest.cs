using AutoFixture;
using ControleVenda.Application.UseCases.Produtos;
using ControleVenda.Domain.Entities;

namespace ControleVenda.Test.Application.UseCases.Produtos
{
    public class ProdutoGetAllUseCaseTest : ProdutoUseCaseBaseTest<ProdutoGetAllUseCase>
    {
        protected override void Setup()
        {
            _useCase = new(_service.Object);
        }
        [Fact]
        public void ExecuteOk()
        {
            IEnumerable<Produto> dto = _fixture.Create<IEnumerable<Produto>>();
            _service
                .Setup(p => p.GetAll())
                .Returns(dto);

            var result = _useCase.Execute();

            Assert.True(result.Any());

        }
    }
}
